using Newtonsoft.Json;

namespace Bing_Search_API.Model
{
    public class HistoryBrowser
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "DateCreation")]
        public string DateCreation { get; set; }

        [JsonProperty(PropertyName = "ContentDisplay")]
        public string ContentDisplay { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}
