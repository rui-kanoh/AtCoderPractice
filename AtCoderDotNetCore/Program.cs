using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Intrinsics.X86;


namespace AtCoderDotNetCore
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
		public static void ExecTemp()
		{
			long n = long.Parse(Console.ReadLine());

			var list = new (long a, long b, long c)[n];
			long total = 0;
			for (var i = 0; i < n; ++i) {
				var abc = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var a = abc[0];
				var b = abc[1];
				var c = abc[2];
				list[i] = (a, b, c);
				if ((BigInteger)total + (BigInteger)abc.Max() < (BigInteger)long.MaxValue) {
					total += abc.Max();
				}
			}

			var dp = new bool[n + 1, total + 1, 3];
			dp[0, 0, 0] = true;
			dp[1, list[0].a, 0] = true;
			dp[1, list[0].b, 1] = true;
			dp[1, list[0].c, 2] = true;

			for (var i = 2; i <= n; ++i) {
				var a = list[i - 1].a;
				var b = list[i - 1].b;
				var c = list[i - 1].c;

				for (int j = 0; j <= total; ++j) {
					for (int k = 0; k < 3; ++k) {
						if (dp[i - 1, j, k]) {
							if (k == 0) {
								if (j <= total - b) {
									dp[i, j + b, 1] = true;
								}

								if (j <= total - c) {
									dp[i, j + c, 2] = true;
								}
							} else if (k == 1) {
								if (j <= total - c) {
									dp[i, j + c, 2] = true;
								}

								if (j <= total - a) {
									dp[i, j + a, 0] = true;
								}
							} else {
								if (j <= total - a) {
									dp[i, j + a, 0] = true;
								}

								if (j <= total - b) {
									dp[i, j + b, 1] = true;
								}
							}
						}
					}
				}
			}

			long max = 0;
			for (int j = 0; j <= total; ++j)
			{
				for (int k = 0; k < 3; ++k) {
					if (dp[n, j, k]) {
						max = Math.Max(max, j);
					}
				}
			}

			var answer = max;

			Console.WriteLine($"{answer}");
		}

		public static void Exec()
		{
			ExecTemp();
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static void ExecTemp()
		{
			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void Index()
		{
			string s = Console.ReadLine();
			int i = int.Parse(Console.ReadLine());
			var answer = s[i - 1];

			Console.WriteLine($"{answer}");
		}

		public static void Takahashi()
		{
			string X = Console.ReadLine();
			string s = Console.ReadLine();
			var answer = s.Replace(X, "");
			Console.WriteLine($"{answer}");
		}


		public static void A()
		{
			long n = long.Parse(Console.ReadLine());

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static void Nankisei()
		{
			string s = Console.ReadLine();

			int count = 0;
			for (var i = 0; i < s.Length; ++i)
			{
				if (Char.IsNumber(s[i]))
				{
					if (i < s.Length - 1)
					{
						if (Char.IsNumber(s[i + 1]))
						{
							count = int.Parse(s[i].ToString()) * 10 + int.Parse(s[i + 1].ToString());
						}
						else
						{
							count = int.Parse(s[i].ToString());
						}

						break;
					}
					else
					{
						count = int.Parse(s[i].ToString());
						break;
					}
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void JumpingTakahashi()
		{
			var nx = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nx[0];
			var x = nx[1];

			var dp = new bool[n + 1, x + 1];
			dp[0, 0] = true;

			for (var i = 1; i <= n; ++i)
			{
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var a = ab[0];
				var b = ab[1];

				for (int j = 0; j <= x; ++j)
				{
					if (dp[i - 1, j])
					{
						if (j <= x - a)
						{
							dp[i, j + a] = true;
						}

						if (j <= x - b)
						{
							dp[i, j + b] = true;
						}
					}
				}
			}

			/*
			for (int j = 0; j <= x; ++j)
			{
				for (var i = 0; i <= n; ++i)
                {
					Console.Write(dp[i, j] ? "1 " : "0 ");
				}

				Console.WriteLine("");
			}
			*/

			var answer = dp[n, x] ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}
	}
}

