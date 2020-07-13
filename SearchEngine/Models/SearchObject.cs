using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchEngine.Models
{
    public class SearchObject
    {
        public class Rootobject
        {
            public string kind { get; set; }
            public Url url { get; set; }
            public Queries queries { get; set; }
            public Context context { get; set; }
            public Searchinformation searchInformation { get; set; }
            public Item[] items { get; set; }
        }

        public class Url
        {
            public string type { get; set; }
            public string template { get; set; }
        }

        public class Queries
        {
            public Request[] request { get; set; }
            public Nextpage[] nextPage { get; set; }
        }

        public class Request
        {
            public string title { get; set; }
            public string totalResults { get; set; }
            public string searchTerms { get; set; }
            public int count { get; set; }
            public int startIndex { get; set; }
            public string inputEncoding { get; set; }
            public string outputEncoding { get; set; }
            public string safe { get; set; }
            public string cx { get; set; }
        }

        public class Nextpage
        {
            public string title { get; set; }
            public string totalResults { get; set; }
            public string searchTerms { get; set; }
            public int count { get; set; }
            public int startIndex { get; set; }
            public string inputEncoding { get; set; }
            public string outputEncoding { get; set; }
            public string safe { get; set; }
            public string cx { get; set; }
        }

        public class Context
        {
            public string title { get; set; }
        }

        public class Searchinformation
        {
            public float searchTime { get; set; }
            public string formattedSearchTime { get; set; }
            public string totalResults { get; set; }
            public string formattedTotalResults { get; set; }
        }

        public class Item
        {
            public string kind { get; set; }
            public string title { get; set; }
            public string htmlTitle { get; set; }
            public string link { get; set; }
            public string displayLink { get; set; }
            public string snippet { get; set; }
            public string htmlSnippet { get; set; }
            public string cacheId { get; set; }
            public string formattedUrl { get; set; }
            public string htmlFormattedUrl { get; set; }
            public Pagemap pagemap { get; set; }
        }

        public class Pagemap
        {
            public Thumbnail[] thumbnail { get; set; }
            public Document[] document { get; set; }
            public Metatag[] metatags { get; set; }
            public Videoobject[] videoobject { get; set; }
            public Cse_Image[] cse_image { get; set; }
            public Cse_Thumbnail[] cse_thumbnail { get; set; }
        }

        public class Thumbnail
        {
            public string src { get; set; }
        }

        public class Document
        {
            public string author { get; set; }
            public string description { get; set; }
            public string tag { get; set; }
            public string title { get; set; }
            public string type { get; set; }
        }

        public class Metatag
        {
            public string ogimage { get; set; }
            public string appleitunesapp { get; set; }
            public string ogtype { get; set; }
            public string twittercard { get; set; }
            public string twittertitle { get; set; }
            public string thumbnail { get; set; }
            public string ogsite_name { get; set; }
            public string ogtitle { get; set; }
            public string title { get; set; }
            public string ogdescription { get; set; }
            public string twitterimage { get; set; }
            public string video_type { get; set; }
            public string fbapp_id { get; set; }
            public string twittersite { get; set; }
            public string ogvideo { get; set; }
            public string viewport { get; set; }
            public string twitterdescription { get; set; }
            public string fbadmins { get; set; }
            public string fbpage_id { get; set; }
            public string ogvideotype { get; set; }
            public string ogurl { get; set; }
            public string msvalidate01 { get; set; }
            public string synonyms { get; set; }
            public string applemobilewebappcapable { get; set; }
            public string nextheadcount { get; set; }
            public string twitterimagesrc { get; set; }
            public string ogimagewidth { get; set; }
            public string ogimageheight { get; set; }
        }

        public class Videoobject
        {
            public string transcript { get; set; }
            public DateTime uploaddate { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string thumbnailurl { get; set; }
        }

        public class Cse_Image
        {
            public string src { get; set; }
            public string width { get; set; }
            public string type { get; set; }
            public string height { get; set; }
        }

        public class Cse_Thumbnail
        {
            public string src { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }


    }
}