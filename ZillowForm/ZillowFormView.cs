using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZillowAPI;

namespace ZillowForm {
	public partial class ZillowFormView : Form {
		string addressFile = "Address.txt";
		ZillowFormPresenter presenter;

		public ZillowFormView() {
			InitializeComponent();

			presenter = new ZillowFormPresenter();

			if (!File.Exists(addressFile)) {
				File.Create(addressFile);
			}

			var adresses = File.ReadAllLines(addressFile).Select(l => new Address(l));
			streetComboBox.Items.AddRange(adresses.Select(a => a.AddressString).ToArray());

		}

		private void searchButton_Click(object sender, EventArgs e) {
			if (!presenter.IsAddressValid(streetComboBox.SelectedItem.ToString())) {
				MessageBox.Show("Please enter a valid Address");
			}
			else {
				resultsBox.Text = presenter.Search(new Address(streetComboBox.SelectedItem.ToString()));
			}
		}

	}
}
