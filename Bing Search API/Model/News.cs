using System.Collections.Generic;

namespace Bing_Search_API.Model
{
    public class News
    {
        public class Thumbnail 
        {
            public string contentUrl { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Image
        {
            public Thumbnail thumbnail { get; set; }
        }

        public class About
        {
            public string readLink { get; set; }
            public string name { get; set; }
        }

        public class Provider
        {
            public string _type { get; set; }
            public string name { get; set; }
        }

        public class About2
        {
            public string readLink { get; set; }
            public string name { get; set; }
        }

        public class Provider2
        {
            public string _type { get; set; }
            public string name { get; set; }
        }

        public class ClusteredArticle
        {
            public string name { get; set; }
            public string url { get; set; }
            public string description { get; set; }
            public List<About2> about { get; set; }
            public List<Provider2> provider { get; set; }
            public string datePublished { get; set; }
            public string category { get; set; }
        }

        public class Mention
        {
            public string name { get; set; }
        }


        public class Value : Webs.Value
        {

            public Image image { get; set; }
            public string description { get; set; }
            public List<Provider> provider { get; set; }
            public string datePublished { get; set; }
            public string category { get; set; }
            public List<ClusteredArticle> clusteredArticles { get; set; }
            public List<Mention> mentions { get; set; }
        }
        public class Error
        {
            public string code { get; set; }
            public string message { get; set; }
            public string parameter { get; set; }
        }

        public class NewsRootObject
        {
            public string _type { get; set; }
          
            public List<Value> value { get; set; }
            public List<Error> errors { get; set; }
        }
    }
}
