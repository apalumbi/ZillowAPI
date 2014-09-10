using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ZillowAPI {
	public class XMLParse {
		public string GetZPID(XDocument doc) {
			XElement root = doc.Root;
			return root.Descendants("zpid").FirstOrDefault().Value;
		}
	}
}
