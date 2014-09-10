using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZillowAPI {
	public class DataPoints {
		public string SquareFootage { get; set; }
		public string MonthlyRent { get; set; }
		public string Zestimate { get; set; }
		public string MonthlyTaxes { get; set; }
		public string MonthlyInsurance { get; set; }

		public string RentPerSquareFoot {
			get { return (int.Parse(SquareFootage) / int.Parse(MonthlyRent)).ToString(); }
		}

		public string YearlyRent { get { return ToYearly(MonthlyRent); } }
		public string YearlyTaxes { get { return ToYearly(MonthlyTaxes); } }
		public string YearlyInsurance { get { return ToYearly(MonthlyInsurance); } }

		private string ToYearly(string amount) {
			return (int.Parse(amount) * 12).ToString();
		}
		

		public string EffectiveRentalIncome { get { return (int.Parse(YearlyRent) - int.Parse(MonthlyRent)).ToString(); } }
	}
}
