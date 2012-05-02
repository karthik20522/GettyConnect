﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace gibsonSearchService
{
    public class ServiceOperations
    {
        public GetImageDetailsResponse GetImageDetail(GetImageDetailsRequestBody searchBody, string token)
        {
            var requestHeader = new RequestHeader();
            requestHeader.Token = token ?? string.Empty;

            var requestBody = new { RequestHeader = requestHeader, GetImageDetailsRequestBody = searchBody };
            var postData = JsonConvert.SerializeObject(requestBody);

            var responseBody = PostData("http://gibson.gettyimages.com/Public/Json/1.0/GetImageDetails", postData);
            return JsonConvert.DeserializeObject<GetImageDetailsResponse>(responseBody);
        }

        public GetEventResultResponse GetEventInfo(GetEventsRequestBody searchBody, string token)
        {
            var requestHeader = new RequestHeader();
            requestHeader.Token = token ?? string.Empty;

            var requestBody = new { RequestHeader = requestHeader, GetEventsRequestBody = searchBody };
            var postData = JsonConvert.SerializeObject(requestBody);

            var responseBody = PostData("http://gibson.gettyimages.com/Public/Json/1.0/GetEvents", postData);
            return JsonConvert.DeserializeObject<GetEventResultResponse>(responseBody);
        }

        public SearchImageResponse SearchImages(SearchForImages2RequestBody searchBody, string token)
        {
            var requestHeader = new RequestHeader();
            requestHeader.Token = token ?? string.Empty;

            var requestBody = new { RequestHeader = requestHeader, SearchForImages2RequestBody = searchBody };
            var postData = JsonConvert.SerializeObject(requestBody);

            var responseBody = PostData("http://gibson.gettyimages.com/Public/Json/1.0/SearchForImages2", postData);
            return JsonConvert.DeserializeObject<SearchImageResponse>(responseBody);
        }

        public Response CreateSession(string systemId = "9999", string systemPassword = "systemPassword12345678==", 
            string userId = "qaterms", string userPassword = "Pa55word")
        {
            var requestHeader = new RequestHeader();
            var sessionTokenRequest = new SessionTokenRequest();
            sessionTokenRequest.SystemId = systemId;
            sessionTokenRequest.SystemPassword = systemPassword;
            sessionTokenRequest.UserId = userId;
            sessionTokenRequest.UserPassword = userPassword;

            var requestBody = new { RequestHeader = requestHeader, SessionTokenRequest = sessionTokenRequest };
            var postData = JsonConvert.SerializeObject(requestBody);

            var responseBody = PostData("https://gibson.gettyimages.com/Session/Json/2.0/CreateSession", postData);

            return JsonConvert.DeserializeObject<Response>(responseBody);
        }

        public Response RenewSession(string token, string coordinationId, string systemId = "9999", string systemPassword = "systemPassword12345678==")
        {
            var requestHeader = new RequestHeader();
            requestHeader.CoordinationId = coordinationId ?? string.Empty;
            requestHeader.Token = token ?? string.Empty;

            var renewSession = new RenewSessionToken();
            renewSession.SystemId = systemId ?? string.Empty;
            renewSession.SystemPassword = systemPassword ?? string.Empty;

            var requestBody = new { RequestHeader = requestHeader, RenewSessionToken = renewSession };
            var postData = JsonConvert.SerializeObject(requestBody);

            var responseBody = PostData("https://gibson.gettyimages.com/Session/Json/2.0/RenewSession", postData);

            return JsonConvert.DeserializeObject<Response>(responseBody);
        }

        private string PostData(string uri, string postData)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(uri); request.KeepAlive = false;
            request.Method = "POST";
            
            byte[] postBytes = Encoding.ASCII.GetBytes(postData);

            request.ContentType = "application/json";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();
            
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
