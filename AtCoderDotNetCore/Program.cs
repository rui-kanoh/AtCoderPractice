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
			var nml = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nml[0];
			var m = nml[1];
			var l = nml[2];

			var ablist = new List<(int a, int b)>();
			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0];
				var b = ab[1];
				ablist.Add((a, b));
			}

			var cdlist = new List<(int c, int d)>();
			for (var i = 0; i < m; ++i) {
				var cd= Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var c = cd[0];
				var d = cd[1];
				cdlist.Add((c, d));
			}

			long max = 0;

			var dp = new long[m + 1, l + 1];
			for (var j = 0; j <= m; ++j) {
				for (var k = 0; k <= l; ++k) {
					dp[j, k] = -1;
				}
			}

			dp[0, 0] = 0;
			for (var j = 0; j < m; ++j) {
				for (var k = 0; k <= l; ++k) {
					if (dp[j, k] != -1) {
						dp[j + 1, k] = Math.Max(dp[j + 1, k], dp[j, k]);
						if (k + cdlist[j].c <= l) {
							dp[j + 1, k + cdlist[j].c] = Math.Max(dp[j + 1, k + cdlist[j].c], dp[j, k] + cdlist[j].d);
						}
					}
				}
			}

			// dp[m, k]について累積max
			var ruiMax = new long[l + 1];
			ruiMax[0] = 0;
			for (var k = 0; k < l; ++k) {
				ruiMax[k + 1] = Math.Max(ruiMax[k], dp[m, k]);
			}

			for (var i = 0; i < n; ++i) {
				long cost = ablist[i].a;
				if (cost >= l) {
					continue;
				}

				int costMax = l - ablist[i].a;

				// 0から順じゃなくて、コストが最大になるように選ぶ
				// 1000個あるので全探索はできない
				// cdについてDPで最大評価の物を見つける
				max = Math.Max(max, ruiMax[costMax + 1] + ablist[i].b);
			}

			var answer = max;
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

		public static void AntBug()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];

			var answer = "Draw";

			if (Math.Abs(a) > Math.Abs(b)) {
				answer = "Bug";
			} else if (Math.Abs(a) < Math.Abs(b)) {
				answer = "Ant";
			}

			Console.WriteLine($"{answer}");
		}

		public static void TakahashiAverage()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var list = a.Where(x => x > 0).ToList();
			double average = Math.Ceiling(list.Average());

			var answer = $"{average:f0}";
			Console.WriteLine($"{answer}");
		}

		public static void StringFormation()
		{
			string s = Console.ReadLine();
			var q = int.Parse(Console.ReadLine());
			var deq = new Deque.Deque<char>(s.Length + q);
			for (var i = 0; i < s.Length; ++i) {
				deq.PushBack(s[i]);
			}

			int rotationCount = 0;
			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ");
				if (query[0] == "1") {
					++rotationCount;
				} else {
					var f = query[1];
					var c = query[2];
					if (f == "1") {
						if (IsOdd(rotationCount) == false) {
							deq.PushFront(c[0]);
						} else {
							deq.PushBack(c[0]);
						}
					} else {
						if (IsOdd(rotationCount) == false) {
							deq.PushBack(c[0]);
						} else {
							deq.PushFront(c[0]);
						}
					}
				}
			}

			var builder = new StringBuilder();
			for (var i = 0; i < deq.Length; ++i) {
				if (IsOdd(rotationCount) == false) {
					builder.Append(deq[i]);
				} else {
					builder.Append(deq[deq.Length - 1 - i]);
				}
			}

			var answer = builder.ToString();
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
	}
}

