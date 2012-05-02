using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gibsonSearchService
{
    /// <summary>
    /// CountryCode: Accepts three letter country codes as defined in ISO3166-1(http://en.wikipedia.org/wiki/ISO_3166-1_alpha-3#Current_codes)
    /// Language : Specify an IETF RFC 5646 compliant language tag. Defaults to "en­‐US" if no value provided
    /// </summary>
    public class SearchForImages2RequestBody
    {   
        public string CountryCode { get; set; }        
        public string Language { get; set; }
        public Filter Filter { get; set; }
        public Query Query { get; set; }
        public ResultOptions ResultOptions { get; set; }

        public SearchForImages2RequestBody()
        {
            this.CountryCode = "USA";
            this.Language = "en-US";
        }
    }

    public class ResultOptions
    {
        public bool IncludeKeywords { get; set; }
        public int ItemCount { get; set; }
        public int ItemStartNumber { get; set; }
        public string RefinementOptionSet { get; set; }
    }

    public class Query
    {
        public DateCreatedRange DateCreatedRange { get; set; }
        public int EventId { get; set; }
        public string SearchPhrase { get; set; }
        public List<string> KeywordIds { get; set; }
        public List<string> SpecificPersons { get; set; }

        public Query()
        {
            this.DateCreatedRange = new DateCreatedRange();
        }
    }

    public class DateCreatedRange
    {
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
    }

    /// <summary>
    /// EditorialSegments: Possible values are: news, sports, entertainment, publicity, royalty, archival
    /// File Types: Possible values are: eps, jpg
    /// GraphicStyles: Possible values are: photography, illustration
    /// ImageFamilies: Possible values are: creative, editorial
    /// LicensingModels: Possible values are: royaltyfree, rightsmanaged
    /// Orientations: Possible values are: horizontal, vertical, panoramichorizontal, panoramicvertical, square
    /// ProductOfferings: Possible values are: premiumaccess, editorialsubscription
    /// </summary>
    public class Filter
    {
        public Collections Collections { get; set; }
        public List<string> EditorialSegments { get; set; }
        public EditorialSources EditorialSources { get; set; }
        public List<string> FileTypes { get; set; }
        public List<string> GraphicStyles { get; set; }
        public List<string> ImageFamilies { get; set; }
        public List<string> LicensingModels { get; set; }
        public List<string> Orientations { get; set; }
        public List<string> ProductOfferings { get; set; }
        public List<Refinement> Refinements { get; set; }

        public Filter()
        {
            this.FileTypes = new List<string> { "jpg" };
        }
    }

    public class Refinement
    {
        public string Category { get; set; }
        public string Id { get; set; }
    }

    public class Collections
    {
        public List<string> Ids { get; set; }
        public string Mode { get; set; }
    }

    public class EditorialSources
    {
        public List<string> Ids { get; set; }
        public string Mode { get; set; }
    }
}
