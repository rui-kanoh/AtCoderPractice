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
			ExecTemp();
		}

		public static void ExecTemp()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			// 勝ち数リスト
			var dict = new Dictionary<int, int>();
			for (var i = 0; i < 2 * n; ++i) {
				dict.Add(i, 0);
			}

			static bool IsWin(string src, string dst)
			{
				bool wins = (src == "G" && dst == "C")
					|| (src == "C" && dst == "P")
					|| (src == "P" && dst == "G");
				return wins;
			}

			var a = new string[2 * n, m];
			for (var i = 0; i < 2 * n; ++i) {
				string s = Console.ReadLine();
				for (var j = 0; j < s.Length; ++j) {
					a[i, j] = s[j].ToString();
				}
			}

			// 最初の試合
			var pare = new (int src, int dst)[n];
			for (var i = 0; i < n; ++i) {
				pare[i] = (2 * i, 2 * i + 1);
			}

			for (var i = 0; i < m; ++i) {
				// 最初のペアが (0, 1) (2, 3)
				//dict[0] += IsWin(a[0, m], a[1, m]) ? 1 : 0;
				//dict[1] += IsWin(a[1, m], a[0, m]) ? 1 : 0;

				//dict[2] += IsWin(a[2, m], a[3, m]) ? 1 : 0;
				//dict[3] += IsWin(a[3, m], a[2, m]) ? 1 : 0;

				if (i > 0) {
					var sorted = dict.OrderByDescending(j => j.Value).ToArray();
					for (var j = 0; j < sorted.Length / 2; ++j) {
						var src = sorted[2 * j].Key;
						var dst = sorted[2 * j + 1].Key;
						pare[j] = (src, dst);
					}
				}

				for (var j = 0; j < n; ++j) {
					dict[pare[j].src] += IsWin(a[pare[j].src, i], a[pare[j].dst, i]) ? 1 : 0;
					dict[pare[j].dst] += IsWin(a[pare[j].dst, i], a[pare[j].src, i]) ? 1 : 0;
				}
			}

			var answer = dict.OrderByDescending(j => j.Value).ToArray();
			var builder = new StringBuilder();
			foreach (var item in answer) {
				builder.AppendLine($"{item.Key + 1}");
			}

			Console.Write(builder.ToString());
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


		public static void BetterWorse()
		{
			var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			var answer = xy[0] < xy[1] ? "Better" : "Worse";
			Console.WriteLine($"{answer}");
		}

		public static void APlusB()
		{
			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			var answer = "";

			if (a + b == c && a - b == c) {
				answer = "?";
			} else {
				if (a + b == c) {
					answer = "+";
				} else if (a - b == c) {
					answer = "-";
				} else {
					answer = "!";
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void Swiss()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			// 勝ち数リスト
			var dict = new Dictionary<int, int>();
			for (var i = 0; i < 2 * n; ++i) {
				dict.Add(i, 0);
			}

			static bool IsWin(string src, string dst)
			{
				bool wins = (src == "G" && dst == "C")
					|| (src == "C" && dst == "P")
					|| (src == "P" && dst == "G");
				return wins;
			}

			var a = new string[n, m];
			for (var i = 0; i < 2 * n; ++i) {
				string s = Console.ReadLine();
				for (var j = 0; j < s.Length; ++j) {
					a[i, j] = s[j].ToString();
				}
			}

			// 最初の試合
			for (var i = 0; i < m; ++i) {
				dict[0] += IsWin(a[0, m], a[1, m]) ? 1 : 0;
				dict[1] += IsWin(a[1, m], a[0, m]) ? 1 : 0;

				dict[2] += IsWin(a[2, m], a[3, m]) ? 1 : 0;
				dict[3] += IsWin(a[3, m], a[2, m]) ? 1 : 0;

				dict.OrderBy(j => j.Value);
			}

			var answer = "";

			Console.WriteLine($"{answer}");
		}

		public static void IshiTori()
		{
			long n = long.Parse(Console.ReadLine());
			var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];

			// nが a + b + 1になるまで削る
			var value = n;
			while (value > 2 * (a + b) + 1) {
				value -= (a + b);
			}

			var answer = "";
			if (value - 2 <= a) {

			}


			Console.WriteLine($"{answer}");
		}
	}
}

