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
using System.ComponentModel.Design;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace AtCoderDotNetCore
{
	class Program
	{
		static void Main(string[] args)
		{
			Question.Exec();
		}
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
			if (parents[x] < 0) return x;
			else {
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

	public static class Question
	{
		public static void Exec()
		{
			ExecTemp();
		}

		public static void ExecTemp()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			var dict = new Dictionary<int, int>();

			var cards = new List<(int number, int index)>();
			bool hasBlank = false;
			for (var i = 0; i < n; ++i) {
				int card = int.Parse(Console.ReadLine());
				if (card > 0) {
					cards.Add((card, i));
				} else {
					hasBlank = true;
				}

				dict.Add(i, card);
			}

			if (n <= 1000 && k <= 500) {
				// 全探索
				cards.Sort((a, b) => a.number.CompareTo(b.number));

				for (var i = 1; i < cards.Count; ++i) {
					if (cards[i].number - cards[i - 1].number == 1) {

					}
				}

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

		public static void Theater()
		{
			int n = int.Parse(Console.ReadLine());

			long total = 0;
			for (var i = 0; i < n; ++i) {
				var lr = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var l = lr[0];
				var r = lr[1];
				total += (r - l + 1);
			}

			var answer = total;
			Console.WriteLine($"{answer}");
		}

		public static void SakasamaJisyo()
		{
			int n = int.Parse(Console.ReadLine());

			var dict = new Dictionary<string, string>();
			var list = new List<string>();
			for (var i = 0; i < n; ++i) {
				string s = Console.ReadLine();
				string rev = new string(s.Reverse().ToArray());
				list.Add(rev);
				dict.Add(rev, s);
			}

			list.Sort();

			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				builder.AppendLine(dict[list[i]]);
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
		}

		public static void Collision2()
		{
			int n = int.Parse(Console.ReadLine());

			var dict = new Dictionary<int, List<(int pos, bool isRight)>>();

			var xylist = new List<(int x, int y)>();
			for (var i = 0; i < n; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var x = xy[0];
				var y = xy[1];
				xylist.Add((x, y));
			}

			bool hasColl = false;

			string s = Console.ReadLine();

			for (var i = 0; i < n; ++i) {
				if (dict.ContainsKey(xylist[i].y) == false) {
					dict.Add(xylist[i].y, new List<(int, bool)>());
				}

				dict[xylist[i].y].Add((xylist[i].x, s[i] == 'R'));
			}

			// 各Yについて衝突が発生するかどうかチェックする
			foreach (var key in dict.Keys) {
				bool hasColl2 = false;
				var list = dict[key];

				// ソートして、Rに進むやつが出てくるまで見て、それいこうでLが出たら衝突
				list.Sort((a, b) => a.pos.CompareTo(b.pos));

				bool right = false;
				foreach ((var pos, bool isRight) in list) {
					if (right == false) {
						if (isRight == false) {
							continue;
						} else {
							right = true;
						}
					} else {
						if (isRight == false) {
							hasColl2 = true;
							break;
						}
					}
				}

				if (hasColl2) {
					hasColl = true;
					break;
				}
			}

			var answer = hasColl ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}
	}
}
}

