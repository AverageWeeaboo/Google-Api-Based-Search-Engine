using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CustomFunctionLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SearchEngine.Models;

namespace SearchEngine.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Tabify(SearchViewModel Search, string command)
        {
            ModelState.Clear();
            if (command.Equals("Previous") && Search.Index !=0)
            {
                Search.Index--;
            }
            else if (command.Equals("Next") && Search.Index < (Search.MaxPages-1))
            {
                Search.Index++;
            }
            else
            {
                Search.Index = Convert.ToInt32(command) - 1;
            }
            Search = PerformSearch(Search);
            return View("Index", Search);
        }
        public IActionResult Search(SearchViewModel Search)
        {

            Search = PerformSearch(Search);
            return View("Index", Search);
        }
    

        protected SearchViewModel PerformSearch(SearchViewModel Search)
        {
            try
            {
                if (TryValidateModel(Search))
                {
                    if (!string.IsNullOrWhiteSpace(Search.SearchQuery))
                    {
                        List<string> searchTerms = new List<string>(Search.SearchQuery.Split(" "));
                        string excludedTerms = string.Empty;
                        string includedTerms = string.Empty;
                        string searchQuery = string.Empty;
                        foreach (string term in searchTerms)
                        {
                            if (term.StartsWith('-'))
                            {

                                excludedTerms += $"+{term.Substring(1)}";
                            }
                            else if (term.StartsWith('+'))
                            {
                                includedTerms += $"+{term.Substring(1)}";
                            }
                            else
                            {
                                searchQuery += $"+{term}";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(excludedTerms))
                        {
                            excludedTerms = excludedTerms.Substring(1);
                        }
                        if (!string.IsNullOrWhiteSpace(includedTerms))
                        {
                            includedTerms = includedTerms.Substring(1);
                        }
                        if (!string.IsNullOrWhiteSpace(searchQuery))
                        {
                            searchQuery = searchQuery.Substring(1);
                        }
                        string query = $"{GetApiString(Search.api)}{searchQuery}&start={Search.Index*10 +1}";
                        if(!string.IsNullOrWhiteSpace(includedTerms))
                        {
                            query += $"&exactTerms={includedTerms}";
                        }
                        if (!string.IsNullOrWhiteSpace(excludedTerms))
                        {
                            query += $"&excludeTerms={excludedTerms}";
                        }
                        
                        string json = new WebClient().DownloadString(query);
                        SearchObject.Rootobject searchObj = JsonConvert.DeserializeObject<SearchObject.Rootobject>(json);
                        Search.Results = Get_Results(searchObj);
                        Search.TotalResults = Convert.ToInt32(searchObj.searchInformation.totalResults);
                        Search.SetMaxPages();
                    }
                }
            }
            catch
            {
                Search = new SearchViewModel();
            }
            return Search;
        }
        protected List<Result> Get_Results(SearchObject.Rootobject searchObj)
        {
            //Extract all of the necessary result specific data from the search result object
            List<Result> value = new List<Result>();
            try
            {
                if (searchObj != null)
                {
                    
                    if (searchObj.items != null)
                    {
                        foreach(SearchObject.Item item in searchObj.items )
                        {
                            string src = string.Empty;
                            if (item.pagemap != null)
                            {
                                if (item.pagemap.cse_image != null)
                                {
                                    if (item.pagemap.cse_image.Length > 0)
                                    {
                                        src = item.pagemap.cse_image[0].src;
                                    }
                                }
                            }
                            value.Add(new Result(item.title, item.link, item.displayLink, item.snippet, src));
                        }
                    }
                }
            }
            catch 
            {
                return new List<Result>();
            }

            return value;
        }

        public IActionResult Index()
        {
            return View("Index", new SearchViewModel()); ;
        }

        private string GetApiString(string baseStr)
        {
            StringEncryption encryptor = new StringEncryption();
            string query = baseStr;
            string str =_configuration.GetValue<string>("ApiKey");
            query += encryptor.Decode(_configuration.GetValue<string>("ApiKey"), Convert.ToUInt64(_configuration.GetValue<string>("DecryptKey"))) + "&cx=";
            query += encryptor.Decode(_configuration.GetValue<string>("ApiConnString"), Convert.ToUInt64(_configuration.GetValue<string>("DecryptKey"))) + "&q=";
            return query;
        }
    }

   

}
