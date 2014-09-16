using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZillowAPI {
	public class Address {
		public string ID { get; set; }
		public string Street { get; set; }
		public string Zip { get; set; }

		public Address() { }

		public Address(string line) {

			if (line.Contains("|")) {
				var split = line.Split('|');

				Street = split[0];
				Zip = split[1];
				ID = split[2];
			}
			else {
				var split = line.Split(',');

				Zip = split.Last().Trim();
				Street = split.First().Trim();
			}
		}

		public string AddressString {
			get { return Street + ", " + Zip; }
		}

		public string ToFileString {
			get { return string.Format("{0}|{1}|{2}", Street, Zip, ID); }
		}
	}
}
