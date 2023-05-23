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

		public static void Louis()
		{
			int n = int.Parse(Console.ReadLine());
			string[] strs = Console.ReadLine().ToLower().Split(" ");

			var dict = new Dictionary<char, string>();
			dict['a'] = "";
			dict['i'] = "";
			dict['u'] = "";
			dict['e'] = "";
			dict['o'] = "";

			dict['b'] = "1";
			dict['c'] = "1";

			dict['d'] = "2";
			dict['w'] = "2";

			dict['t'] = "3";
			dict['j'] = "3";

			dict['f'] = "4";
			dict['q'] = "4";

			dict['l'] = "5";
			dict['v'] = "5";

			dict['s'] = "6";
			dict['x'] = "6";

			dict['p'] = "7";
			dict['m'] = "7";

			dict['h'] = "8";
			dict['k'] = "8";

			dict['n'] = "9";
			dict['g'] = "9";

			dict['z'] = "0";
			dict['r'] = "0";

			var builder = new StringBuilder();

			bool isFirst = true;
			foreach (var s in strs) {
				string temp = "";
				for (var i = 0; i < s.Length; ++i) {
					if (dict.ContainsKey(s[i]) == false) {
						continue;
					}

					temp += dict[s[i]];
				}

				if (string.IsNullOrWhiteSpace(temp) == false) {
					if (isFirst == false) {
						builder.Append(" ");
					} else {
						isFirst = false;
					}

					builder.Append(temp);
				}
			}

			var answer = builder.ToString();
			Console.WriteLine($"{answer}");
		}

		public static void Kaizodo()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			var a = new int[n];
			for (var i = 0; i < n; ++i) {
				a[i] = int.Parse(Console.ReadLine());
			}

			if (n < k) {
				Console.WriteLine($"0");
				return;
			}

			if (n == 1 && k == 1) {
				Console.WriteLine($"1");
				return;
			}

			int count = 0;
			var list = new List<int>();
			list.Add(a[0]);
			for (var i = 1; i < n; ++i) {
				if (a[i - 1] < a[i]) {
					list.Add(a[i]);
				} else {
					if (list.Count >= k) {
						count += list.Count - k + 1;
					}

					list.Clear();
					list.Add(a[i]);
				}
			}

			if (list.Count >= k) {
				count += list.Count - k + 1;
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		// DPでやってみた場合（断念）
		public static void KaizodoDP()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			var a = new int[n];
			for (var i = 0; i < n; ++i) {
				a[i] = int.Parse(Console.ReadLine()) / 100;
			}

			var amax = a.Max();
			var dp = new bool[n + 1, amax + 1];
			var dpCount = new int[n + 1, amax + 1];
			dp[0, 0] = true;

			for (var i = 0; i < n; ++i) {
				for (var j = 0; j <= amax; ++j) {
					if (dp[i, j]) {
						if (a[i] > j && dpCount[i, j] < k) {
							dp[i + 1, a[i]] = true;
							dpCount[i + 1, a[i]] = Math.Min(dpCount[i + 1, a[i]], dpCount[i, j]);
						}

						dp[i + 1, j] = true;
						dpCount[i + 1, j] = Math.Min(dpCount[i + 1, j], dpCount[i, j]);
					}
				}
			}

			int count = 0;
			for (var j = 0; j <= amax; ++j) {
				if (dp[n, j] && dpCount[n, j] == k) {
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}
	}
}

