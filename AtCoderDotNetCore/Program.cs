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

		public static long CalcTotal(long d)
		{
			return d * (d + 1) / 2;
		}

		public static void FizzBuzzSumHard()
		{
			var nab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nab[0];
			var a = nab[1];
			var b = nab[2];
			var ab = Lcm(a, b);
			var total = CalcTotal(n);
			var countA = n / a;
			var setA = CalcTotal(countA) * a;
			var countB = n / b;
			var setB = CalcTotal(countB) * b;
			var countAB = n / ab;
			var setAB = CalcTotal(countAB) * ab;
			var setAorB = setA + setB - setAB;

			var answer = total - setAorB;

			Console.WriteLine($"{answer}");
		}

		public static void NazoX()
		{
			var rcd = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var r = rcd[0];
			var c = rcd[1];
			var d = rcd[2];

			var mat = new int[r, c];

			for (var i = 0; i < r; ++i) {
				var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				for (var j = 0; j < c; ++j) {
					mat[i, j] = a[j];
				}
			}

			var max = 0;
			bool dIsOdd = IsOdd(d);
			for (var i = 0; i < r; ++i) {
				for (var j = 0; j < c; ++j) {
					if (i + j <= d && dIsOdd == IsOdd(i + j)) {
						max = Math.Max(max, mat[i, j]);
					}
				}
			}

			var answer = max;
			Console.WriteLine($"{answer}");
		}
	}
}

