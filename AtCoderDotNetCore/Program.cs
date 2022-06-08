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
		public static void WoodToy()
		{
			long n = long.Parse(Console.ReadLine());
			var sarray = new long[n];

			for (var i = 0; i < n; ++i)
			{
                var s = long.Parse(Console.ReadLine());
				sarray[i] = s;
			}

			var dict = new Dictionary<long, long>();
			for (var i = 0; i < n - 1; ++i)
			{
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				dict[b] = a;
			}

			long m = long.Parse(Console.ReadLine());
			var tlist = new long[m];
			for (var j = 0; j < m; ++j)
			{
                var t = long.Parse(Console.ReadLine());

				long max = -1;
				int index = -1;
				for (var i = 0; i < n; ++i)
                {
					if (i == 0)
                    {
						if (sarray[i] <= t)
						{
							if (max < t - sarray[i])
                            {
								max = t - sarray[i];
								index = i;
							}
						}
					} else
                    {
						if (sarray[dict[i]] <= t)
						{
							if (max < t - sarray[dict[i]])
                            {
								max = t - sarray[dict[i]];
								index = i;
							}
						}
					}
                }

				if (max != -1)
                {
					if (index == 0)
					{
						sarray[0] = t;
					}
					else
					{
						sarray[dict[index]] = sarray[index];
						sarray[index] = t;
					}
				}
			}

			var answer = sarray.Sum();
			Console.WriteLine($"{answer}");
		}


		public static void Exec()
		{
			WoodToy();
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

		public static void Cooking()
		{
			int n = int.Parse(Console.ReadLine());
			var t = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			if (n <= 2)
			{
				if (n == 1)
				{
					Console.WriteLine($"{t[0]}");
				}
				else
				{
					Console.WriteLine($"{Math.Max(t[0], t[1])}");
				}
			}
			else
			{
				int total = t.Sum();
				int total2 = (int)Math.Ceiling(total / 2.0m);

				// dpテーブル作成
				var dp = new int[n + 1, total + 1];
				dp[0, 0] = 1;
				for (int i = 1; i <= n; ++i)
				{
					for (int j = 0; j <= total; ++j)
					{
						int value = dp[i - 1, j];
						if (value != 0)
						{
							// intですらオーバーフローするので対応
							dp[i, j] = (int)((((long)dp[i, j] % (long)int.MaxValue) + ((long)value % (long)int.MaxValue)) % (long)int.MaxValue);
							if (j < total - t[i - 1])
							{
								dp[i, j + t[i - 1]] = (int)((((long)dp[i, j + t[i - 1]] % (long)int.MaxValue) + ((long)value % (long)int.MinValue)) % (long)int.MaxValue);
							}
						}
					}
				}

				int answer = 0;

				// i == nのときのtotal2以降で0より大きい物があればOK
				for (int j = total2; j < total; ++j)
				{
					if (dp[n, j] > 0)
					{
						answer = j;
						break;
					}
				}

				Console.WriteLine($"{answer}");
			}
		}

		public static void HAGIXILE()
		{
			string s = Console.ReadLine();

			var answer = s.Replace("HAGIYA", "HAGIXILE");
			Console.WriteLine($"{answer}");
		}
	}
}

