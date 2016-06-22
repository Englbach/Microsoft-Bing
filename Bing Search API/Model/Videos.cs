﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bing_Search_API.Model
{
    public class Videos
    {
        public class Instrumentation
        {
            public string pageLoadPingUrl { get; set; }
        }

        public class Publisher
        {
            public string name { get; set; }
        }

        public class Creator
        {
            public string name { get; set; }
        }

        public class Thumbnail
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Value
        {
            public string name { get; set; }
            public string description { get; set; }
            public string webSearchUrl { get; set; }
            public string thumbnailUrl { get; set; }
            public string datePublished { get; set; }
            public List<Publisher> publisher { get; set; }
            public Creator creator { get; set; }
            public string contentUrl { get; set; }
            public string hostPageUrl { get; set; }
            public string encodingFormat { get; set; }
            public string hostPageDisplayUrl { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string duration { get; set; }
            public string motionThumbnailUrl { get; set; }
            public string embedHtml { get; set; }
            public bool allowHttpsEmbed { get; set; }
            public int viewCount { get; set; }
            public Thumbnail thumbnail { get; set; }
            public string videoId { get; set; }
            public bool allowMobileEmbed { get; set; }
        }

        public class Thumbnail2
        {
            public string thumbnailUrl { get; set; }
        }

        public class QueryExpansion
        {
            public string text { get; set; }
            public string displayText { get; set; }
            public string webSearchUrl { get; set; }
            public string searchLink { get; set; }
            public Thumbnail2 thumbnail { get; set; }
        }

        public class Thumbnail3
        {
            public string thumbnailUrl { get; set; }
        }

        public class Suggestion
        {
            public string text { get; set; }
            public string displayText { get; set; }
            public string webSearchUrl { get; set; }
            public string searchLink { get; set; }
            public Thumbnail3 thumbnail { get; set; }
        }

        public class PivotSuggestion
        {
            public string pivot { get; set; }
            public List<Suggestion> suggestions { get; set; }
        }

        public class VideosRootObject
        {
            public string _type { get; set; }
            public Instrumentation instrumentation { get; set; }
            public string readLink { get; set; }
            public string webSearchUrl { get; set; }
            public int totalEstimatedMatches { get; set; }
            public List<Value> value { get; set; }
            public int nextOffsetAddCount { get; set; }
            public List<QueryExpansion> queryExpansions { get; set; }
            public List<PivotSuggestion> pivotSuggestions { get; set; }
        }
    }
}
