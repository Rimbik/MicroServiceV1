using System;

namespace EventSourcing
{
	public enum EventType
	{
		  ItemBlocked = 0
		, OrderCreated
		, PaymentMade
		, OrderFinalized
		, InventoryUpdate
	}

	public class Event
	{
		/*
			Id	Type			ReferenceId		OccuredAt
			---	-----			------------	----------
			1	ItemBlocked		45455			08-05-2020 12:11
			1	OrderCreated	12345			08-05-2020 12:12
			1	PaymentMade		34344			08-05-2020 12:20
			1	OrderFinalized	12345			08-05-2020 12:22
			1	InventoryUpdate	45455			08-05-2020 12:23
		*/

		public int Id { get; set; }
		public EventType Type { get; set; }
		public int ReferenceId { get; set; }
		public DateTime OccuredAt { get; set; }
	}
}