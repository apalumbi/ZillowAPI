using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using ZillowAPI;
using System.Xml.Linq;

namespace ZillowAPITest {
	[TestFixture]
	public class XMLParseTest {

		[Test]
		public void GetZPID() {
			var xml = XDocument.Load("GetSearchResults.xml");

			Assert.AreEqual("9369328", new XMLParse().GetZPID(xml));
		}
	}
}
