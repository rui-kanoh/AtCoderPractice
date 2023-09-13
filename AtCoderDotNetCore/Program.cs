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
using System.ComponentModel.Design;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace AtCoderDotNetCore
{
	class Program
	{
		static void Main(string[] args)
		{
			Question.Exec();
		}
	}

	public class UnionFind
	{
		List<int> parents;

		public int GroupCount { get; private set; }

		public UnionFind(int x)
		{
			parents = Enumerable.Repeat(-1, x).ToList();
			GroupCount = x;
		}

		public int Find(int x)
		{
			if (parents[x] < 0) return x;
			else {
				parents[x] = Find(parents[x]);
				return parents[x];
			}
		}

		public void Union(int x, int y)
		{
			(x, y) = (Find(x), Find(y));

			if (x != y) {
				if (Count(x) < Count(y)) (x, y) = (y, x);
				parents[x] += parents[y];
				parents[y] = x;
				GroupCount--;
			}
		}

		public int Count(int x) => -parents[Find(x)];

		public bool IsSame(int x, int y) => Find(x) == Find(y);
	}

	public static class Question
	{
		public static void Exec()
		{
			ExecTemp();
		}

		public static void ExecTemp()
		{
			long n = long.Parse(Console.ReadLine());

			long count = 0;

			var hash = new HashSet<long>();

			for (var a = 2; a <= 10; ++a) {
				for (var b = 2; b <= 10; ++b) {
					long value = a;
					for (var i = 0; i < b; ++i) {
						value *= a;
					}

					if (value > n) {
						continue;
					}

					if (hash.Contains(value) == false) {
						++count;

						hash.Add(value);
					}
				}
			}

			var answer = n - count;
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

		public static void TaskScheduling()
		{
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			a.Sort();

			var answer = Math.Abs(a[1] - a[0]) + Math.Abs(a[2] - a[1]);
			Console.WriteLine($"{answer}");
		}

		public static void SportsDay()
		{
			int n = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();

			bool isRed = true;

			int count = 0;
			for (var i = 0; i < n - 1; ++i) {
				if (s[i] == 'R') {
					++count;

					if (count == k) {
						isRed = false;
						break;
					}
				}
			}

			var answer = isRed ? "R" : "W";
			Console.WriteLine($"{answer}");
		}

		public static void Unexpressed()
		{
			long n = long.Parse(Console.ReadLine());

			// n - (a^b で表せるもの）が答え
			// b = 2 で固定すると aはSQRT(N)まででよい。

			long count = 0;

			var hash = new HashSet<long>();

			// b = 2
			for (var a = 2; a * a <= n; ++a) {
				long value = a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}

			// b = 3
			for (var a = 2; a * a * a <= n; ++a) {
				long value = a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}

			/*
			// b = 4
			for (var a = 2; a * a * a * a <= n; ++a) {
				long value = a * a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}
			*/

			// b = 5
			for (var a = 2; a * a * a * a * a <= n; ++a) {
				long value = a * a * a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}

			// b = 6
			for (var a = 2; a * a * a * a * a * a <= n; ++a) {
				long value = a * a * a * a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}

			// b = 7
			for (var a = 2; a * a * a * a * a * a * a <= n; ++a) {
				long value = a * a * a * a * a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}

			/*
			// b = 8
			for (var a = 2; a * a * a * a * a * a * a * a <= n; ++a) {
				long value = a * a * a * a * a * a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}

			// b = 9
			for (var a = 2; a * a * a * a * a * a * a * a * a<= n; ++a) {
				long value = a * a * a * a * a * a * a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}
			*/

			// b = 10
			for (var a = 2; a * a * a * a * a * a * a * a * a * a <= n; ++a) {
				long value = a * a * a * a * a * a * a * a * a * a;

				if (hash.Contains(value) == false) {
					++count;

					hash.Add(value);
				}
			}

			var answer = n - count;
			Console.WriteLine($"{answer}");
		}
	}
}

