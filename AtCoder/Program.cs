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
		public static void Exec()
		{
			int n = int.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int total = 0;
			foreach (var item in array) {
				total += item;
			}

			if (total % n != 0) {
				Console.WriteLine($"{-1}");
				Console.ReadKey();
				return;
			}

			int average = total / n;

			int count = 0;
			int left = 0;
			int answer = 0;
			for (int i = 0; i < n - 1; ++i) {
				left += array[i];
				++count;

				if (left % count != 0 || left / count != average) {
					if (i != n - 1) {
						++answer;
					}
				} else {
					left = 0;
					count = 0;
				}
			}

			Console.WriteLine($"{answer}");

			Console.ReadKey();
		}
	}
}

namespace Temp {
	public class Question
	{
		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static void Exec()
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

