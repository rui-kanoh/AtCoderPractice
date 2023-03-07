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
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var clist = new char[h, w];
			for (var i = 0; i < w; ++i) {
				string s = Console.ReadLine();
				for (var j = 0; j < s.Length; ++j) {
					clist[j, i] = s[j];
				}
			}

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

		public static void MaximumSum()
		{
			var abc = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];
			var k = int.Parse(Console.ReadLine());

			var list = abc.ToList();
			list.Sort();
			var max = list[2];
			max = (max << k);

			var answer = list[0] + list[1] + max;
			Console.WriteLine($"{answer}");
		}

		public static void Rectangle()
		{
			var wab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var w = wab[0];
			var a = wab[1];
			var b = wab[2];

			var answer = 0;

			if (a < b) {
				if (b > a + w) {
					answer = b - (a + w);
				} else {
					answer = 0;
				}
			} else {
				if (a > b + w) {
					answer = a - (b + w);
				} else {
					answer = 0;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void WaterOnBottle()
		{
			var abx = Console.ReadLine().Split(" ").Select(i => double.Parse(i)).ToArray();
			var a = abx[0];
			var b = abx[1];
			var x = abx[2];

			var area = a * a * b;

			if (area == x) {
				Console.WriteLine("0");
			} else {
				if (area - x > x) {
					if (area / 2.0 <= x) {
						var theta = Math.Atan((2.0 * x) / (a * a * a)) * 180.0 / Math.PI;
						var answer = theta;
						Console.WriteLine($"{answer}");
					} else {
						var theta = Math.Atan((2.0 * x) / (a * b * b)) * 180.0 / Math.PI;
						var answer = 90.0 - theta;
						Console.WriteLine($"{answer}");
					}
				} else {
					var theta = Math.Atan(a * a * a / (2.0 * (area - x))) * 180.0 / Math.PI;
					var answer = 90.0 - theta;
					Console.WriteLine($"{answer}");
				}
			}
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

		public static void D()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			var dict = new Dictionary<long, long>();

			var wlist = new List<long>();
			var dlist = new long[n];

			for (var i = 0; i < n; ++i) {
				var wd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var w = nk[0] - 1;
				var d = nk[1];

				wlist.Add(w);
				dlist[i] = d;
			}

			wlist.Sort();

			long count = 0;
			while (count < k) {

				if (k >= count) {
					break;
				}
			}


			long x = -1;
			foreach (var item in dict) {
				count += item.Value;
				if (count >= k) {
					x = item.Key;
					break;
				}
			}

			var answer = x;
			Console.WriteLine($"{answer}");
		}

	}
}

