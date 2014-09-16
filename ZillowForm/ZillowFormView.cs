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
		ZillowFormPresenter presenter;

		public ZillowFormView() {
			InitializeComponent();

			presenter = new ZillowFormPresenter();

			ReloadComboBox();
		}

		private void ReloadComboBox() {
			streetComboBox.Items.Clear();
			streetComboBox.Items.AddRange(presenter.LoadAddresses());
		}

		private void searchButton_Click(object sender, EventArgs e) {
			Search();
		}

		private void Search() {
			exampleLabel.Visible = false;
			if (!presenter.IsAddressValid(streetComboBox.Text)) {
				MessageBox.Show("Please enter a valid Address");
			}
			else {
				resultsBox.Text = presenter.Search(new Address(streetComboBox.Text));
			}
			ReloadComboBox();
			streetComboBox.Select(0, streetComboBox.Text.Length);
		}

		void streetComboBox_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				Search();
			}
		}
	}
}
