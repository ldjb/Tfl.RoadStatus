using Microsoft.Extensions.Configuration;
using Tfl.RoadStatus.Common;
using Tfl.RoadStatus.Exceptions;
using Tfl.RoadStatus.Models;

namespace Tfl.RoadStatus
{
	/// <summary>
	/// The entry point to the program.
	/// </summary>
	class Program
	{
		/// <summary>
		/// This is the first method that is run.
		/// Displays information about a road based on an ID provided as arguments.
		/// </summary>
		/// <param name="args">An array of words which, together, may form a road ID.</param>
		/// <returns>A status code: 0 for success, or other values for errors.</returns>
		static async Task<int> Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
			var appKey = config["AppKey"];

			var apiClient = new ApiClient(new HttpClientWrapper(new HttpClient()));

			if (args.Length == 0)
			{
				Console.Error.WriteLine(Constants.ProvideRoadIdMessage);
				return (int) Constants.StatusCode.NoArgumentsProvided;
			}

			// The road ID may be a single word ("a2"),
			// or multiple words ("bishopsgate cross route").
			// We therefore join all the args into a single string.
			var roadId = string.Join(' ', args);

			RoadCorridor road;
			try
			{
				road = await apiClient.GetRoad(appKey!, roadId);
			}
			catch (RoadNotFoundException)
			{
				Console.Error.WriteLine(string.Format(
					Constants.NotAValidRoadMessage,roadId));
				return (int) Constants.StatusCode.RoadNotFound;
			}
			catch (UnifiedApiException)
			{
				Console.Error.WriteLine(Constants.UnifiedApiErrorMessage);
				return (int) Constants.StatusCode.UnifiedApiError;
			}

			Console.WriteLine(string.Format(Constants.RoadInfoMessage,
				road.DisplayName, road.StatusSeverity, road.StatusSeverityDescription));
			return (int) Constants.StatusCode.Success;
		}
	}
}
