using System;
using System.Collections.Generic;

namespace Checkout.Events
{
    public sealed class EventsPageResponse
    {
        public int? TotalCount { get; set; }

        public int? Limit { get; set; }

        public int? Skip { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public IList<EventSummaryResponse> Data { get; set; }
    }
}