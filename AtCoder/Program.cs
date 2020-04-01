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
			long n = int.Parse(Console.ReadLine());
			string answer = "No";
			List<string> list = new List<string>();

			for (var i = 0; i < n; ++i) {
				list.Add(Console.ReadLine());
			}

			for (var i = 0; i < n; ++i) {
				if (i > 0 && list[i - 1][list[i - 1].Length - 1] != list[i][0]) {
					Console.WriteLine("No");
					Console.ReadLine();
					return;
				}

				for (var j = 0; j < i; ++j) {
					if (list[j] == list[i]) {
						Console.WriteLine("No");
						Console.ReadLine();
						return;
					}
				}

				if (i == n - 1) {
					answer = "Yes";
					Console.WriteLine($"{answer}");
				}
			}

			Console.ReadLine();
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

