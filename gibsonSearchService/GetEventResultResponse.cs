using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectSearchService
{
    public class GetEventResultResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public GetEventsResult GetEventsResult { get; set; }
    }

    public class GetEventsResult
    {
        public List<Event> Events { get; set; }
    }

    public class Event
    {
        public string Description { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int ImageCount { get; set; }
        public string RepresentativeImageId { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
    }
}
