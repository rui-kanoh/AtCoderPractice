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
			Annaijo();
		}

		public static void Annaijo()
		{
			var nmq = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nmq[0];
			var m = nmq[1];
			var q = nmq[2];

			var slist = new List<string>();
			var indexList = new int[n];
			for (var i = 0; i < n; ++i) {
				string s = Console.ReadLine();
				var item = s.Where(c => c != '*').ToArray();
				if (item != null && item.Any()) {
					string str = new string(item);
					int index = s.IndexOf(str);
					slist.Add(str);
					indexList[i] = index + 1;
				} else {
					slist.Add("*");
				}
			}

			var builder = new StringBuilder();

			for (var i = 0; i < q; ++i) {
				string qq = Console.ReadLine();
				if (slist.Contains(qq)) {
					int index = slist.IndexOf(qq);
					builder.AppendLine($"{index + 1} {indexList[index]}");
				} else {
					builder.AppendLine("NA");
				}
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

		public static void MaximumDiff()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			long max = 0;
			for (var i = 0; i < n; ++i) {
				for (var j = 0; j < n; ++j) {
					if (i == j) {
						continue;
					}

					max = Math.Max(max, Math.Abs(a[i] - a[j]));
				}
			}

			var answer = max;

			Console.WriteLine($"{answer}");
		}

		public static void ChooseElement()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			bool isOK = false;

			var dp = new bool[n + 1, 2];
			for (int i = 0; i <= n; ++i) {
				dp[i, 0] = false;
				dp[i, 1] = false;
			}

			dp[0, 0] = true;
			dp[0, 1] = true;

			for (int i = 0; i < n; ++i) {
				if (i < n - 1) {
					if (dp[i, 0]) {
						dp[i + 1, 0] = Math.Abs(a[i] - a[i + 1]) <= k;
						dp[i + 1, 1] = Math.Abs(a[i] - b[i + 1]) <= k;
					}

					if (dp[i, 1]) {
						dp[i + 1, 0] = dp[i + 1, 0] || Math.Abs(b[i] - a[i + 1]) <= k;
						dp[i + 1, 1] = dp[i + 1, 1] || Math.Abs(b[i] - b[i + 1]) <= k;
					}
				}
			}

			isOK = dp[n - 1, 0] || dp[n - 1, 1];

			var answer = isOK ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}
	}
}

