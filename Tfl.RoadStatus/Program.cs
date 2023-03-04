using Microsoft.Extensions.Configuration;
using Tfl.RoadStatus.Common;
using Tfl.RoadStatus.Exceptions;
using Tfl.RoadStatus.Models;

namespace Tfl.RoadStatus
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
			var appKey = config["AppKey"];

			var apiClient = new ApiClient(new HttpClientWrapper(new HttpClient()));

			if (args.Length == 0)
			{
				Console.Error.WriteLine("Please provide the road ID as an argument.");
				return 1;
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
				Console.Error.WriteLine($"{roadId} is not a valid road");
				return 1;
			}
			catch (UnifiedApiException)
			{
				Console.Error.WriteLine("There was a problem retrieving this information.");
				Console.Error.WriteLine("Check that you've entered your Unified API key in appsettings.json.");
				return 1;
			}

			Console.WriteLine($"The status of the {road.DisplayName} is as follows");
			Console.WriteLine($"    Road Status is {road.StatusSeverity}");
			Console.WriteLine($"    Road Status Description is {road.StatusSeverityDescription}");
			return 0;
		}
	}
}
