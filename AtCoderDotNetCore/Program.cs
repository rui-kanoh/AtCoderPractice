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
			var nm = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var sushi = new long[n];
			var list = new long[m];

			for (int i = 0; i < list.Length; i++) {
				list[i] = -1;
			}

			for (int i = 0; i < sushi.Length; i++) {
				sushi[i] = -1;
			}

			for (int j = 0; j < m; ++j) {
				for (int i = 0; i < n; ++i) {
					if (sushi[i] == -1 || sushi[i] < a[j]) {
						sushi[i] = a[j];
						list[j] = i + 1;
						break;
					}
				}
			}

			var builder = new StringBuilder();
			for (int i = 0; i < list.Length; ++i) {
				builder.AppendLine($"{list[i]}");
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
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

		public static void Eating()
		{
			string s = Console.ReadLine();

			var answer = 0;
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] == '+') {
					++answer;
				} else {
					--answer;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void TakahashiOtsukai()
		{
			int n = int.Parse(Console.ReadLine());

			int count = 0;
			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				count += ab[0] * ab[1];
			}

			count = (int)Math.Floor(count * 1.05);

			var answer = count;
			Console.WriteLine($"{answer}");
		}
	}
}

