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
using System.Reflection;

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
		public static void Exec()
		{
			ExecTemp();
		}

		public static void ExecTemp()
		{
			var kr = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var k = kr[0];
			var r = kr[1];

			var mizu = new bool[r];
			var odist = new List<long>();
			var fdist = new List<long>();
			for (var i = 0; i < r; ++i) {
				var ta = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			}

			if (r == 0) {
				var dp = new long[k  + 1, k  + 1];
				for (var i = 0; i < k + 1; ++i) {
					for (var j = 0; j < k + 1; ++j) {
						dp[i, j] = 0;
					}
				}

				dp[0, 0] = 1;
				for (var j = 0; j < k; ++j) {
					for (var l = 0; l < k + 1; ++l) {
						if (dp[j, l] > 0) {
							dp[j + 1, l] += dp[j, l];
							if (l + 1 < k + 1) {
								dp[j + 1, l + 1] += dp[j, l];
							}

							if (l + 2 < k + 1) {
								dp[j + 1, l + 2] += dp[j, l];
							}
						}
					}
				}

				long total = 0;
				for (var j = 0; j < k + 1; ++j) {
					total = Math.Max(total, dp[j, k]);
				}
				/*
				for (var i = 0; i < k + 1; ++i) {
					for (var j = 0; j < k + 1; ++j) {
						dp[i, j] = 0;
					}
				}

				dp[0, 0] = total;
				for (var j = 0; j < k + 1; ++j) {
					for (var l = 0; l < k + 1; ++l) {
						if (dp[j, l] > 0) {
							if (l + 1 < k + 1) {
								dp[j + 1, l + 1] += dp[j, l];
							}

							if (l + 2 < k + 1) {
								dp[j + 1, l + 2] += dp[j, l];
							}
						}
					}
				}

				total = 0;
				for (var j = 0; j < k + 1; ++j) {
					total = Math.Max(total, dp[j, k]);
				}
				*/

				var answer = total;
				Console.WriteLine($"{answer}");
			} else {
				var answer = 0;
				Console.WriteLine($"{answer}");
			}
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

		public static void SumAndProduct()
		{
			var sp = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var s = sp[0];
			var p = sp[1];

			bool isOK = true;

			var answer = isOK ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void KSwap()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static void BathTime()
		{
			int n = int.Parse(Console.ReadLine());
			int min = n / 60;
			int hour = min / 60;
			min = min % 60;
			int sec = n % 60;

			var answer = $"{hour:d2}:{min:d2}:{sec:d2}";
			Console.WriteLine($"{answer}");
		}


		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

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
	}
}

