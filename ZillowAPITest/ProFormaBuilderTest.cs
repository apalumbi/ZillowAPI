using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ZillowAPI;

namespace ZillowAPITest {
	[TestFixture]
	public class ProFormaBuilderTest {

		[Test]
		public void Output() {
			var data = new DataPoints { MonthlyRent = "10", SquareFootage = "100", MonthlyTaxes = "20", MonthlyInsurance = "30" };

			Assert.AreEqual(expected, new ProFormaBuilder().Output(data));
		}

		string expected = @"|Square Footage|Rent per Square foot|Monthly Rent|Annual Rent
|100|10|10|120

Gross Potential Rent|120
Vacancy|10
Effective Rental Income|110

Operating Expenses
Real Estate Taxes|240
Insurance|360
";
	}
}
