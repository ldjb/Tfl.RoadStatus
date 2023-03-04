namespace Tfl.RoadStatus.Exceptions
{
	/// <summary>
	/// Exception thrown when a road with a given ID does not exist.
	/// </summary>
	[Serializable]
	public class RoadNotFoundException : Exception
	{
		public RoadNotFoundException() { }

		public RoadNotFoundException(string message)
			: base(message) { }

		public RoadNotFoundException(string message, Exception inner)
			: base(message, inner) { }
	}
}
