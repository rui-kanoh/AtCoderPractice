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
		public static void Cooking()
		{
			int n = int.Parse(Console.ReadLine());
			var t = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			t.Sort();

			var rui = new int[n + 1];
			rui[0] = 0;
			for (var i = 1; i <= n; ++i) {
				rui[i] = t[i - 1] + rui[i - 1];
			}

			int total = t.Sum();
			int total2 = (int)Math.Ceiling((double)total / 2.0);

			var dp = new int[n + 1, total + 1];

			dp[0, 0] = 1;

			void UpdateDP(int i, int j)
			{
				if (i == n)
				{
					return;
				}
				else
				{
					dp[i + 1, j] += dp[i, j];
					UpdateDP(i + 1, j);

					dp[i + 1, j + t[i]] += dp[i, j];
					UpdateDP(i + 1, j + t[i]);
				}
			}

			UpdateDP(0, 0);

			/*
			for (var j = 0; j <= total; ++j)
			{
				for (var i = 0; i <= n; ++i)
				{
					Console.Write($"{dp[i, j]} ");
				}

				Console.WriteLine("");
			}
			*/

			var answer = 0;

			bool isFound = false;
			for (var j = total2; j < total; ++j)
            {
				for (var i = 0; i <= n; ++i)
                {
					if (dp[i, j] > 0)
                    {
						isFound = true;
						break;
                    }
                }

				if (isFound)
                {
					answer = j;
					break;
                }
			}

			Console.WriteLine($"{answer}");
		}

		public static void Exec()
		{
			Cooking();
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

		public static void GoHome()
		{
			long x = long.Parse(Console.ReadLine());

			// 1～nまでの和がXを超えるところを探せばOK
			// 余った部分は取り除ける
			long Calc(long l)
			{
				return ((1 + l) * l) / 2;
			}

			long answer = 0;

			for (long i = 1; i <= x; ++i)
			{
				if (Calc(i) >= x)
				{
					answer = i;
					break;
				}
			}

			Console.WriteLine($"{answer}");
		}

	}
}

