using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Models
{
    public class Result
    {

        public Result (string name, string url, string surl, string desc, string thumbnailSrc)
        {
            this.Name = name;
            this.Url = url;
            this.ShortUrl = surl;
            this.Description = desc;
            this.ThumbnailSrc = thumbnailSrc;
        }
        public string Name { set; get; }
        public string Url { set; get; }

        public string ShortUrl { set; get; }
        public string Description { set; get; }

        public string ThumbnailSrc {set; get;}
        
    }


}
