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

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void ExecTemp() {
			var xkd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var x = Math.Abs(xkd[0]); // 正の場合だけ考える
			var k = xkd[1];
			var d = xkd[2];

			var distance = (long)0;
			if (x > d) {
				// x > d の場合 なるべく0に近づくようにする |x - n * d|
				var count = x / d;
				if (count <= k) {
					var dist1 = x % d;
					if (IsOdd(k - count) == false) {
						distance = Math.Abs(dist1);
					} else {
						distance = Math.Abs(dist1 - d);
					}
				} else {
					distance = Math.Abs(x - (k * d));
				}
			} else {
				// x <= d の場合
				// Kが偶数なら留まる(|x|)
				// Kが奇数なら |d - x|

				if (IsOdd(k) == false) {
					distance = Math.Abs(x);
				} else {
					distance = Math.Abs(d - x);
				}
			}

			var answer = distance;
			Console.WriteLine($"{answer}");
		}
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

		public static void Restaurant()
		{
			int n = int.Parse(Console.ReadLine());
			int x = n * 800;
			int y = (n / 15) * 200;
			var answer = x - y;
			Console.WriteLine($"{answer}");
		}

		public static IReadOnlyList<T[]> AllPermutation<T>(params T[] array) where T : IComparable
		{
			var a = new List<T>(array).ToArray();
			var res = new List<T[]>();
			res.Add(new List<T>(a).ToArray());
			var n = a.Length;
			var next = true;
			while (next) {
				next = false;

				// 1
				int i;
				for (i = n - 2; i >= 0; i--) {
					if (a[i].CompareTo(a[i + 1]) < 0) break;
				}
				// 2
				if (i < 0) break;

				// 3
				var j = n;
				do {
					j--;
				} while (a[i].CompareTo(a[j]) > 0);

				if (a[i].CompareTo(a[j]) < 0) {
					// 4
					var tmp = a[i];
					a[i] = a[j];
					a[j] = tmp;
					Array.Reverse(a, i + 1, n - i - 1);
					res.Add(new List<T>(a).ToArray());
					next = true;
				}
			}
			return res;
		}

		public static void Chairの適切な解()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = new int[] { ab[0], ab[1], ab[2], };
			var b = new int[] { ab[3], ab[4], ab[5], };

			var items = AllPermutation(new[] { 0, 1, 2 });
			var min = int.MaxValue;
			foreach (var item in items) {
				var dist = Math.Abs(a[0] - b[item[0]]) + Math.Abs(a[1] - b[item[1]]) + Math.Abs(a[2] - b[item[2]]);
				min = Math.Min(min, dist);
			}

			var answer = min;
			Console.WriteLine($"{answer}");
		}

		public static void Chair()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = new int[] { ab[0], ab[1], ab[2], }.ToList();
			var b = new int[] { ab[3], ab[4], ab[5], }.ToList();

			a.Sort();
			b.Sort();
			var min = Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]) + Math.Abs(a[2] - b[2]);

			var answer = min;
			Console.WriteLine($"{answer}");
		}

		public static bool IsOdd(BigInteger n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static BigInteger Abs(BigInteger value)
		{
			return value >= 0 ? value : -1 * value;
		}

		public static void WalkingTakahashi()
		{
			var xkd = Console.ReadLine().Split(" ").Select(i => BigInteger.Parse(i)).ToArray();
			var x = Abs(xkd[0]); // 正の場合だけ考える
			var k = xkd[1];
			var d = xkd[2];

			var distance = (BigInteger)0;
			if (x > d) {
				// x > d の場合 なるべく0に近づくようにする |x - n * d|
				var count = x / d;
				if (count <= k) {
					var dist1 = x % d;
					if (IsOdd(k - count) == false) {
						distance = Abs(dist1);
					} else {
						distance = Abs(dist1 - d);
					}
				} else {
					distance = Abs(x - (k * d));
				}
			} else {
				// x <= d の場合
				// Kが偶数なら留まる(|x|)
				// Kが奇数なら |d - x|

				if (IsOdd(k) == false) {
					distance = Abs(x);
				} else {
					distance = Abs(d - x);
				}
			}

			var answer = distance;
			Console.WriteLine($"{answer}");
		}
	}
}

