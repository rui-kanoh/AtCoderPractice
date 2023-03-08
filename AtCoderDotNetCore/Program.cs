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
			int n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();
			var clist = s.ToCharArray().ToList();

			if (n == 1) {
				Console.WriteLine($"0");
				return;
			}

			// 後ろから見て行って01が連続したらRemove
			// 残ったものの個数/2が答え
			bool canRemove = true;
			for (var i = 1; i < 2 * n; ++i) {
				int index = 2 * n - 1 - i;
				if (clist.Count > index + 1) {
					if (clist[index] != clist[index + 1]) {
						if (canRemove) {
							clist.RemoveAt(index + 1);
							clist.RemoveAt(index);
							canRemove = false;
							continue;
						}
					}
				}

				if (canRemove == false) {
					canRemove = true;
				}
			}

			var answer = clist.Count / 2;
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

		public static void HD()
		{
			string[] ab = Console.ReadLine().Split(" ");

			var answer = (ab[0] == "H" && ab[1] == "H") || (ab[0] == "D" && ab[1] == "D")
				? "H"
				: "D";
			Console.WriteLine($"{answer}");
		}

		public static void CollectingBalls()
		{
			int n = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());
			var x = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			long total = 0;
			for (var i = 0; i < n; ++i) {
				total += Math.Min(x[i], Math.Abs(k - x[i])) * 2;
			}

			var answer = total;
			Console.WriteLine($"{answer}");
		}

		public static void Dangeras()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var list = new HashSet<int>[m];
			for (var i = 0; i < m; ++i) {
				var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				list[i] = new HashSet<int> {
					abc[0] - 1,
					abc[1] - 1,
					abc[2] - 1,
				};
			}

			if (n == 3 || m == 1) {
				Console.WriteLine("1");
				return;
			}

			long max = 0;
			for (var i = 0; i < n; ++i) {
				for (var j = i + 1; j < n; ++j) {
					if (i == j) {
						continue;
					}

					var hash = new HashSet<int>();
					foreach (var item in list) {
						if (item.Contains(i) && item.Contains(j)) {
							int k = -1;
							if (item.ElementAt(0) == i && item.ElementAt(1) == j) {
								k = item.ElementAt(2);
							} else {
								if (item.ElementAt(0) == i && item.ElementAt(2) == j) {
									k = item.ElementAt(1);
								} else {
									k = item.ElementAt(0);
								}
							}

							if (hash.Contains(k) == false) {
								hash.Add(k);
							}
						}
					}

					max = Math.Max(max, hash.Count);
				}
			}

			var answer = max;

			Console.WriteLine($"{answer}");
		}
	}
}

