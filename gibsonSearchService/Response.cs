using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gibsonSearchService
{
    public class Response
    {
        public ResponseHeader ResponseHeader { get; set; }
        public TokenResponse TokenResponse { get; set; }
    }

    public class ResponseHeader
    {
        public string Status { get; set; }
        public List<Status> StatusList { get; set; }
        public string CoordinationId { get; set; }
    }

    public class TokenResponse
    {
        public string AccountId { get; set; }
        public string SecureToken { get; set; }
        public string Token { get; set; }
        public int TokenDurationMinutes { get; set; }
    }

    public class Status
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
