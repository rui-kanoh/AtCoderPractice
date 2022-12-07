﻿using System;
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
			var rnm = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var r = rnm[0];
			var n = rnm[1];
			var m = rnm[2];

			double Calc(double r, double angle_rad)
			{
				return 2 * r * Math.Sin(angle_rad / 2.0);
			}

			if (m == 1) {
				var cutCount = n - 1;
				var center = n / 2;
			}

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

		public static void TV()
		{
			var wh = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var w = wh[0];
			var h = wh[1];

			var answer = Math.Abs(((double)h / w) - (3.0 / 4.0)) < 1e-9 ? "4:3" : "16:9";

			Console.WriteLine($"{answer}");
		}

		public static void OOmoji()
		{
			var Cc = Console.ReadLine().Split(" ");

			var answer = Cc[0].ToLower() == Cc[1] ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void Renketsu()
		{
			var builder = new StringBuilder();

			var nq = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nq[0];
			var q = nq[1];

			var seen = new bool[n];
			bool DFS(HashSet<int>[] lists, int v, int goal)
			{
				if (v == goal) {
					return true;
				}

				seen[v] = true;

				foreach (var next_v in lists[v]) {
					if (seen[next_v]) {
						continue;
					}

					bool isOK = DFS(lists, next_v, goal);
					if (isOK) {
						return isOK;
					}
				}

				return false;
			}

			var lists = new HashSet<int>[n];
			for (var i = 0; i < n; ++i) {
				lists[i] = new HashSet<int>();
			}

			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var num = query[0];
				var u = query[1] - 1;
				var v = query[2] - 1;
				if (num == 1) {
					if (lists[u].Contains(v)) {
						lists[u].Remove(v);
						lists[v].Remove(u);
					} else {
						lists[u].Add(v);
						lists[v].Add(u);
					}
				} else {
					seen = new bool[n];
					bool isOK = DFS(lists, u, v);
					builder.AppendLine(isOK ? "Yes" : "No");
				}
			}

			var answer = builder.ToString();
			Console.WriteLine($"{answer}");
		}


		public static long Lcm(long a, long b)
		{
			long g = Gcd(a, b);
			return a / g * b;
		}

		public static void IsKaibun()
		{
			string s = Console.ReadLine();

			bool isKaibun(string s)
			{
				bool isOK = true;
				for (var i = 0; i < s.Length / 2; ++i) {
					if (s[i] != s[s.Length - i - 1]) {
						isOK = false;
						return isOK;
					}
				}

				return isOK;
			}

			bool isOK = isKaibun(s);
			var answer = isOK ? "YES" : "NO";

			Console.WriteLine($"{answer}");
		}

		public static void Month()
		{
			int n = int.Parse(Console.ReadLine());
			var answer = n == 12 ? 1 : n + 1;
			Console.WriteLine($"{answer}");
		}

		public static void Orca()
		{
			var st = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var sx = st[0] + 1000;
			var sy = st[1] + 1000;
			var gx = st[2] + 1000;
			var gy = st[3] + 1000;

			var h = 2001;
			var w = 2001;
			var map = new bool[h, w];
			for (var i = 0; i < h; ++i) {
				for (var j = 1; j < w; ++j) {
					map[i, j] = true;
				}
			}


		}


		public static void Restricted()
		{
			var	ab = Console.ReadLine().Split("	").Select(i	=> int.Parse(i)).ToArray();
			var	a =	ab[0];
			var	b =	ab[1];
			var	answer = (a	+ b	>= 10) ? "error" : $"{a	+ b}";
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

		public static void SecondGreatest()
		{
			int n = int.Parse(Console.ReadLine());
			var xlist = new List<(int index, long value)>();
			var ylist = new List<(int index, long value)>();
			for (var i = 0; i < n; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(j => long.Parse(j)).ToArray();
				xlist.Add((i, xy[0]));
				ylist.Add((i, xy[1]));
			}

			/* 愚直
			var hash = new HashSet<(int x, int y)>();
			var set = new List<long>();
			for (var i = 0; i < n; ++i) {
				for (var j = 1; j < n; ++j) {
					if (i == j) {
						continue;
					}

					if (hash.Contains((i, j)) || hash.Contains((j, i))) {
						continue;
					}

					long dist = Math.Max(Math.Abs(xlist[i] - xlist[j]), Math.Abs(ylist[i] - ylist[j]));
					set.Add(dist);
					hash.Add((i, j));
					hash.Add((j, i));
				}
			}

			set.Sort((a, b) => b.CompareTo(a));

			var answer = set[1];
			Console.WriteLine($"{answer}");
			*/

			/* 愚直2
			var set = new List<long>();
			for (var i = 0; i < n; ++i) {
				for (var j = i + 1; j < n; ++j) {
					long dist = Math.Max(Math.Abs(xlist[i] - xlist[j]), Math.Abs(ylist[i] - ylist[j]));
					set.Add(dist);
				}
			}

			set.Sort((a, b) => b.CompareTo(a));

			var answer = set[1];
			Console.WriteLine($"{answer}");
			*/

			xlist.Sort((a, b) => b.value.CompareTo(a.value));
			ylist.Sort((a, b) => b.value.CompareTo(a.value));

			long distMax = 0;
			var indexes = new HashSet<(int i, int j)>();
			if (Math.Abs(xlist[xlist.Count - 1].value - xlist[0].value) >= Math.Abs(xlist[ylist.Count - 1].value - ylist[0].value)) {
				distMax = Math.Abs(xlist[xlist.Count - 1].value - xlist[0].value);
				indexes.Add((xlist[0].index, xlist[xlist.Count - 1].index));
				indexes.Add((xlist[xlist.Count - 1].index, xlist[0].index));
			} else {
				distMax = Math.Abs(ylist[xlist.Count - 1].value - ylist[0].value);
				indexes.Add((ylist[0].index, ylist[xlist.Count - 1].index));
				indexes.Add((ylist[xlist.Count - 1].index, ylist[0].index));
			}

			long secondMax = 0;
			for (var i = 1; i < n; ++i) {
				if (indexes.Contains((xlist[xlist.Count - i - 1].index, xlist[0].index)) == false
					&& indexes.Contains((xlist[0].index, xlist[xlist.Count - i - 1].index)) == false) {
					long dist = Math.Abs(xlist[xlist.Count - i - 1].value - xlist[0].value);
					if (distMax < dist && secondMax < dist) {
						secondMax = Math.Max(secondMax, dist);

						break;
					}
				}
			}

			for (var i = 1; i < n; ++i) {
				if (indexes.Contains((xlist[xlist.Count - 1].index, xlist[i].index)) == false
					&& indexes.Contains((xlist[i].index, xlist[xlist.Count - 1].index)) == false) {
					long dist = Math.Abs(xlist[xlist.Count - 1].value - xlist[i].value);
					if (distMax < dist) {
						secondMax = Math.Max(secondMax, dist);
						break;
					}
				}
			}

			long secondMaxY = 0;
			for (var i = 1; i < n; ++i) {
				if (indexes.Contains((ylist[ylist.Count - i - 1].index, ylist[0].index)) == false
					&& indexes.Contains((ylist[0].index, ylist[ylist.Count - i - 1].index)) == false) {
					long dist = Math.Abs(ylist[ylist.Count - i - 1].value - ylist[0].value);
					if (distMax < dist) {
						secondMax = Math.Max(secondMax, dist);
						break;
					}
				}
			}

			for (var i = 1; i < n; ++i) {
				if (indexes.Contains((ylist[ylist.Count - 1].index, ylist[i].index)) == false
					&& indexes.Contains((ylist[i].index, ylist[ylist.Count - 1].index)) == false) {
					long dist = Math.Abs(ylist[ylist.Count - 1].value - ylist[i].value);
					if (distMax < dist) {
						secondMax = Math.Max(secondMax, dist);
						break;
					}
				}
			}
			Math.Max(
				Math.Abs(ylist[ylist.Count - 2].value - ylist[0].value),
				Math.Abs(ylist[ylist.Count - 1].value - ylist[1].value));

			//var answer = Math.Max(secondMaxX, secondMaxY);

			//Console.WriteLine($"{answer}");
		}

	}
}

