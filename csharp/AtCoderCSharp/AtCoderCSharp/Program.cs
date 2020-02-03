using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AtCoderCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> intDataList = new List<int>();
			string strData;
			for (int i = 0; i < 2; ++i) {
				string line = Console.ReadLine();
				string[] strs = line.Split(' ');
				foreach (var str in strs) {
					int data = int.Parse(str);
					intDataList.Add(data);
				}
			}

			{
				string line = Console.ReadLine();
				strData = line;
			}

			Console.WriteLine($"{intDataList.Sum()} " + strData);
		}
	}
}
