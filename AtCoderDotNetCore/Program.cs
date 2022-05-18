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
		public static void Multiplication()
		{
			var ab = Console.ReadLine().Split(" ");
			var a = long.Parse(ab[0]);
			double bb = double.Parse(ab[1]);
			// Math.Roundが大事
			var b = (long)(Math.Round(bb * 100.0));

			var answer = a * b;
			answer /= 100;

			Console.WriteLine($"{answer}");
		}

		public static void Exec()
		{
			Multiplication();
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

		public static void Rotation()
		{
			string s1 = Console.ReadLine();
			string s2 = Console.ReadLine();

			bool isOK = s1[2] == s2[0] && s1[1] == s2[1] && s1[0] == s2[2];
			var answer = isOK ? "YES" : "NO";

			Console.WriteLine($"{answer}");
		}

		public static void Nando()
		{
			int n = int.Parse(Console.ReadLine());

			int count = 0;
			for (var i = 0; i < n; ++i)
			{
				var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				int sum = array.Sum();
				if (sum < 20)
				{
					++count;
				}
			}


			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void MonSho()
		{
			var mn = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var m = mn[0];
			var n = mn[1];
			var flag = new char[m + 2, n + 2];
			for (var i = 0; i < m; ++i)
			{
				var s = Console.ReadLine();
				for (var j = 0; j < n; ++j)
				{
					flag[i + 1, j + 1] = s[j];
				}
			}

			var mon = new char[2, 2];
			for (var i = 0; i < 2; ++i)
			{
				var s = Console.ReadLine();
				for (var j = 0; j < 2; ++j)
				{
					mon[i, j] = s[j];
				}
			}

			var joi = new[] { 'J', 'O', 'I' };

			bool Find2(int i, int j)
			{
				for (var k = 0; k < 2; ++k)
				{
					for (var l = 0; l < 2; ++l)
					{
						if (mon[k, l] != flag[i + k, j + l])
						{
							return false;
						}
					}
				}

				return true;
			}

			int Find()
			{
				int count = 0;

				for (var i = 0; i < m; ++i)
				{
					for (var j = 0; j < n; ++j)
					{
						bool isFound = Find2(i, j);
						if (isFound)
						{
							++count;
						}
					}
				}

				return count;
			}

			int Find3(int i, int j)
			{
				int count = 0;
				for (var ii = -1; ii <= 0; ++ii)
				{
					for (var jj = -1; jj <= 0; ++jj)
					{
						bool isFound = Find2(i + ii, j + jj);
						if (isFound)
						{
							++count;
						}
					}
				}

				return count;
			}

			int max = Find();
			int count2 = max;
			for (var i = 0; i < m; ++i)
			{
				for (var j = 0; j < n; ++j)
				{
					foreach (var item in joi)
					{
						if (flag[i + 1, j + 1] == item)
						{
							continue;
						}

						int countOld = Find3(i + 1, j + 1);

						var old = flag[i + 1, j + 1];
						flag[i + 1, j + 1] = item;

						int countNew = Find3(i + 1, j + 1);
						int count = count2 - countOld + countNew;

						max = Math.Max(max, count);
						flag[i + 1, j + 1] = old;
					}
				}
			}

			Console.WriteLine($"{max}");
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

