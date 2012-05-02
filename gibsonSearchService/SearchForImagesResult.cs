using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gibsonSearchService
{

    public class SearchImageResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public SearchForImagesResult SearchForImagesResult { get; set; }
    }

    public class SearchForImagesResult
    {
        public List<Image> Images { get; set; }
        public int ItemCount { get; set; }
        public int ItemStartNumber { get; set; }
        public int ItemTotalCount { get; set; }
        public List<RefinementOption> RefinementOptions { get; set; }
    }

    public class RefinementOption
    {
        public string Category { get; set; }
        public string Id { get; set; }
        public int ImageCount { get; set; }
        public string Text { get; set; }
    }

    public class Image
    {
        public List<string> ApplicableProductOfferings { get; set; }
        public string Artist { get; set; }
        public List<string> AuthorizationConstraints { get; set; }
        public string Caption { get; set; }
        public string CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string ColorType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateSubmitted { get; set; }
        public List<string> EditorialSegments { get; set; }
        public string EditorialSourceId { get; set; }
        public string EditorialSourceName { get; set; }
        public List<int> EventIds { get; set; }
        public string GraphicStyle { get; set; }
        public string ImageFamily { get; set; }
        public string ImageId { get; set; }
        public List<Keyword> Keywords { get; set; }
        public string LicensingModel { get; set; }
        public List<string> Orientations { get; set; }
        public string Title { get; set; }
        public string UrlComp { get; set; }
        public string UrlPreview { get; set; }
        public string UrlThumb { get; set; }
        public string UrlWatermarkComp { get; set; }
        public string UrlWatermarkPreview { get; set; }       
    }

    public class Keyword
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
