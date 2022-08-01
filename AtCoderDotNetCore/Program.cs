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

		public static void AntiDivision()
		{
			var abcd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abcd[0];
			var b = abcd[1];
			var c = abcd[2];
			var d = abcd[3];

			var cdlcm = Lcm(c, d);
			long cCount = (b / c) - (a / c) + ((a % c == 0) ? 1 : 0);
			long dCount = (b / d) - (a / d) + ((a % d == 0) ? 1 : 0);
			long cdCount = (b / cdlcm) - (a / cdlcm) + ((a % cdlcm) == 0 ? 1 : 0);
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

				list.Sort();
				list.Insert(0, 0);

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

