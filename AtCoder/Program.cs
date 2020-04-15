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
		public static long Gcd(long a, long b)
		{
			if (b == 0) {
				return a;
			}

			return Gcd(b, a % b);
		}

		public static long Lcm(long a, long b)
		{
			long g = Gcd(a, b);
			return a / g * b;
		}

		public static void Exec()
		{
			long n = long.Parse(Console.ReadLine());
			var array = new long[n];

			long answer = 1;
			for (var i = 1; i <= n; ++i) {
				long time = long.Parse(Console.ReadLine());
				answer = Lcm(answer, time);
			}

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

		void WrongAnswer()
		{
			var larray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long N = long.Parse(Console.ReadLine());
			long Q = larray[0];
			long H = larray[1];
			long S = larray[2];
			long D = larray[3];
			var dict = new Dictionary<double, long>();
			dict.Add(0.25, Q);
			dict.Add(0.5, H);
			dict.Add(1.0, S);
			dict.Add(2.0, D);

			long answer = 0;

			long min = long.MaxValue;

			if (N > 1) {
				if (N % 2 == 0) {
					answer = (N / 2) * D;
				} else {
					answer = (N / 2) * D + (N % 2) * S;
				}
			} else {
				answer = N * S;
			}

			if (min > answer) {
				min = answer;
			}
		}
	}
}

