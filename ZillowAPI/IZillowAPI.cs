using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ZillowAPI {
	public interface IZillowAPI {
		XDocument GetDeepSearchResults(SearchRequest request);
		XDocument GetMonthlyPaymentResults(SearchRequest request);
	}

	public class ZillowAPI : IZillowAPI {
		static string GetDeepSearchResultUrl = "http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id={0}&address={1}&citystatezip={2}&rentzestimate=true";
		static string GetSearchResultsUrl = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id={0}&address={1}&citystatezip={2}";
		static string GetZestimateUrl = "http://www.zillow.com/webservice/GetZestimate.htm?zws-id={0}&zpid={1}&rentzestimate=true";
		static string GetMonthlyPaymentUrl = "http://www.zillow.com/webservice/GetMonthlyPayments.htm?zws-id={0}&price={1}&zip={2}";

		public XDocument GetDeepSearchResults(SearchRequest request) {
			var url = string.Format(GetDeepSearchResultUrl, request.ZWSID, request.StreetAddress, request.Zip);
			return RunQuery(url);
		}

		private static XDocument RunQuery(string searchUrl) {
			return XDocument.Load(searchUrl);
		}
		
		public XDocument GetMonthlyPaymentResults(SearchRequest request) {
			var url = string.Format(GetMonthlyPaymentUrl, request.ZWSID, request.Price, request.Zip);
			return RunQuery(url);
		}
	}
}
