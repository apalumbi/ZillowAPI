using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ZillowForm;
using ZillowAPI;
using Rhino.Mocks;
using System.Xml.Linq;

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

		[Test]
		public void Search_UsesReturnedAddressToSave() {
			var api = MockRepository.GenerateMock<IZillowAPI>();
			var repo = MockRepository.GenerateMock<IRepository>();

			api.Stub(a => a.GetDeepSearchResults(null)).IgnoreArguments().Return(XDocument.Load("DeepSearchResult.xml"));
			api.Stub(a => a.GetMonthlyPaymentResults(null)).IgnoreArguments().Return(XDocument.Load("MonthlyResult.xml"));

			var presenter = new ZillowFormPresenter(api, repo);

			presenter.Search(new Address());
			repo.AssertWasCalled(r => r.Save(Arg<Address>.Matches(a => a.ID == "9872758")));
		}
	}
}
