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
using System.Drawing;
using System.Net;
using System.Xml.Schema;

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
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var idols = new List<int>();
			var pphs = new List<int>();
			var costs = new List<int>();
			var clist = new List<int>();

			for (var i = 0; i < m; ++i) {
				var cc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var c = cc[0];
				clist.Add(c);
				var cost = cc[1];
				costs.Add(cost);

				for (var j = 0; j < c; ++j) {
					var ip = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
					var idol = ip[0];
					var pph = ip[1];

					idols.Add(idol);
					pphs.Add(pph);
				}
			}

			var total = 0.0;
			for (var i = 1; i <= 20; ++i) {
				var cost = 300.0;
				var cost2 = 300.0;
				for (var j = 0; j < i; ++j) {
					cost *= (5.0 / 100.0);
					cost2 *= (95.0 / 100.0);
				}

				total += cost + cost2;
			}
			Console.WriteLine($"{total}");

			if (n == 1 && m == 1) {
				var answer = costs[0];
				Console.WriteLine($"{answer}");
			} else {
				if (n == 1) {
					var answer = costs.Min();
					Console.WriteLine($"{answer}");
				} else {
					// Ci = 1 を満たす全ての入力に正解した場合
					if (clist.Distinct().ElementAt(0) == 1) {
						// M個のくじ引きが全部100%
						//var answer = costs.Sum();

						if (m == n) {
							var answer = costs.Sum();
							Console.WriteLine($"{answer}");
						} else {
							var dict = new Dictionary<int, int>();
							for (var i = 0; i < m; ++i) {
								if (dict.ContainsKey(costs[i]) == false) {
									dict.Add(costs[i], idols[i]);
								} else {
									if (dict[costs[i]] > idols[i]) {
										dict[costs[i]] = idols[i];
									}
								}
							}

							var answer = dict.Values.Sum();
							Console.WriteLine($"{answer}");
						}
					}
				}
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

		public static void SocialGame()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var idols = new List<int>();
			var pphs = new List<int>();
			var costs = new List<int>();
			var clist = new List<int>();

			for (var i = 0; i < m; ++i) {
				var cc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var c = cc[0];
				clist.Add(c);
				var cost = cc[1];
				costs.Add(cost);

				for (var j = 0; j < c; ++j) {
					var ip = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
					var idol = ip[0];
					var pph = ip[1];

					idols.Add(idol);
					pphs.Add(pph);
				}
			}

			if (n == 1 && m == 1) {
				var answer = costs[0];
				Console.WriteLine($"{answer}");
			} else {
				if (n == 1) {
					var answer = costs.Min();
					Console.WriteLine($"{answer}");
				} else {
					// Ci = 1 を満たす全ての入力に正解した場合
					if (clist.Distinct().ElementAt(0) == 1) {
						// M個のくじ引きが全部100%
						//var answer = costs.Sum();

						if (m == n) {
							var answer = costs.Sum();
							Console.WriteLine($"{answer}");
						} else {
							var dict = new Dictionary<int, int>();
							for (var i = 0; i < m; ++i) {
								if (dict.ContainsKey(costs[i]) == false) {
									dict.Add(costs[i], idols[i]);
								} else {
									if (dict[costs[i]] > idols[i]) {
										dict[costs[i]] = idols[i];
									}
								}
							}

							var answer = dict.Values.Sum();
							Console.WriteLine($"{answer}");
						}
					}
				}
			}
		}

		public static void Uruu()
		{
			int y = int.Parse(Console.ReadLine());
			bool isOK = false;
			if (y % 4 == 0) {
				if (y % 100 == 0 && y % 400 != 0) {
					isOK = false;
				} else {
					isOK = true;
				}
			} else {
				isOK = false;
			}

			var answer = isOK
				? "YES"
				: "NO";
			Console.WriteLine($"{answer}");
		}
		public static void Exec229()
		{
			static long Calc(long b)
			{
				long count = (b / 4) - (b / 100) + (b / 400);
				return count;
			}

			var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];
			long count = Calc(b);
			count -= Calc(a - 1);

			// 愚直になげるとTLE
			/*
			for (long i = a; i <= b; ++i) {
				if (i % 4 == 0 && (i % 100 != 0 || i % 400 == 0)) {
					++count;
				}
			}
			*/

			var answer = count;
			Console.Write($"{answer}");
		}
		
		public static bool Check(long value, long[] list)
		{
			var num = list.Distinct().Count(x => x <= value);
			var amari = list.Length - num > 0
				? list.Length - num
				: 0;
			bool isOK = value <= num + (amari / 2);

			return isOK;
		}

		public static (long ok, long ng) BinarySearch(long[] list)
		{
			long ok = 0;
			long ng = list.Length + 1;
			while (ng - ok > 1) {
				long mid = (ng + ok) / 2;
				if (Check(mid, list)) {
					ok = mid;
				} else {
					ng = mid;
				}
			}

			return (ok, ng);
		}

		public static void Manga()
		{
			long n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			if (n == 1) {
				if (a[0] != 1) {
					Console.WriteLine($"0");
				} else {
					Console.WriteLine($"1");
				}

				return;
			}

			(long ok, long ng) = BinarySearch(a);

			var answer = ok;
			Console.WriteLine($"{answer}");
		}
	}
}

