using System;
using System.Collections.Generic;
using System.IO;
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
		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static void Exec()
		{
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long n = array[0];
			long x = array[1];
			var a = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var totals = new long[n - 1];
			for (int i = 0; i < n - 1; ++i) {
				totals[i] = a[i] + a[i + 1];
			}

			long count = 0;
			if (a[0] > x) {
				long diff = a[0] - x;
				count += diff;
				a[0] -= diff;
				totals[0] -= diff;
			}

			for (int i = 0; i < n - 1; ++i) {
				if (totals[i] > x) {
					long diff = totals[i] - x;
					count += diff;

					if (i < n - 2) {
						totals[i + 1] -= diff;
					}
				}
			}

			Console.WriteLine($"{count}");
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

		public static long Gcd(long a, long b)
		{
			if (b == 0)
			{
				return a;
			}

			return Gcd(b, a % b);
		}

		public static long Lcm(long a, long b)
		{
			long g = Gcd(a, b);
			return a / g * b;
		}
	}
}

