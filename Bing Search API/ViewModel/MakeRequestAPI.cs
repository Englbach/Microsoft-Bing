
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bing_Search_API.ViewModel
{
    public class MakeRequestAPI
    {
        public class WebResponse
        {
            public async Task<string> GetResponseAsync(string q, string count, string offset, string mkt, string safeSearch)
            {
                var client = new HttpClient();
                var queryString = new Dictionary<string, string>();

                //request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b5c6f22830d44aa8a776fc6e8ba9f05f");

                //request parameters
                queryString.Add("q", q);
                queryString.Add("count", count);
                queryString.Add("offset", offset);
                queryString.Add("mkt", mkt);
                queryString.Add("safesearch", safeSearch);

                var uri = "https://bingapis.azure-api.net/api/v5/search/?"
                    + "&q=" + queryString["q"]
                    + "&count=" + queryString["count"]
                    + "&offset" + queryString["offset"]
                    + "&mkt" + queryString["mkt"]
                    + "&safesearch" + queryString["safesearch"];

                var response = await client.GetAsync(uri);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public class NewsResponse 
        {
            public async Task<string> GetResponseAsync(string q, string count, string offset, string mkt, string safeSearch)
            {
                var client = new HttpClient();
                var queryString = new Dictionary<string, string>();

                //request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b5c6f22830d44aa8a776fc6e8ba9f05f");

                //request parameters
                queryString.Add("q", q);
                queryString.Add("count", count);
                queryString.Add("offset", offset);
                queryString.Add("mkt", mkt);
                queryString.Add("safesearch", safeSearch);

                var uri = "https://bingapis.azure-api.net/api/v5/news/search/?"
                    + "&q=" + queryString["q"]
                    + "&count=" + queryString["count"]
                    + "&offset" + queryString["offset"]
                    + "&mkt" + queryString["mkt"]
                    + "&safesearch" + queryString["safesearch"];

                var response = await client.GetAsync(uri);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public class PhotosResponse
        {
            public async Task<string> GetResponseAsync(string q, string count, string offset, string mkt, string safeSearch)
            {
                var client = new HttpClient();
                var queryString = new Dictionary<string, string>();

                //request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b5c6f22830d44aa8a776fc6e8ba9f05f");

                //request parameters
                queryString.Add("q", q);
                queryString.Add("count", count);
                queryString.Add("offset", offset);
                queryString.Add("mkt", mkt);
                queryString.Add("safesearch", safeSearch);
                //...........................//

                var uri = "https://bingapis.azure-api.net/api/v5/images/search/?&license=Public"
                    + "&q=" + queryString["q"]
                    + "&count=" + queryString["count"]
                    + "&offset" + queryString["offset"]
                    + "&mkt" + queryString["mkt"]
                    + "&safesearch" + queryString["safesearch"];
                   

                var response = await client.GetAsync(uri);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public class VideosResponse
        {
            public async Task<string> GetResponseAsync(string q, string count, string offset, string mkt, string safeSearch)
            {
                var client = new HttpClient();
                var queryString = new Dictionary<string, string>();

                //request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b5c6f22830d44aa8a776fc6e8ba9f05f");

                //request parameters
                queryString.Add("q", q);
                queryString.Add("count", count);
                queryString.Add("offset", offset);
                queryString.Add("mkt", mkt);
                queryString.Add("safesearch", safeSearch);
                //...........................//

                var uri = "https://bingapis.azure-api.net/api/v5/videos/search/?&pricing=Free"
                    + "&q=" + queryString["q"]
                    + "&count=" + queryString["count"]
                    + "&offset" + queryString["offset"]
                    + "&mkt" + queryString["mkt"]
                    + "&safesearch" + queryString["safesearch"];


                var response = await client.GetAsync(uri);

                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
