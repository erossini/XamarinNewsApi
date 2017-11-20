using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace News.Models.Responses
{
    public class SourceResponse
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
        [JsonProperty("sources")]
        public IList<SourceModel> Sources { get; set; }
    }
}