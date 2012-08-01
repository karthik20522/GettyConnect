using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectSearchService
{
    public class GetImageDetailsRequestBody
    {
        public string CountryCode { get; set; }
        public List<string> ImageIds { get; set; }
        public string Language { get; set; }

        public GetImageDetailsRequestBody()
        {
            this.CountryCode = "USA";
            this.Language = "en-us";
        }
    }
}
