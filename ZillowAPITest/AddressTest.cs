using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ZillowAPI;

namespace ZillowAPITest {
	[TestFixture]
	public class AddressTest {
		[Test]
		public void Constructor_NoID() {
			var line = "527 Stanbridge Street|19083|";

			var address = new Address(line);

			Assert.AreEqual("19083", address.Zip);
			Assert.AreEqual("527 Stanbridge Street", address.Street);
		}

		[Test]
		public void Constructor_ID() {
			var line = "527 Stanbridge Street|19083|1234";

			var address = new Address(line);

			Assert.AreEqual("19083", address.Zip);
			Assert.AreEqual("527 Stanbridge Street", address.Street);
			Assert.AreEqual("1234", address.ID);
		}

		[Test]
		public void Constructor_Comma() {
			var line = "527 Stanbridge Street,19083";

			var address = new Address(line);

			Assert.AreEqual("19083", address.Zip);
			Assert.AreEqual("527 Stanbridge Street", address.Street);
		}
	}
}
