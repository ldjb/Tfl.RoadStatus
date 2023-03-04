using System.Net;
using System.Text.Json;
using Tfl.RoadStatus.Common;
using Tfl.RoadStatus.Models;

namespace Tfl.RoadStatus
{
	public class ApiClient
	{
		private readonly IHttpClientWrapper _httpClient;

		public ApiClient(IHttpClientWrapper httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<RoadCorridor> GetRoad(string appKey, string roadId)
		{
			var response = await _httpClient.GetAsync(
				string.Format(Constants.UnifiedApiRoadQueryUrl, roadId, appKey));

			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw new Exceptions.RoadNotFoundException();
			}
			if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new Exceptions.UnifiedApiException();
			}

			var stream = response.Content.ReadAsStream();
			var roadCorridors = JsonSerializer.Deserialize<IEnumerable<RoadCorridor>>(stream);
			return roadCorridors!.Single();
		}
	}
}
