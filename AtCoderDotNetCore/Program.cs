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

		public static void Parking()
		{
			var nab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nab[0];
			var a = nab[1];
			var b = nab[2];

			var answer = Math.Min(a * n, b);
			Console.WriteLine($"{answer}");
		}

		public static void Heiho()
		{
			int n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();

			if (IsOdd(n)) {
				Console.WriteLine($"-1");
				return;
			}

			int half = s.Length / 2;
			int count = 0;
			for (var i = 0; i < half; ++i) {
				if (s[i] != s[half + i]) {
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Friends()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var union = new Lib.UnionFind(n);
			for (var j = 0; j < m; ++j) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				union.Union(a, b);
			}

			int count = union.GroupCount;

			int max = 0;
			for (var i = 0; i < count; ++i) {
				max = Math.Max(max, union.Count(i));
			}

			var answer = max;
			Console.WriteLine($"{answer}");
		}
	}
}

