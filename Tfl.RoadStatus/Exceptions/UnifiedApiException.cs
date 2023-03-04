namespace Tfl.RoadStatus.Exceptions
{
	/// <summary>
	/// Exception thrown when the Unified API returns an unsuccessful response.
	/// For example, where an invalid app_key is provided.
	/// </summary>
	[Serializable]
	public class UnifiedApiException : Exception
	{
		public UnifiedApiException() { }

		public UnifiedApiException(string message)
			: base(message) { }

		public UnifiedApiException(string message, Exception inner)
			: base(message, inner) { }
	}
}
