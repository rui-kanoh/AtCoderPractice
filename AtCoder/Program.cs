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
			int total = tlist.Sum();

			for (var i = 0; i < (1 << n); ++i) {
				int time = 0;
				for (var j = 0; j < n; ++j) {
					if (((1 << j) & i) != 0) {
						time += tlist[j];
					}
				}

				int yaki = Math.Max(time, total - time);
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

