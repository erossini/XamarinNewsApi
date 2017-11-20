using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using News.Interfaces;
using News.Models.Responses;
using Refit;

namespace News.Code
{
    public class NewsClient
    {
        /// <summary>
        /// Gets the news.
        /// </summary>
        /// <returns>The news.</returns>
        /// <param name="source">Source.</param>
        /// <param name="apikey">Apikey.</param>
        public async Task<NewsResponse> GetNews(string source, string apikey) {
            NewsResponse rtn = new NewsResponse();

            try
            {
                var client = RestService.For<INewsApi>(Constants.UrlNews);
                rtn = await client.GetNews(source, apikey);
            }
            catch (ApiException ax) {
                Debug.WriteLine("Api error: " + ax.Message);
            }
            catch(Exception ex) {
                Debug.WriteLine("Generic error: " + ex.Message);
            }

            return rtn;
        }

        /// <summary>
        /// Gets the sources.
        /// </summary>
        /// <returns>The sources.</returns>
        /// <param name="apikey">Apikey.</param>
        public async Task<SourceResponse> GetSources(string apikey)
        {
            SourceResponse rtn = new SourceResponse();

            try
            {
                var client = RestService.For<INewsApi>(Constants.UrlNews);
                rtn = await client.GetSources(apikey);
            }
            catch (ApiException ax)
            {
                Debug.WriteLine("Api error: " + ax.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Generic error: " + ex.Message);
            }

            return rtn;
        }
    }
}