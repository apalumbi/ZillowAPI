using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZillowAPI {
	public class ProFormaBuilder {
		string header = "|Square Footage|Rent per Square foot|Monthly Rent|Annual Rent";
		public string Output(DataPoints dataPoints) {
			var sb = new StringBuilder();
			sb.AppendLine(header);
			sb.AppendFormat("|{0}|{1}|{2}|{3}", dataPoints.SquareFootage, dataPoints.RentPerSquareFoot, dataPoints.MonthlyRent, dataPoints.YearlyRent).AppendLine();
			sb.AppendLine();
			sb.AppendFormat("Gross Potential Rent|{0}", dataPoints.YearlyRent).AppendLine();
			sb.AppendFormat("Vacancy|{0}", dataPoints.MonthlyRent).AppendLine();
			sb.AppendFormat("Effective Rental Income|{0}", dataPoints.EffectiveRentalIncome).AppendLine();
			sb.AppendLine();
			sb.AppendLine("Operating Expenses");
			sb.AppendFormat("Real Estate Taxes|{0}", dataPoints.YearlyTaxes).AppendLine();
			sb.AppendFormat("Insurance|{0}", dataPoints.YearlyInsurance).AppendLine();
			return sb.ToString();
		}
	}
}
