using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			var Instance = new Question();
			Instance.Exec();
		}
	}

	public class Question
	{
		public void Exec()
		{
			string dirs = Console.ReadLine();
			bool isConnected = false;

			int ncount = 0;
			int scount = 0;
			int wcount = 0;
			int ecount = 0;
			for (int i = 0; i < dirs.Length; ++i) {
				switch (dirs[i]) {
					case 'N':
					default:
						++ncount;
						break;
					case 'W':
						++wcount;
						break;
					case 'S':
						++scount;
						break;
					case 'E':
						++ecount;
						break;
				}
			}

			if ((scount > 0 && ncount > 0 && ecount > 0 && wcount > 0)
				|| (scount == 0 && ncount == 0 && ecount > 0 && wcount > 0)
				|| (scount > 0 && ncount > 0 && ecount == 0 && wcount == 0)) {
				isConnected = true;
			}

			string str = isConnected ? "Yes" : "No";
			Console.WriteLine($"{str}");
			Console.ReadKey();
		}
	}
}

namespace Temp {
	public class Question
	{
		public void Exec()
		{
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
			Console.SetOut(sw);

			string s = Console.ReadLine();

			long n = long.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var inputLongArray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);

			Console.Out.Flush();

			Console.ReadKey();
		}
	}
}

