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
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			int c = array[1];
			var alist = new List<int>();
			for (var i = 0; i < n; ++i) {
				alist.Add(int.Parse(Console.ReadLine()) - 1);
			}

			int min = int.MaxValue;

			int total = 0;
			for (var i = 0; i < 10; ++i) {
				for (var j = 0; j < 10; ++j) {
					if (i == j) {
						continue;
					}

					total = 0;
					for (var k = 0; k < n; ++k) {
						if (k % 2 == 0 && alist[k] != i) {
							total += c;
						} else if (k % 2 == 1 && alist[k] != j) {
							total += c;
						}
					}

					min = Math.Min(min, total);
				}
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

