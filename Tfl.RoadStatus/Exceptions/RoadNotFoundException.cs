using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfl.RoadStatus.Exceptions
{
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
