using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ZillowAPI;
using System.IO;

namespace ZillowForm {
	public class ZillowFormPresenter {
		DataRetriever retriever;
		IRepository repository;

		public ZillowFormPresenter() : this(new ZillowAPI.ZillowAPI(), new AddressRepository()) {}

		public ZillowFormPresenter(IZillowAPI api, IRepository repository) {
			retriever = new DataRetriever(api);
			this.repository = repository;
		}

		public bool	IsAddressValid(string address) {
			if (String.IsNullOrEmpty(address) ||
					!address.Contains(",") ||
					!EndsWithZip(address)) {
				return false;
			}

			return true;
		}

		private bool EndsWithZip(string address) {
			var zip = address.Substring(address.Length - 5, 5).Trim();
			return Regex.IsMatch(zip, "[0-9]+");
		}

		public string Search(Address address) {
			var data = retriever.GetData(address);
			repository.Save(data.Address);
			return new ProFormaBuilder().Output(data);
		}
		
		public string[] LoadAddresses() {
			return repository.FindAll().Select(a => a.AddressString).ToArray();
		}
	}
}
