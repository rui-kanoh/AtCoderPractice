using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			Question.Exec();
		}
	}

	public static class Question
	{
		public static void Exec()
		{
			int n = int.Parse(Console.ReadLine());
			List<int> tlist = new List<int>();
			for (var i = 0; i < n; ++i) {
				tlist.Add(int.Parse(Console.ReadLine()));
			}

			int min = int.MaxValue;
			int total = 0;

			for (var i = 0; i < n; ++i) {
				total += tlist[i];
			}

			for (var i = 0; i < n; ++i) {
				int yaki1 = 0;
				int yaki2 = 0;

				yaki1 = tlist[i];
				yaki2 = total - yaki1;

				int yaki = Math.Max(yaki1, yaki2);
				//Console.WriteLine($"{yaki1} {yaki2}");
				min = Math.Min(yaki, min);
			}

			if (n > 2) {
				for (var i = 1; i < n; ++i) {
					int yaki1 = 0;
					int yaki2 = 0;

					yaki1 = tlist[0] + tlist[i];
					yaki2 = total - yaki1;

					int yaki = Math.Max(yaki1, yaki2);
					//Console.WriteLine($"{yaki1} {yaki2}");
					min = Math.Min(yaki, min);
				}
			}

			if (n > 3) {
				int yaki2 = tlist[n - 1];
				int yaki1 = total - yaki2;

				int yaki = Math.Max(yaki1, yaki2);
				//Console.WriteLine($"{yaki1} {yaki2}");
				min = Math.Min(yaki, min);
			}


			int answer = min;

			Console.WriteLine($"{answer}");
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

			long ln = long.Parse(Console.ReadLine());
			long n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);

			Console.Out.Flush();

			Console.ReadKey();
		}
	}
}

