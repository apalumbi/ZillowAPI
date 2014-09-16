using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using ZillowAPI;
using System.Xml.Linq;
using Rhino.Mocks;

namespace ZillowAPITest {
	[TestFixture]
	public class DataRetrieverTest {
		
		[Test]
		public void GetDataPoints() {
			var api = MockRepository.GenerateMock<IZillowAPI>();
			api.Stub(a => a.GetDeepSearchResults(null)).IgnoreArguments().Return(XDocument.Load("DeepSearchResult.xml"));
			api.Stub(a => a.GetMonthlyPaymentResults(null)).IgnoreArguments().Return(XDocument.Load("MonthlyResult.xml"));
			
			var data = new DataRetriever(api).GetData(new Address());
			Assert.AreEqual("2064", data.SquareFootage);
			Assert.AreEqual("1444", data.MonthlyRent);
			Assert.AreEqual("57", data.MonthlyInsurance);
			Assert.AreEqual("292", data.MonthlyTaxes);
			Assert.AreEqual("152379", data.Zestimate);
		}
	}
}
