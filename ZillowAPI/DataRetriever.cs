using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ZillowAPI {
	public class DataRetriever {
		static string ZWSID = "X1-ZWz1b5hlrpbuob_2avji";
		readonly IZillowAPI api;

		public DataRetriever(IZillowAPI api) {
			this.api = api;
		}

		public DataPoints GetData(string streetAddress, string zip) {
			var request = new DeepSearchRequest {
				ZWSID = ZWSID,
				StreetAddress = streetAddress,
				Zip = zip,
			};

			var document = api.GetDeepSearchResults(request);

			return new DataPoints {
				MonthlyRent = GetMonthlyRent(document),
				SquareFootage = GetFinishedSqFoot(document),
			};
		}


		public string GetFinishedSqFoot(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("finishedSqFt").FirstOrDefault().Value;
		}

		public string GetMonthlyRent(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("rentzestimate")
								 .Descendants("amount").FirstOrDefault().Value;
		}
	}
}
