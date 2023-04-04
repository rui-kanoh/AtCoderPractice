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
			// メモ化再帰
			var memo = new Dictionary<long, long>();

			long Func2(long n)
			{
				if (n == 0) {
					return 1;
				} else {
					if (memo.ContainsKey(n) == false) {
						var ret = Func2(n / 2) + Func2(n / 3);
						memo.Add(n, ret);
						return ret;
					} else {
						return memo[n];
					}
				}
			}

			var n = long.Parse(Console.ReadLine());

			// log2(10^18) = 120 なので最大120回もぐればOK

			var answer = Func2(n);
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

		public static void TwoChar()
		{
			string s = Console.ReadLine();
			var answer = s.Length == 2
				? s
				: new string(s.Reverse().ToArray());
			Console.WriteLine($"{answer}");
		}

		public static void NextChar()
		{
			int n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();
			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				if (i > 0 && s[i] == 'J') {
					builder.AppendLine($"{s[i - 1]}");
				}
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
		}
	}
}

