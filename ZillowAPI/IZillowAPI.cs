using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ZillowAPI {
	public interface IZillowAPI {
		XDocument GetDeepSearchResults(DeepSearchRequest request);
	}

	public class ZillowAPI : IZillowAPI {
		static string GetDeepSearchResultUrl = "http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id={0}&address={1}&citystatezip={2}&rentzestimate=true";
		static string GetSearchResultsUrl = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id={0}&address={1}&citystatezip={2}";
		static string GetZestimateUrl = "http://www.zillow.com/webservice/GetZestimate.htm?zws-id={0}&zpid={1}&rentzestimate=true";

		public XDocument GetDeepSearchResults(DeepSearchRequest request) {
			var deepSearchUrl = string.Format(GetDeepSearchResultUrl, request.ZWSID, request.StreetAddress, request.Zip);
			return RunQuery(deepSearchUrl);
		}

		private static XDocument RunQuery(string searchUrl) {
			return XDocument.Load(searchUrl);
		}
	}
}
