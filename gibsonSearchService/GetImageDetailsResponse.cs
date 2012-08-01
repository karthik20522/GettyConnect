using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectSearchService
{
    public class GetImageDetailsResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public GetImageDetailsResult GetImageDetailsResult { get; set; }
    }

    public class GetImageDetailsResult
    {
        public List<ImageDetailExt> Images { get; set; }
    }

    public class ImageDetailExt : Image
    {
        public string ArtistTitle { get; set; }
        public string City { get; set; }
        public string Copyright { get; set; }
        public string Country { get; set; }
        public string CreditLine { get; set; }
        public string ReleaseMessage { get; set; }
        public List<string> Restrictions { get; set; }
        public string StateProvince { get; set; }
        public List<SizesDownloadableImage> SizesDownloadableImages { get; set; }
    }

    public class SizesDownloadableImage
    {
        public int FileSizeInBytes { get; set; }
        public double InchesHeight { get; set; }
        public double InchesWidth { get; set; }
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }
        public int ResolutionDpi { get; set; }
        public string SizeKey { get; set; }
    }
}
