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

		public DataPoints GetData(Address address) {
			var searchRequest = new SearchRequest {
				ZWSID = ZWSID,
				StreetAddress = address.Street,
				Zip = address.Zip,
			};

			var searchDocument = api.GetDeepSearchResults(searchRequest);

			var data = new DataPoints {
				Address = new Address { 
					ID = GetID(searchDocument),
					Street = address.Street,
					Zip = address.Zip,
				},
				MonthlyRent = GetMonthlyRent(searchDocument),
				SquareFootage = GetFinishedSqFoot(searchDocument),
				Zestimate = GetZestimate(searchDocument),
			};

			var monthlyRequest = new SearchRequest {
				ZWSID = ZWSID,
				StreetAddress = address.Street,
				Zip = address.Zip,
				Price = data.Zestimate,
			};

			var monthlyDocument = api.GetMonthlyPaymentResults(monthlyRequest);

			data.MonthlyTaxes = GetMonthlyTaxes(monthlyDocument);
			data.MonthlyInsurance = GetMonthlyInsurance(monthlyDocument);
			return data;
		}

		private string GetID(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("zpid").FirstOrDefault().Value;
		}


		public string GetFinishedSqFoot(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("finishedSqFt").FirstOrDefault().Value;
		}

		public string GetZestimate(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("zestimate")
								 .Descendants("amount").FirstOrDefault().Value;
		}

		public string GetMonthlyInsurance(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("monthlyHazardInsurance").FirstOrDefault().Value;
		}

		public string GetMonthlyTaxes(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("monthlyPropertyTaxes").FirstOrDefault().Value;
		}

		public string GetMonthlyRent(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("rentzestimate")
								 .Descendants("amount").FirstOrDefault().Value;
		}
	}
}
