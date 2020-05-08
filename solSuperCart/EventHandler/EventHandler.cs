using System;
using System.Collections.Generic;

namespace EventSourcing
{
	public static class EventHandler
	{
		static EventHandler()
		{
		}

		public static List<Event> Events = new List<Event>();
	}
}
