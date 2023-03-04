namespace Tfl.RoadStatus
{
	/// <summary>
	/// Constants used across the project.
	/// </summary>
	class Constants
	{
		public const string UnifiedApiRoadQueryUrl
			= "https://api.tfl.gov.uk/Road/{0}?app_key={1}";

		public const string ProvideRoadIdMessage
			= "Please provide the road ID as an argument.";

		public const string NotAValidRoadMessage
			= "{0} is not a valid road";

		public const string UnifiedApiErrorMessage
			= @"There was a problem retrieving this information.
Check that you've entered your Unified API key in appsettings.json.";

		public const string RoadInfoMessage
			= @"The status of the {0} is as follows
    Road Status is {1}
    Road Status Description is {2}";

		public enum StatusCode
		{
			Success = 0,
			RoadNotFound = 1,
			NoArgumentsProvided = 2,
			UnifiedApiError = 3
		}
	}
}
