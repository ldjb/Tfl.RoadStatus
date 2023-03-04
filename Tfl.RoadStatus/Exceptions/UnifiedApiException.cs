using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfl.RoadStatus.Exceptions
{
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
