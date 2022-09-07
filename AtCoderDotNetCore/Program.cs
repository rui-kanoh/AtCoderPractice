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
		public static void Exec()
		{
			ExecTemp();
		}

		public static void ExecTemp()
		{
			long n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var dict = new Dictionary<long, long[]>();
			for (var i = 0; i < n; ++i) {
				if (dict.ContainsKey(a[i]) == false) {
					var array = new long[n];
					array[i] = 1;
					dict.Add(a[i], array);
				} else {
					dict[a[i]][i] = 1;
				}
			}

			for (var i = 0; i < dict.Count; ++i) {
				var rui = new long[n + 1];
				rui[0] = 0;
				for (var j = 0; j < n; ++j) {
					rui[j + 1] = rui[j] + dict.ElementAt(i).Value[j];
				}

				var key = dict.ElementAt(i).Key;
				dict[key] = rui;
			}

			var builder = new StringBuilder();

			long q = long.Parse(Console.ReadLine());
			for (var i = 0; i < q; ++i) {
				var lrx = Console.ReadLine().Split(" ").Select(j => int.Parse(j)).ToArray();
				var l = lrx[0] - 1;
				var r = lrx[1] - 1;
				var x = lrx[2];

				long count = 0;
				if (dict.ContainsKey(x) == false) {
					count = 0;
				} else {
					count = dict[x][r] - dict[x][l];
				}

				builder.AppendLine($"{count}");
			}

			var answer = builder.ToString();
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

		public static void NotFound()
		{
			string s = Console.ReadLine();

			char answer = (char)0;
			for (var i = 0; i < 26; i++) {
				char c = (char)('a' + (char)i);
				if (s.Contains(c) == false) {
					answer = c;
					break;
				}
			}

			if (answer == (char)0) {
				Console.WriteLine($"None");
			} else {
				Console.WriteLine($"{answer}");
			}
		}

			public static void Shoes()
		{
			var lr = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var l = lr[0];
			var r = lr[1];
			var larray = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			var rarray = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			larray.Sort();
			rarray.Sort();

			int count = 0;
			int nexti = 0;
			int nextj = 0;
			for (var i = nexti; i < larray.Count; ++i) {
				bool isFound = false;
				for (var j = nextj; j < rarray.Count; ++j) {
					if (larray[i] == rarray[j]) {
						++count;
						nexti = i + 1;
						nextj = j + 1;
						isFound = true;
						break;
					}
				}

				if (isFound) {
					continue;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Mujin()
		{
			string s = Console.ReadLine();
			if (s == "O" || s == "P" || s == "K" || s == "L") {
				Console.WriteLine($"Right");
			} else {
				Console.WriteLine($"Left");
			}
		}

		public static void Kaiten()
		{
			var strs = new string[4, 4];
			for (var i = 0; i < 4; i++) {
				string[] array = Console.ReadLine().Split(" ");
				for (var j = 0; j < 4; ++j) {
					strs[i, j] = array[j];
				}
			}

			var builder = new StringBuilder();
			for (var i = 0; i < 4; ++i) {
				for (var j = 0; j < 4; ++j) {
					string s = strs[3 - i, 3 - j];
					if (j < 3) {
						builder.Append($"{s} ");
					} else {
						builder.AppendLine($"{s}");
					}
				}
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
		}

		public static void ChangingJewel()
		{
			var nxy = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nxy[0] - 1;
			var x = nxy[1];
			var y = nxy[2];

			if (n == 0) {
				Console.WriteLine($"{0}");
				return;
			}

			var rLevelTable = new long[n + 1];
			var bLevelTable = new long[n + 1];

			rLevelTable[n] = 1;

			bool continues = true;
			while (continues) {

				bool Continues()
				{
					bool continues = false;
					for (var i = 1; i < n; ++i) {
						if (rLevelTable[i] > 0 || bLevelTable[i] > 0) {
							continues = true;
							break;
						}
					}

					return continues;
				}

				for (var i = n; i >= 1; --i) {
					rLevelTable[i - 1] += rLevelTable[i];
					bLevelTable[i] += x * rLevelTable[i];
					rLevelTable[i] = 0;
					rLevelTable[i - 1] += bLevelTable[i];
					bLevelTable[i - 1] += y * bLevelTable[i];
					bLevelTable[i] = 0;
				}

				continues = Continues();
			}

			var answer = bLevelTable[0];
			Console.WriteLine($"{answer}");
		}
	}
}

