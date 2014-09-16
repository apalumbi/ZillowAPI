using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ZillowAPI {
	public interface IRepository {
		IEnumerable<Address> FindAll();
		void Save(Address address);
	}

	public class AddressRepository : IRepository{
		string addressFile = "Address.txt";

		public AddressRepository() {
			if (!File.Exists(addressFile)) {
				File.Create(addressFile);
			}
		}

		public IEnumerable<Address> FindAll() {
			return File.ReadAllLines(addressFile).Select(l => new Address(l));
		}

		public void Save(Address address) {
			var addresses = FindAll().ToList();
			if (!addresses.Exists(a => a.ID == address.ID)) {
				addresses.Add(address);
			}

			var text = new StringBuilder();
			foreach (var a in addresses) {
				text.AppendLine(a.ToFileString);
			}

			File.WriteAllText(addressFile, text.ToString());
		}
	}
}
