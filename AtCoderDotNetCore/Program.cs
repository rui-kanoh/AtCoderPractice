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

		public static bool Check(int value, int[] list)
		{
			var num = list.Distinct().Count(x => x <= value);
			var amari = list.Length - num;
			bool isOK = value <= num + (amari / 2); 

			return isOK;
		}

		public static (int ok, int ng) BinarySearch(int[] list)
		{
			int ok = 0;
			int ng = list.Length;
			while (ng - ok > 1) {
				int mid = (ng + ok) / 2;
				if (Check(mid, list)) {
					ok = mid;
				} else {
					ng = mid;
				}
			}

			return (ok, ng);
		}

		public static void ExecTemp()
		{
			long n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			(int ok, int ng) = BinarySearch(a);

			var answer = ok;
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

		public static void Exec229()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];
			long count = (b / 4) - (b / 100) + (b / 400);
			count -= ((a - 1) / 4) - ((a - 1) / 100) + ((a - 1) / 400);

			// 愚直になげるとTLE
			/*
			for (long i = a; i <= b; ++i) {
				if (i % 4 == 0 && (i % 100 != 0 || i % 400 == 0)) {
					++count;
				}
			}
			*/

			var answer = count;
			Console.Write($"{answer}");
		}
	}
}

