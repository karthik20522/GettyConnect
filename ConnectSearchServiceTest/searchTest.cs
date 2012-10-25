using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectSearchService;
using System.IO;

namespace gibsonSearchServiceTest
{
    [TestClass]
    public class searchTest
    {
        ServiceOperations operations;

        [TestInitialize]
        public void Init()
        {
            operations = new ServiceOperations();
        }

        [TestMethod]
        public void CreateSession_Test()
        {
            var session = operations.CreateSession();

            Assert.IsTrue(session != null);
            Assert.IsTrue(session.ResponseHeader.Status.Equals("success"));
            Assert.IsTrue(!string.IsNullOrEmpty(session.TokenResponse.Token));
        }

        [TestMethod]
        public void RenewSession_Test()
        {
            var session = operations.CreateSession();
            
            var renewSession = operations.RenewSession(session.TokenResponse.SecureToken, session.ResponseHeader.CoordinationId);

            Assert.IsTrue(renewSession != null);
            Assert.IsTrue(renewSession.ResponseHeader.Status.Equals("success"));
            Assert.IsTrue(!string.IsNullOrEmpty(renewSession.TokenResponse.Token));
            Assert.IsTrue(!session.TokenResponse.Token.Equals(renewSession.TokenResponse.Token));
        }
        
        [TestMethod]
        public void SearchImages_Test()
        {
            var session = operations.CreateSession();

            var searchQuery = new SearchForImages2RequestBody();
            searchQuery.Filter = new Filter();
            searchQuery.Filter.Orientations = new List<string> { "Vertical" };                        
            searchQuery.Query = new Query();
            searchQuery.Query.SpecificPersons = new List<string> { "Jennifer Lopez" };
            searchQuery.ResultOptions = new ResultOptions();
            searchQuery.ResultOptions.ItemCount = 75;

            var searchResponse = operations.SearchImages(searchQuery, session.TokenResponse.Token);

            Assert.IsTrue(searchResponse != null && searchResponse.ResponseHeader.Status.Equals("success"));
            Assert.IsTrue(searchResponse.SearchForImagesResult.Images.Count == 75);
        }

        [TestMethod]
        public void ImageDetail_Test()
        {
            var session = operations.CreateSession();

            var searchQuery = new SearchForImages2RequestBody();
            searchQuery.Query = new Query();
            searchQuery.Query.SpecificPersons = new List<string> { "Jennifer Lopez" };
            searchQuery.ResultOptions = new ResultOptions();
            searchQuery.ResultOptions.ItemCount = 5;

            var searchResponse = operations.SearchImages(searchQuery, session.TokenResponse.Token);

            var imageIds = searchResponse.SearchForImagesResult.Images.Select(s => s.ImageId).ToList();

            var imageDetailRequest = new GetImageDetailsRequestBody();
            imageDetailRequest.ImageIds = imageIds;

            var imgDetailSrchResponse = operations.GetImageDetail(imageDetailRequest, session.TokenResponse.Token);

            Assert.IsTrue(imgDetailSrchResponse != null && imgDetailSrchResponse.ResponseHeader.Status.Equals("success"));
            Assert.IsTrue(imgDetailSrchResponse.GetImageDetailsResult.Images.Count == 5);
        }

        [TestMethod]
        public void GetEvent_Test()
        {
            var session = operations.CreateSession();

            var searchQuery = new SearchForImages2RequestBody();
            searchQuery.Filter = new Filter();
            searchQuery.Query = new Query();
            searchQuery.Query.SpecificPersons = new List<string> { "Jennifer Lopez" };
            searchQuery.ResultOptions = new ResultOptions();
            searchQuery.ResultOptions.ItemCount = 75;

            var searchResponse = operations.SearchImages(searchQuery, session.TokenResponse.Token);
            var eventId = searchResponse.SearchForImagesResult.Images.Where(s => s.EventIds != null && s.EventIds.Count > 0).First().EventIds.First();

            var geteventRequest = new GetEventsRequestBody();
            geteventRequest.EventIds = new List<int>() { eventId };

            var eventResponse = operations.GetEventInfo(geteventRequest, session.TokenResponse.Token);

            Assert.IsTrue(eventResponse != null && eventResponse.ResponseHeader.Status.Equals("success"));
            Assert.IsTrue(eventResponse.GetEventsResult.Events.First().EventId == eventId);
            Assert.IsTrue(!string.IsNullOrEmpty(eventResponse.GetEventsResult.Events.First().EventName));
        }
    }
}
