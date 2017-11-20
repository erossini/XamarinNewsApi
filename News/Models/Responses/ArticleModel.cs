using System;
using Newtonsoft.Json;

namespace News.Models.Responses
{
    /// <summary>
    /// Article response.
    /// </summary>
    public class ArticleModel
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
		[JsonProperty("source")]
        public SourceModel Source { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
		[JsonProperty("author")]
		public string Author { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
		[JsonProperty("title")]
		public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
		[JsonProperty("description")]
		public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
		[JsonProperty("url")]
		public string Url { get; set; }

        /// <summary>
        /// Gets or sets the URL to image.
        /// </summary>
        /// <value>The URL to image.</value>
		[JsonProperty("urlToImage")]
		public string UrlToImage { get; set; }

        /// <summary>
        /// Gets or sets the published at.
        /// </summary>
        /// <value>The published at.</value>
		[JsonProperty("publishedAt")]
		public DateTime? PublishedAt { get; set; }

        /// <summary>
        /// Gets the published at text.
        /// </summary>
        /// <value>The published at text.</value>
        [JsonIgnore]
        public string PublishedAtText {
            get {
                if (PublishedAt == null)
                    return "Publish data unknown";
                else
                    return ((DateTime)PublishedAt).ToString("dd/MM/yy @ HH:mm");
            }
        }
	}
}