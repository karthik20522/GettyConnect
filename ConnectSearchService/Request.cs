using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectSearchService
{
    public class RequestHeader
    {
        public string Token { get; set; }
        public string CoordinationId { get; set; }
    }

    public class SessionTokenRequest
    {
        public string SystemId { get; set; }
        public string SystemPassword { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool RememberedUser { get; set; }
    }

    public class RenewSessionToken
    {
        public string SystemId { get; set; }
        public string SystemPassword { get; set; }
    }   
}
