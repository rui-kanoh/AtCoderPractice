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

		public static void ExecTemp()
		{
			int n = int.Parse(Console.ReadLine());
			string s1 = Console.ReadLine();
			string s2 = Console.ReadLine();

			var count = (long)0;

			var dict = new Dictionary<char, int>();
			for (var i = 0; i < n; ++i) {
				if (char.IsNumber(s1[i])) {
					if (char.IsNumber(s2[i]) == false) {
						if (dict.ContainsKey(s2[i]) == false) {
							dict.Add(s2[i], 1);
						} else {
							++dict[s2[i]];
						}
					}
				} else {
					if (dict.ContainsKey(s1[i]) == false) {
						dict.Add(s1[i], 1);
					} else {
						++dict[s1[i]];
					}
				}
			}

			var answer = count;
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

