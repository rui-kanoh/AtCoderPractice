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
			var hwn = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hwn[0];
			var w = hwn[1];
			var n = hwn[2];

			var rows = new int[h];
			var cols = new int[w];
			var dict = new (int a, int b)[n];

			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				dict[i] = (a, b);

				rows[a] = 1;
				cols[b] = 1;
			}

			var ruiRows = new int[h];
			for (var i = 0; i < h; ++i) {
				if (i == 0) {
					ruiRows[i] = rows[i];
				} else {
					ruiRows[i] = rows[i] + ruiRows[i - 1];
				}
			}

			var ruiCols = new int[w];
			for (var i = 0; i < w; ++i) {
				if (i == 0) {
					ruiCols[i] = cols[i];
				} else {
					ruiCols[i] = cols[i] + ruiCols[i - 1];
				}
			}

			var buider = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				(var r, var c) = dict[i];

				int indexR = r == ruiRows.Length - 1 ? ruiRows.Length - 1 : r;
				var numR = ruiRows[indexR];

				int indexC = c == ruiCols.Length - 1 ? ruiCols.Length - 1 : c;
				var numC = ruiCols[indexC];

				buider.AppendLine($"{numR} {numC}");
			}


			var answer = buider.ToString();
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

		public static void Same()
		{
			string s = Console.ReadLine();
			var answer = (s[0] == s[1] && s[1] == s[2] && s[2] == s[3]) ? "SAME" : "DIFFERENT";
			Console.WriteLine($"{answer}");
		}

		public static void Syoritsu()
		{
			var abcd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abcd[0];
			var b = abcd[1];
			var c = abcd[2];
			var d = abcd[3];
			var lcm = Lcm(a, c);

			long temp = lcm / a;
			long taka = b * temp;
			temp = lcm / c;
			long aoki = d * temp;
			if (taka == aoki) {
				Console.WriteLine($"DRAW");
			} else {
				if (taka > aoki) {
					Console.WriteLine($"TAKAHASHI");
				} else {
					Console.WriteLine($"AOKI");
				}
			}
		}

		public static void SnakeToy()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var l = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			l.Sort((a, b) => b.CompareTo(a));

			int count = 0;
			for (var i = 0; i < k; ++i) {
				count += l[i];
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Celcius()
		{
			int n = int.Parse(Console.ReadLine());

			var answer = (9.0 / 5.0 * n) + 32.0;
			Console.WriteLine($"{answer}");
		}

		public static void KenkenRace()
		{
			var nabcd = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nabcd[0];
			var a = nabcd[1] - 1;
			var b = nabcd[2] - 1;
			var c = nabcd[3] - 1;
			var d = nabcd[4] - 1;
			string s = Console.ReadLine();
			var mass = new bool[s.Length];

			bool isOK = true;
			for (var i = 0; i < s.Length; ++i) {
				mass[i] = s[i] == '.';

				if ((i == c || i == d) && mass[i] == false) {
					isOK = false;
					break;
				}

				if (i > 0 && i >= a && i <= d) {
					if (mass[i - 1] == false && mass[i] == false) {
						isOK = false;
						break;
					}
				}
			}

			if (isOK) {
				if (c < d) {
					isOK = true;
				} else {
					bool exists3blank = false;
					for (var i = b; i <= d; ++i) {
						if (i > 1
							&& i < s.Length - 1
							&& exists3blank == false) {
							if (mass[i - 1] && mass[i] && mass[i + 1]) {
								exists3blank = true;
								break;
							}
						}
					}

					isOK = exists3blank;
				}
			}

			var answer = isOK ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void FriendsFriend()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var lists = new HashSet<int>[n];
			for (var i = 0; i < n; ++i) {
				lists[i] = new HashSet<int>();
			}

			for (var i = 0; i < m; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				lists[a].Add(b);
				lists[b].Add(a);
			}

			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				var hash = new HashSet<int>();
				foreach (var item in lists[i]) {
					foreach (var item2 in lists[item]) {
						if (hash.Contains(item2) == false && i != item2 && lists[i].Contains(item2) == false) {
							hash.Add(item2);
						}
					}
				}

				builder.AppendLine($"{hash.Count}");
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
		}
	}
}

