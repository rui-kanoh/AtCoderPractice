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

		public static void ExecTemp()
		{
			var x = int.Parse(Console.ReadLine());
			long a = 0;
			long b = 0;

			var answer = $"{a} {b}";
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

		public static void OddString()
		{
			string s = Console.ReadLine();
			var builder = new StringBuilder();

			for (var i = 0; i < s.Length; i = i + 2) {
				builder.Append(s[i]);
			}

			var answer = builder.ToString();
			Console.WriteLine($"{answer}");
		}

		public static void SecondHighestMountain()
		{
			int n = int.Parse(Console.ReadLine());

			var dict = new Dictionary<int, string>();
			var list = new List<int>();
			for (var i = 0; i < n; ++i) {
				var st = Console.ReadLine().Split(" ");
				var s = st[0];
				var t = int.Parse(st[1]);
				dict.Add(t, s);
				list.Add(t);
			}

			list.Sort((a, b) => b.CompareTo(a));

			var answer = dict[list[1]];

			Console.WriteLine($"{answer}");
		}

		public static void GrateOceanView()
		{
			int n = int.Parse(Console.ReadLine());
			var h = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int count = 1;

			var list = new List<int>();
			list.Add(h[0]);
			int max = h[0];

			for (var i = 1; i < n; ++i) {
				if (h[i] < max) {
					continue;
				}

				max = Math.Max(max, h[i]);

				++count;
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Game()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];

			var alist = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			var blist = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();

			//alist.Reverse();
			//blist.Reverse();

			var sunu = new List<int>();
			var sume = new List<int>();

			while (alist.Any() || blist.Any()) {
				if (alist.Any() && blist.Any()) {
					if (alist[alist.Count - 1] < blist[blist.Count - 1]) {
						sunu.Add(blist[blist.Count - 1]);
						blist.RemoveAt(blist.Count - 1);
					} else {
						sunu.Add(alist[alist.Count - 1]);
						alist.RemoveAt(alist.Count - 1);
					}
				} else {
					if (alist.Any()) {
						sunu.Add(alist[alist.Count - 1]);
						alist.RemoveAt(alist.Count - 1);
					} else if (blist.Any()) {
						sunu.Add(blist[blist.Count - 1]);
						blist.RemoveAt(blist.Count - 1);
					} else {
						break;
					}
				}

				if (alist.Any() && blist.Any()) {
					if (alist[alist.Count - 1] < blist[blist.Count - 1]) {
						sume.Add(blist[blist.Count - 1]);
						blist.RemoveAt(blist.Count - 1);
					} else {
						sume.Add(alist[alist.Count - 1]);
						alist.RemoveAt(alist.Count - 1);
					}
				} else {
					if (alist.Any()) {
						sume.Add(alist[alist.Count - 1]);
						alist.RemoveAt(alist.Count - 1);
					} else if (blist.Any()) {
						sume.Add(blist[blist.Count - 1]);
						blist.RemoveAt(blist.Count - 1);
					} else {
						break;
					}
				}
			}

			var answer = sunu.Sum();
			Console.WriteLine($"{answer}");
		}

		public static void CatAndDog()
		{
			var abx = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abx[0];
			var b = abx[1];
			var x = abx[2];

			bool isOK = a + b >= x && a <= x;

			var answer = isOK ? "YES" : "NO";
			Console.WriteLine($"{answer}");
		}

		public static void KameTuru()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];

			var answer = 4 * a + 2 * b;
			Console.WriteLine($"{answer}");
		}

		public static void Slot()
		{
			int n = int.Parse(Console.ReadLine());

			var slist = new List<string>();
			for (var i = 0; i < n; ++i) {
				string s = Console.ReadLine();
				slist.Add(s + s);
			}

			var lengthList = new Dictionary<char, int>();

			for (var k = 0; k < 10; ++k) {
				var c = slist[0][k];
				var first = k;
				var last = slist[0].LastIndexOf(c);

				for (var j = 1; j < slist.Count; ++j) {
					var first2 = slist[j].IndexOf(c);
					var last2 = slist[j].LastIndexOf(c);

					var minLength = new List<int> {
						Math.Abs(first - first2),
						Math.Abs(last - last2),
						Math.Abs(first - last2),
						Math.Abs(last - first2) }.Min();

					if (lengthList.ContainsKey(c) == false) {
						lengthList.Add(c, minLength);
					} else {
						lengthList[c] = Math.Max(lengthList[c], minLength);
					}
				}
			}

			var answer = 0;
			Console.WriteLine($"{answer}");
		}
	}
}

