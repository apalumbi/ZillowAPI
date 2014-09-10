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
		public void GetFinishedSqFoot() {
			var xml = XDocument.Load("DeepSearchResult.xml");
			
			var api = MockRepository.GenerateMock<IZillowAPI>();
			api.Stub(a => a.GetDeepSearchResults(new DeepSearchRequest())).IgnoreArguments().Return(xml);
			
			var data = new DataRetriever(api).GetData("", "");
			Assert.AreEqual("2064", data.SquareFootage);
			Assert.AreEqual("1444", data.MonthlyRent);
		}
	}
}
