using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var writer = new StreamWriter(args[1])) {
				List<int> intDataList = new List<int>();
				string strData = "";
				using (var reader = new StreamReader(args[0])) {
					// Redirect standard output from the console to the output file.
					Console.SetOut(writer);
					// Redirect standard input from the console to the input file.
					Console.SetIn(reader);

					for (int i = 0; i < 2; ++i) {
						string line = Console.ReadLine();
						string[] strs = line.Split(' ');
						foreach (var str in strs) {
							int data = int.Parse(str);
							intDataList.Add(data);
							System.Diagnostics.Trace.WriteLine($"{data}");
						}
					}

					{
						string line = Console.ReadLine();
						System.Diagnostics.Trace.WriteLine(line);
						strData = line;
					}
				}

				writer.WriteLine($"{intDataList.Sum()} " + strData);
			}
		}
	}
}
