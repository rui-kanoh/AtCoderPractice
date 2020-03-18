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
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var dp = new long[n];
			dp[0] = 0;
			dp[1] = Math.Abs(array[1] - array[0]);
			for (int i = 2; i < n; ++i) {
				dp[i] = Math.Min(
					dp[i - 1] + Math.Abs(array[i] - array[i - 1]),
					dp[i - 2] + Math.Abs(array[i] - array[i - 2]));
			}

			Console.WriteLine($"{dp[n - 1]}");

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

