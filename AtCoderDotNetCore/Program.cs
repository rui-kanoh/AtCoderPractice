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

		public static void TakahashiAoki()
		{
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());

			long answer = 0;
			for (long i = n; i < int.MaxValue; ++i) {
				if (i % a == 0 && i % b == 0) {
					answer = i;
					break;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void Ongaku()
		{
			int n = int.Parse(Console.ReadLine());
			var x = new List<char[]>();

			var count = 0;

			for (var i = 0; i < n; i++) {
				var s = Console.ReadLine();
				var array = s.ToCharArray();
				count += array.Count(c => c == 'x');
				x.Add(array);
			}

			// 長押し箇所を探す
			for (var j = 0; j < 9; ++j) {
				bool starts = false;
				for (var i = 0; i < n; ++i) {
					if (x[i][j] == 'o') {
						if (starts == false) {
							starts = true;
							++count;
							continue;
						}
					}

					if (x[i][j] != 'o') {
						if (starts) {
							starts = false;
						}
					}
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void RedundantRedundancy()
		{
			int n = int.Parse(Console.ReadLine());
			long value = 2;
			for (long i = 3; i <= n; ++i) {
				value = Lcm(i, value);
			}

			long answer = value + 1;
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
	}
}

