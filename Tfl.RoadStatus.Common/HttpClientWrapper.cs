namespace Tfl.RoadStatus.Common
{
	/// <summary>
	/// A wrapper for HttpClient.
	/// </summary>
	public class HttpClientWrapper : IHttpClientWrapper
	{
		private readonly HttpClient _httpClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="HttpClientWrapper"/> class
		/// with the specified <see cref="HttpClient"/>.
		/// </summary>
		/// <param name="httpClient">An HTTP client for sending requests.</param>
		public HttpClientWrapper(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		/// <summary>
		/// Send a GET request to the specified Uri as an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">The Uri the request is sent to.</param>
		/// <returns>The task object representing the asynchronous operation.</returns>
		public async Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			return await _httpClient.GetAsync(requestUri);
		}
	}
}
