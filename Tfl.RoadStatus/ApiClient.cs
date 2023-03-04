using System.Net;
using System.Text.Json;
using Tfl.RoadStatus.Common;
using Tfl.RoadStatus.Models;

namespace Tfl.RoadStatus
{
	/// <summary>
	/// Makes requests to the Unified API.
	/// </summary>
	public class ApiClient
	{
		private readonly IHttpClientWrapper _httpClient;

		/// <summary>
		/// Constructs a new ApiClient.
		/// </summary>
		/// <param name="httpClient">Enables the ApiClient to make HTTP requests.</param>
		public ApiClient(IHttpClientWrapper httpClient)
		{
			_httpClient = httpClient;
		}

		/// <summary>
		/// Retrieve a road corridor from the Unified API based on the given ID.
		/// </summary>
		/// <param name="appKey">A Unified API app_key.</param>
		/// <param name="roadId">The ID of a road corridor.</param>
		/// <returns>A road corridor.</returns>
		/// <exception cref="Exceptions.RoadNotFoundException">A road with this ID does not exist.</exception>
		/// <exception cref="Exceptions.UnifiedApiException">The Unified API returned an error.</exception>
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
