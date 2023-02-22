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
			ChangesUserNames();
		}

		public class UnionFind
		{
			List<int> parents;

			public int GroupCount { get; private set; }

			public UnionFind(int x)
			{
				parents = Enumerable.Repeat(-1, x).ToList();
				GroupCount = x;
			}

			public int Find(int x)
			{
				if (parents[x] < 0) {
					return x;
				} else {
					parents[x] = Find(parents[x]);
					return parents[x];
				}
			}

			public void Union(int x, int y)
			{
				(x, y) = (Find(x), Find(y));

				if (x != y) {
					if (Count(x) < Count(y)) (x, y) = (y, x);
					parents[x] += parents[y];
					parents[y] = x;
					GroupCount--;
				}
			}

			public int Count(int x) => -parents[Find(x)];

			public bool IsSame(int x, int y) => Find(x) == Find(y);
		}

		public static void ChangesUserNames()
		{
			var n = int.Parse(Console.ReadLine());

			var snames = new string[n];
			var tnames = new string[n];
			var dict = new Dictionary<string, int>();

			int index = 0;
			for (var i = 0; i < n; ++i) {
				string[] st = Console.ReadLine().Split(" ");
				snames[i] = st[0];
				tnames[i] = st[1];

				if (dict.ContainsKey(st[0]) == false) {
					dict.Add(st[0], index);
					++index;
				}

				if (dict.ContainsKey(st[1]) == false) {
					dict.Add(st[1], index);
					++index;
				}
			}

			if (n == 1) {
				Console.WriteLine("Yes");
				return;
			}

			var union = new UnionFind(dict.Count);

			bool isOK = true;

			// 親が同じものがあれば閉路
			for (var i = 0; i < n; ++i) {
				if (union.IsSame(dict[snames[i]], dict[tnames[i]])) {
					isOK = false;
					break;
				}

				union.Union(dict[snames[i]], dict[tnames[i]]);
			}

			var answer = isOK ? "Yes" : "No";
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

		public static void A()
		{
			char X = char.Parse(Console.ReadLine());

			var answer = X - 'A' + 1;
			Console.WriteLine($"{answer}");
		}

		public static void CountingRoads()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var lists = new int[n];

			for (var i = 0; i < m; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				++lists[a];
				++lists[b];
			}

			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				builder.AppendLine($"{lists[i]}");
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
		}

		public static void D()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			var dict = new Dictionary<long, long>();

			var wlist = new List<long>();
			var dlist = new long[n];

			for (var i = 0; i < n; ++i) {
				var wd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var w = nk[0] - 1;
				var d = nk[1];

				wlist.Add(w);
				dlist[i] = d;
			}

			wlist.Sort();

			long count = 0;
			while (count < k) {

				if (k >= count) {
					break;
				}
			}


			long x = -1;
			foreach (var item in dict) {
				count += item.Value;
				if (count >= k) {
					x = item.Key;
					break;
				}
			}

			var answer = x;
			Console.WriteLine($"{answer}");
		}

	}
}

