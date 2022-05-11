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
		public static void Vote()
		{
			long n = long.Parse(Console.ReadLine());

			var arrayX = new long[n];
			var arrayY = new long[n];
			var arrayAgree = new int[n];
			var rui = new long[n + 1];
			rui[0] = 0;
			for (var i = 0; i < n; i++)
			{
				var xy = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				arrayX[i] = xy[0];
				arrayY[i] = xy[1];

			}

			long count = 0;

			for (var i = 0; i < n; i++)
			{
				if (arrayY[i] == 0)
                {
					arrayAgree[i] = 1;
					++count;
				} else if (arrayX[i] + 1 == arrayY[i])
				{
					arrayAgree[i] = 0;
				} else if (arrayX[i] == i)
                {
					if (count >= arrayY[i])
					{
						arrayAgree[i] = 1;
						++count;
					}
				} else {
					long right = i;
					long left = i - arrayX[i] >= 0 ? i - arrayX[i] : 0;
					long aCount = rui[right] - rui[left];
					/*
					for (var j = 1; j <= arrayX[i]; j++)
                    {
						if ((i - j) >= 0 && arrayAgree[i - j] != 0)
                        {
							++aCount;
                        }
                    }
					*/

					if (aCount >= arrayY[i])
					{
						arrayAgree[i] = 1;
						++count;
					}
				}

				rui[i + 1] = arrayAgree[i] + rui[i];
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Exec()
		{
			Vote();
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

		public static void CodeFestival()
		{
			string s = Console.ReadLine();
			string ans = "CODEFESTIVAL2016";
			int count = 0;
			for (var i = 0; i < s.Length; i++)
			{
				if (s[i] != ans[i])
				{
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Discovery2016()
		{
			int w = int.Parse(Console.ReadLine());
			string origin = "DiscoPresentsDiscoveryChannelProgrammingContest2016";

			int count = (int)Math.Ceiling(origin.Length / (double)w);

			var sb = new StringBuilder();
			sb.AppendLine(origin.Substring(0, w));
			if (w < origin.Length)
			{
				for (var i = 1; i < count; i++)
				{
					sb.AppendLine(origin.Substring(w * i, origin.Length > w + (w * i) ? w : origin.Length - (w * i)));
				}
			}

			Console.Write(sb.ToString());
		}

		public static void DiceSum()
		{
			var nmk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nmk[0];
			var m = nmk[1];
			var k = nmk[2];
			long deno = 998244353;

			var answer = 0;

			Console.WriteLine($"{answer}");
		}


		public static void Festival()
		{
			string s = Console.ReadLine();
			var answer = s.Substring(0, 4) + " " + s.Substring(4, 8);
			Console.WriteLine($"{answer}");
		}

		public static void BestBody()
		{
			var nst = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nst[0];
			var s = nst[1];
			var t = nst[2];
			long weight = long.Parse(Console.ReadLine());

			long count = 0;
			if (s <= weight && weight <= t)
			{
				++count;
			}

			for (var i = 1; i < n; i++)
			{
				var w = long.Parse(Console.ReadLine());
				weight += w;

				if (weight < 0)
				{
					weight = 0;
				}

				if (s <= weight && weight <= t)
				{
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}


	}
}

