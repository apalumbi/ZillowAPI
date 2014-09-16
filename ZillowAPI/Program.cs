using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ZillowAPI {
	class Program {
		static void Main(string[] args) {
			var dataRetriever = new DataRetriever(new ZillowAPI());
			var proFormaBuilder = new ProFormaBuilder();

			var keepGoing = true;
			while (keepGoing) {
				Console.WriteLine("Enter Street (i.e.  527 Stanbridge Street):");
				var streetAddress = Uri.EscapeUriString(Console.ReadLine());

				Console.WriteLine("Enter Zip:");
				var zip = Uri.EscapeUriString(Console.ReadLine());

				Console.WriteLine(proFormaBuilder.Output(dataRetriever.GetData(new Address { Zip = zip, Street = streetAddress })));

				Console.WriteLine("Search Another (Y/N):");
				var answer = Console.ReadLine();
				keepGoing = answer.ToLowerInvariant().StartsWith("y");
			}
		}
	}
}
