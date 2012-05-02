using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gibsonSearchService
{
    public class GetEventsRequestBody
    {
        public List<int> EventIds { get; set; }
        public string EventSortType { get; set; }
    }
}
