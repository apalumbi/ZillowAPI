using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ZillowAPI;

namespace ZillowForm {
	public class ZillowFormPresenter {
		DataRetriever retriever;

		public ZillowFormPresenter() {
			retriever = new DataRetriever(new ZillowAPI.ZillowAPI());
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
			return new ProFormaBuilder().Output(data);
		}
	}
}
