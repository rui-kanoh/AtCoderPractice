using System;

namespace AtCoderCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = 0;
			int b = 0;
			int c = 0;
			string strData = "";
			string line = Console.ReadLine();
			a = int.Parse(line);

			line = Console.ReadLine();
			string[] strs = line.Split(' ');
			b = int.Parse(strs[0]);
			c = int.Parse(strs[1]);

			strData = Console.ReadLine();

			Console.WriteLine($"{a + b + c} " + strData);
		}
	}
}
