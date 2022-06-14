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
			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var answer = 0;

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

