using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectSearchService
{
    public class GetEventsRequestBody
    {
        public List<int> EventIds { get; set; }
        public string EventSortType { get; set; }
    }
}
