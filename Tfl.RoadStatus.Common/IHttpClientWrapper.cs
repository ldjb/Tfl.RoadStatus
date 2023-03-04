namespace Tfl.RoadStatus.Common
{
	/// <summary>
	/// An interface for an <see cref="HttpClientWrapper"/>.
	/// </summary>
	public interface IHttpClientWrapper
	{
		/// <summary>
		/// Send a GET request to the specified Uri as an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">The Uri the request is sent to.</param>
		/// <returns>The task object representing the asynchronous operation.</returns>
		Task<HttpResponseMessage> GetAsync(string requestUri);
	}
}