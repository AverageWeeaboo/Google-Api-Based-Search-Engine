﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Models
{


    public class SearchViewModel
    {
        protected string apiID = "012776195944492167572:hvfearqxilu";
        protected string key = "AIzaSyCEwllTx8dDBvu6EFUhnneQBSmLFOxdxl4";

        public SearchViewModel ()
        {
            this.api = "https://www.googleapis.com/customsearch/v1?key=" + key + "&cx=" + apiID + "&q=";
            this.Results = new List<Result>();
            this.TotalResults = 0;
            this.Index = 0;
            this.MaxPages = 0;
        }

        public void SetMaxPages ()
        {
            this.MaxPages = Convert.ToInt32(Math.Ceiling(TotalResults / 10.0));
        }
        public string SearchQuery { set; get; }
        public string api { set; get; }
        public int Index { set; get; }
        public int TotalResults { set; get; }
        public int MaxPages { set; get; }
        public List<Result> Results { set; get; }
    }

}