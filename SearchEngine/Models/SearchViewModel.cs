using CustomFunctionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Models
{


    public class SearchViewModel
    {
        protected string apiID = "=!S&tBWl^r(36ShX9nJ,q45EH+,A*26qZ/\\C<Q#!guJO+";
        protected string key = "-<rnh\"7HGA:a*W$_Jb/Equ)^*)!pf8?t7J2>DJI@m$(3&%B[(B";
        protected ulong DecryptKey = 208299813696966;

        public SearchViewModel ()
        {
            //Custom encryption
            StringEncryption encryptor = new StringEncryption();
            this.api = "https://www.googleapis.com/customsearch/v1?key=" + encryptor.Decode(key, DecryptKey) + "&cx=" + encryptor.Decode(apiID, DecryptKey) + "&q=";
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
