GettyConnect
============

GettyImages Connect API - Gibson Service [http://gibson.gettyimages.com/Public/help]

Examples: (please review the test cases for how to)

1) To Create a new session to access the service

	 var session = operations.CreateSession();

2) To renew the session

	var session = operations.CreateSession();
            
	var renewSession = operations.RenewSession(session.TokenResponse.SecureToken,session.ResponseHeader.CoordinationId);

3) Search Images using GettyConnect API

            var session = operations.CreateSession();

            var searchQuery = new SearchForImages2RequestBody();
            searchQuery.Filter = new Filter();
            searchQuery.Filter.Orientations = new List<string> { "Vertical" };
            searchQuery.Query = new Query();
            searchQuery.Query.SpecificPersons = new List<string> { "Jennifer Lopez" };
            searchQuery.ResultOptions = new ResultOptions();
            searchQuery.ResultOptions.ItemCount = 75;

            var searchResponse = operations.SearchImages(searchQuery, session.TokenResponse.Token);

4) Get Image detail

            var imageDetailRequest = new GetImageDetailsRequestBody();
            imageDetailRequest.ImageIds = imageIds;

            var imgDetailSrchResponse = operations.GetImageDetail(imageDetailRequest, session.TokenResponse.Token);


5) Get Event detail

            var geteventRequest = new GetEventsRequestBody();
            geteventRequest.EventIds = new List<int>() { eventId };

            var eventResponse = operations.GetEventInfo(geteventRequest, session.TokenResponse.Token);