namespace Tfl.RoadStatus.Common
{
	public interface IHttpClientWrapper
	{
		Task<HttpResponseMessage> GetAsync(string requestUri);
	}
}