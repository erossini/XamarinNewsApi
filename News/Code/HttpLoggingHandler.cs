using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace News.Code
{
	/// <summary>
	/// Http logging handler.
	/// </summary>
	public class HttpLoggingHandler : DelegatingHandler
	{
		public HttpLoggingHandler(HttpMessageHandler innerHandler = null)
			: base(innerHandler ?? new HttpClientHandler())
		{ }

		/// <summary>
		/// Sends the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="request">Request.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var req = request;
			var id = Guid.NewGuid().ToString();
			var msg = $"[{id} -   Request]";

            Debug.WriteLine($"{msg}========Start==========");
			Debug.WriteLine($"{msg} {req.Method} {req.RequestUri.PathAndQuery} {req.RequestUri.Scheme}/{req.Version}");
			Debug.WriteLine($"{msg} Host: {req.RequestUri.Scheme}://{req.RequestUri.Host}");

			foreach (var header in req.Headers)
				Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

			if (req.Content != null)
			{
				foreach (var header in req.Content.Headers)
					Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

				if (req.Content is StringContent || this.IsTextBasedContentType(req.Headers) || this.IsTextBasedContentType(req.Content.Headers))
				{
					var result = await req.Content.ReadAsStringAsync();

					Debug.WriteLine($"{msg} Content:");
					Debug.WriteLine($"{msg} {string.Join("", result.Cast<char>().Take(255))}...");
				}
			}

			var start = DateTime.Now;

			var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

			var end = DateTime.Now;

			Debug.WriteLine($"{msg} Duration: {end - start}");
			Debug.WriteLine($"{msg}==========End==========");

			msg = $"[{id} - Response]";
			Debug.WriteLine($"{msg}=========Start=========");

			var resp = response;

			Debug.WriteLine($"{msg} {req.RequestUri.Scheme.ToUpper()}/{resp.Version} {(int)resp.StatusCode} {resp.ReasonPhrase}");

			foreach (var header in resp.Headers)
				Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

			if (resp.Content != null)
			{
				foreach (var header in resp.Content.Headers)
					Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

				if (resp.Content is StringContent || this.IsTextBasedContentType(resp.Headers) || this.IsTextBasedContentType(resp.Content.Headers))
				{
					start = DateTime.Now;
					var result = await resp.Content.ReadAsStringAsync();
					end = DateTime.Now;

					Debug.WriteLine($"{msg} Content:");
					Debug.WriteLine($"{msg} {string.Join("", result.Cast<char>().Take(255))}...");
					Debug.WriteLine($"{msg} Duration: {end - start}");
				}
			}

			Debug.WriteLine($"{msg}==========End==========");
			return response;
		}

		readonly string[] types = new[] { "html", "text", "xml", "json", "txt", "x-www-form-urlencoded" };

		/// <summary>
		/// Ises the type of the text based content.
		/// </summary>
		/// <returns><c>true</c>, if text based content type was ised, <c>false</c> otherwise.</returns>
		/// <param name="headers">Headers.</param>
		bool IsTextBasedContentType(HttpHeaders headers)
		{
			IEnumerable<string> values;
			if (!headers.TryGetValues("Content-Type", out values))
				return false;
			var header = string.Join(" ", values).ToLowerInvariant();

			return types.Any(t => header.Contains(t));
		}
	}
}