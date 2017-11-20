using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace News.Models.Responses
{
    /// <summary>
    /// News response.
    /// </summary>
    public class NewsResponse
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the articles.
        /// </summary>
        /// <value>The articles.</value>
        [JsonProperty("articles")]
        public IList<ArticleModel> Articles { get; set; }
    }
}