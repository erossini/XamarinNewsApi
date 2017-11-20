using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.Models.Responses;
using Refit;

namespace News.Interfaces
{
    /// <summary>
    /// News API.
    /// </summary>
    public interface INewsApi
    {
        /// <summary>
        /// Gets the news.
        /// </summary>
        /// <returns>The news.</returns>
        /// <param name="source">Source.</param>
        /// <param name="apikey">Apikey.</param>
        [Get("/v2/top-headlines?sources={source}&apiKey={apikey}")]
        Task<NewsResponse> GetNews(string source, string apikey);
    }
}