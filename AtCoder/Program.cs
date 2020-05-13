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
			int N = int.Parse(Console.ReadLine());
			var ss = new char[N, N];
			for (int i = 0; i < N; ++i) {
				char[] array = Console.ReadLine().ToCharArray();
				for (int j = 0; j < N; ++j) {
					ss[i, j] = array[j];
				}
			}

			/*
			for (int i = 0; i < N; ++i) {
				for (int j = 0; j < N; ++j) {
					//Console.Write($"{ss[i, j]}");
					Console.Write($"({i}, {j}) ");
				}

				Console.WriteLine($"");
			}

			Console.WriteLine($"");
			*/

			for (int j = 0; j < N; ++j) {
				for (int i = 0; i < N; ++i) {
					//Console.Write($"({N - i - 1}, {j}) ");
					Console.Write($"{ss[N - i - 1, j]}");
				}

				Console.WriteLine($"");
			}

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

