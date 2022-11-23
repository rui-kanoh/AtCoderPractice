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
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void Exec()
		{
			ExecTemp();
		}

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

		public static void Restricted()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];
			var answer = (a + b >= 10) ? "error" : $"{a + b}";
			Console.WriteLine($"{answer}");
		}

		public static void Shima()
		{
			var nc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nc[0];
			var c = nc[1];
			var alist = new int[n];

			for (var i = 0; i < n; ++i) {
				alist[i] = int.Parse(Console.ReadLine()) - 1;
			}

			long min = long.MaxValue;

			for (var i = 0; i < 10; ++i) {
				for (var j = 0; j < 10; ++j) {
					if (i == j) {
						continue;
					}

					long cost = 0;
					int count = IsOdd(n) ? (n + 1) / 2 : n / 2;
					for (var k = 0; k < count; ++k) {
						if (alist[2 * k] != i) {
							cost += c;
						}
					}

					for (var k = 0; k < n / 2; ++k) {
						if (alist[2 * k + 1] != j) {
							cost += c;
						}
					}

					min = Math.Min(min, cost);
				}
			}

			var answer = min;
			Console.WriteLine($"{answer}");
		}

		public static void ShoppingStreet()
		{
			int n = int.Parse(Console.ReadLine());

			var flist = new List<List<bool>>();
			for (var i = 0; i < n; ++i) {
				var list = Console.ReadLine().Split(" ").Select(j => int.Parse(j) == 1 ? true : false).ToList();
				flist.Add(list);
			}

			var plist = new long[n, 11];
			for (var i = 0; i < n; ++i) {
				var p = Console.ReadLine().Split(" ").Select(j => long.Parse(j)).ToArray();
				for (var k = 0; k < p.Length; ++k) {
					plist[i, k] = p[k];
				}
			}

			long max = long.MinValue;

			void DfsBool(List<bool> items, int num)
			{
				if (items.Count == num) {
					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					int count = items.Count(s => s != false);
					if (count == 0) {
						// 全部営業しないのは無し
						return;
					}

					long benefit = 0;
					for (var i = 0; i < n; ++i) {
						int count2 = 0;
						for (var k = 0; k < num; ++k) {
							if (items[k] && flist[i][k]) {
								++count2;
							}
						}

						benefit += plist[i, count2];
					}

					max = Math.Max(max, benefit);
					return;
				}

				Array.ForEach(
					new[] { true, false },
					value => {
						items.Add(value);
						DfsBool(items, num);
						items.RemoveAt(items.Count - 1);
					});
			}

			DfsBool(new List<bool>(), 10);

			var answer = max;

			Console.WriteLine($"{answer}");
		}

		public static void DeliciousBurgers()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			string s = Console.ReadLine();

			var list = new List<long>();
			int count = 0;
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] == '(') {
					++count;
				} else if (s[i] == ')') {
					--count;
				}

				list.Add(count);
			}

			// 降順にソート
			list.Sort((a, b) => b.CompareTo(a));

			long max = 0;
			for (var i = 0; i < k; ++i) {
				max += list[i];
			}

			var answer = max;
			Console.WriteLine($"{answer}");
		}
	}
}

