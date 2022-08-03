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
		public static void Exec()
		{
			ExecTemp();
		}

		public static void ExecTemp()
		{
			long n = long.Parse(Console.ReadLine());
			var a = new List<long>();
			for (var i = 0; i < n; i++) {
				a.Add(long.Parse(Console.ReadLine()));
			}

			long totalA = a.Sum();

			// リングバッファなので後ろにもう一つ付ける
			a.AddRange(a);

			var rui = new long[a.Count + 1];
			rui[0] = 0;
			for (var i = 0; i < a.Count; i++) {
				rui[i + 1] = a[i] + rui[i];
			}

			long max = 0;

			// 小課題1,2 切る場所を2つ選ぶのに3重ループで回す
			if (n <= 400) {
				var chank = new List<long> { 0, 0, 0, };
				for (var i = 0; i < a.Count; i++) {
					for (var j = i + 1; j < a.Count; j++) {
						for (var k = j + 1; k < a.Count; k++) {
							chank[0] = 0;
							chank[1] = 0;
							chank[2] = 0;

							chank[0] = rui[j] - rui[i];
							if (chank[0] > totalA) {
								chank[0] -= totalA;
							}


							chank[1] = rui[k] - rui[j];
							if (chank[1] > totalA) {
								chank[1] -= totalA;
							}

							chank[2] = totalA - (chank[0] + chank[1]);
							max = Math.Max(max, chank.Min());
						}
					}
				}
			}

			var answer = max;
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

		public static void Tenka()
		{
			long total = 130000000;
			long member = 42;
			for (var i = 0; i < total; ++i) {
				member += member;
				if (member > total) {
					break;
				}
			}

			Console.WriteLine($"{member}");
		}

		public static void Tashizan()
		{
			var ab = Console.ReadLine().Split(" ");
			var a = ab[0];
			var b = ab[1];
			var answer = int.Parse(a + b) * 2;
			Console.WriteLine($"{answer}");
		}

		// わざとTLE
		public static void AntiDivisionTLE()
		{
			var abcd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abcd[0];
			var b = abcd[1];
			var c = abcd[2];
			var d = abcd[3];

			var cdlcm = Lcm(c, d);

			long count = 0;
			for (var i = a; i <= b; ++i) {
				if (i % c != 0 && i % d != 0 && i % cdlcm != 0) {
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void AntiDivision()
		{
			var abcd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abcd[0];
			var b = abcd[1];
			var c = abcd[2];
			var d = abcd[3];

			var cdlcm = Lcm(c, d);
			long cCount = (b / c) - ((a - 1) / c);
			long dCount = (b / d) - ((a - 1) / d);
			long cdCount = (b / cdlcm) - ((a - 1) / cdlcm);
			long bar = cCount + dCount - cdCount;

			var answer = (long)(b - a - bar + 1);
			Console.WriteLine($"{answer}");
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

		public static void RobotTakahashi()
		{
			var n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();
			var w = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			var answer = 0;

			bool isAllSame = s.Contains('1') == false || s.Contains('0') == false;
			if (isAllSame) {
				answer = n;
			} else {
				var childs = new Dictionary<int, int>();
				var adults = new Dictionary<int, int>();
				var list = new List<int>();
				var hash = new HashSet<int>();
				for (var i = 0; i < n; ++i) {
					if (hash.Contains(w[i]) == false) {
						hash.Add(w[i]);
						list.Add(w[i]);
					}

					if (s[i] == '1') {
						if (adults.ContainsKey(w[i]) == false) {
							adults[w[i]] = 1;
						} else {
							++adults[w[i]];
						}
					} else {
						if (childs.ContainsKey(w[i]) == false) {
							childs[w[i]] = 1;
						} else {
							++childs[w[i]];
						}
					}
				}

				// ここが大事
				list.Sort();

				int countA = s.Count(s => s == '1');
				int countC = 0;
				int max = countA + countC;

				for (var i = 0; i < list.Count; ++i) {
					if (adults.ContainsKey(list[i])) {
						countA -= adults[list[i]];
					}

					if (childs.ContainsKey(list[i])) {
						countC += childs[list[i]];
					}

					max = Math.Max(countA + countC, max);
				}

				answer = max;
			}

			Console.WriteLine($"{answer}");
		}
	}
}

