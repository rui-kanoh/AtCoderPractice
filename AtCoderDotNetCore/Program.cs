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
		public static void ExecTemp()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var alist = new List<long>();
			var dlist = new List<long>();

			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				alist.Add(ab[0]);
			}

			for (var i = 0; i < m; ++i) {
				var cd = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				dlist.Add(cd[1]);
			}

			alist.Sort((a, b) => b.CompareTo(a));
			dlist.Sort((a, b) => b.CompareTo(a));

			while (alist.Any() && dlist.Any() && alist.First() < dlist.First()) {
				dlist.RemoveAt(0);
			}

			long min = Math.Min(alist.Count, dlist.Count);
			long count = 0;
			for (var i = 0; i < min; ++i) {
				if (alist[i] < dlist[i]) {
					break;
				}

				++count;
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Exec()
		{
			ExecTemp();
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

		public static bool IsPrime(long num)
		{
			if (num < 2) return false;
			else if (num == 2) return true;
			else if (num % 2 == 0) return false;

			double sqrtNum = Math.Sqrt(num);
			for (int i = 3; i <= sqrtNum; i += 2) {
				if (num % i == 0) {
					// 素数ではない
					return false;
				}
			}

			// 素数である
			return true;
		}

		public static void CountPrime()
		{
			var n = long.Parse(Console.ReadLine());

			int count = 0;
			for (var i = 1; i < n; ++i) {
				if (IsPrime(i)) {
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Weekend()
		{
			string s = Console.ReadLine();
			var answer = 0;
			switch (s) {
				case "Monday":
					answer = 5;
					break;

				case "Tuesday":
					answer = 4;
					break;

				case "Wednesday":
					answer = 3;
					break;

				case "Thursday":
					answer = 2;
					break;

				case "Friday":
					answer = 1;
					break;

				case "Saturday":
				case "Sunday":
				default:
					break;
			}


			Console.WriteLine($"{answer}");
		}

		public static void OneReverse()
		{
			string s = Console.ReadLine();
			int count = 0;

			if (s.Contains('W') == false || s.Contains('B') == false) {
				count = 0;
			} else {
				var union = new Lib.UnionFind(s.Length);

				for (var i = 1; i < s.Length; ++i) {
					if (s[i] == s[i - 1]) {
						union.Union(i - 1, i);
					}
				}

				count = union.GroupCount - 1;
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}
	}
}

