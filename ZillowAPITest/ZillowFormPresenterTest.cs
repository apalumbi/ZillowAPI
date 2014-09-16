using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ZillowForm;

namespace ZillowAPITest {
	[TestFixture]
	public class ZillowFormPresenterTest {

		[Test]
		public void AddressIsValid() {
			var empty = "";
			var noComma = "17 West GolfView Road 19083";
			var noZip = "1418 Ashton Road";
			var good = "17 West GolfView Road, 19083";

			var presneter = new ZillowFormPresenter();

			Assert.IsTrue(presneter.IsAddressValid(good));
			Assert.IsFalse(presneter.IsAddressValid(empty));
			Assert.IsFalse(presneter.IsAddressValid(noComma));
			Assert.IsFalse(presneter.IsAddressValid(noZip));
		}
	}
}
