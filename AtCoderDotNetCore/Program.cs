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
			var n = int.Parse(Console.ReadLine());

			var snames = new HashSet<string>();
			var tnames = new string[n];
			for (var i = 0; i < n; ++i) {
				string[] st = Console.ReadLine().Split(" ");
				snames.Add(st[0]);
				tnames[i] = st[1];
			}

			bool isOK = false;

			for (var i = 0; i < n; ++i) {
				if (snames.Contains(tnames[i]) == false) {
					isOK = true;
					break;
				}
			}

			var answer = isOK ? "Yes" : "No";
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

		public static void A()
		{
			char X = char.Parse(Console.ReadLine());

			var answer = X - 'A' + 1;
			Console.WriteLine($"{answer}");
		}

		public static void CountingRoads()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var lists = new int[n];

			for (var i = 0; i < m; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				++lists[a];
				++lists[b];
			}

			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				builder.AppendLine($"{lists[i]}");
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
		}
	}
}

