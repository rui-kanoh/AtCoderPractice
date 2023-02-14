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
			int n = int.Parse(Console.ReadLine());
			var m = 2 * n;
			var x = 0;

			// mについて [1, m - m/2]の範囲で探索してみれば良さそう
			// mになる和の組み合わせを全列挙して、それを1/2したときにnになるものを探す
			long min = long.MaxValue;
			for (var i = 1; i <= m - m / 2; ++i) {
				long value = m - i;
			}


			var answer = $"{min} {x}";
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

		public static void DoubleStrings()
		{
			string s = Console.ReadLine();
			var answer = s + s;
			Console.WriteLine($"{answer}");
		}

		public static void TensuHenkan()
		{
			var nab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nab[0];
			var a = nab[1];
			var b = nab[2];

			var s = new List<long>();
			for (var i = 0; i < n; ++i) {
				s.Add(long.Parse(Console.ReadLine()));
			}

			var sum = s.Sum();
			var max = s.Max();
			var min = s.Min();

			// Pが無い場合
			if (max == min) {
				Console.WriteLine($"-1");
				return;
			}

			decimal p = (decimal)b / (max - min);
			decimal q = (decimal)a - p * sum / n;

			var answer = $"{p} {q}";
			Console.WriteLine($"{answer}");
		}

		public static void TakahashiInformation()
		{
			var c = new int[3, 3];

			for (var i = 0; i < 3; ++i) {
				var cc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				for (var j = 0; j < 3; ++j) {
					c[i, j] = cc[j];
				}
			}

			bool isOK = false;

			int max = 100;
			for (var p = 0; p <= max; ++p) { // a1
				for (var q = 0; q <= max; ++q) { // a2
					for (var k = 0; k <= max; ++k) { // a3
						var l = c[0, 0] - p;
						var m = c[0, 1] - p;
						var n = c[0, 2] - p;
						if (c[0, 0] == p + l
							&& c[0, 1] == p + m
							&& c[0, 2] == p + n
							&& c[1, 0] == q + l
							&& c[1, 1] == q + m
							&& c[1, 2] == q + n
							&& c[2, 0] == k + l
							&& c[2, 1] == k + m
							&& c[2, 2] == k + n) {
							isOK = true;

							break;
						}

						if (isOK) {
							break;
						}
					}

					if (isOK) {
						break;
					}
				}

				if (isOK) {
					break;
				}
			}

			var answer = isOK ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}
	}
}

