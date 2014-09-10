using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ZillowAPI {
	class Program {
		static void Main(string[] args) {
			var ZWSID = "X1-ZWz1b5hlrpbuob_2avji";
			var address = Uri.EscapeUriString("527 Stanbridge Street");
			var zip = Uri.EscapeUriString("19401");
			var GetSearchResultsUrl = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id={0}&address={1}&citystatezip={2}";
			var GetZestimateUrl = "http://www.zillow.com/webservice/GetZestimate.htm?zws-id={0}&zpid={1}&rentzestimate=true";
			var GetDeepSearchResultUrl = "http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id={0}&address={1}&citystatezip={2}&rentzestimate=true";
			//var searchUrl = string.Format(GetSearchResultsUrl, ZWSID, address, zip);
			//var response = RunQuery(searchUrl);
			//var zpid = GetZPID(response);
			
			//var zestimateUrl = string.Format(GetZestimateUrl, ZWSID, zpid);
			//response = RunQuery(zestimateUrl);
						
			var deepSearchUrl = string.Format(GetDeepSearchResultUrl, ZWSID, address, zip);
			var response = RunQuery(deepSearchUrl);

			Console.WriteLine(response.ToString());
			Console.ReadLine();

		}

		private static string GetZPID(XDocument doc) {
			return new XMLParse().GetZPID(doc);
		}

		private static XDocument RunQuery(string searchUrl) {
			return XDocument.Load(searchUrl);
		}
	}
}
