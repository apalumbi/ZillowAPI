using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZillowAPI {
	public class SearchRequest {
		public string ZWSID { get; set; }
		public string StreetAddress { get; set; }
		public string Zip { get; set; }
		public string Price { get; set; }
	}
}
