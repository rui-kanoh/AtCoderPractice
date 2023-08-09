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

			var dict = new Dictionary<int, List<int>[]>();
			// 0をグー、1をチョキ、2をパーとする

			var ratingList = new List<int>();
			var rList = new List<int>();
			var gcpList = new List<int>();

			for (var i = 0; i < n; ++i) {
				var rh = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var r = rh[0];
				var h = rh[1] - 1;

				rList.Add(r);
				gcpList.Add(h);

				if (dict.ContainsKey(r) == false) {
					ratingList.Add(r);

					dict.Add(r, new List<int>[3]);
					for (var j = 0; j < 3; ++j) {
						dict[r][j] = new List<int>();
					}
				}

				dict[r][h].Add(i);
			}

			ratingList.Sort();

			int k = 0; // 今見ているレーティングより低い人の人数

			var result = new Dictionary<int, (int win, int lose, int draw)[]>();

			for (var i = 0; i < ratingList.Count; ++i) {
				int g = dict[ratingList[i]][0].Count;
				int c = dict[ratingList[i]][1].Count;
				int p = dict[ratingList[i]][2].Count;

				var ret = new (int win, int lose, int draw)[3];
				ret[0] = (k + c, n - k - g - c, g - 1); // g
				ret[1] = (k + p, n - k - c - p, c - 1); // c
				ret[2] = (k + g, n - k - p - g, p - 1); // p

				result.Add(ratingList[i], ret);

				k += g + c + p;
			}

			var builder = new StringBuilder();

			for (var i = 0; i < n; ++i) {
				var rating = rList[i];
				var gcp = gcpList[i];

				var ans = $"{result[rating][gcp].win} {result[rating][gcp].lose} {result[rating][gcp].draw}";
				builder.AppendLine(ans);
			}

			var answer = builder.ToString();
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

		public static void TwoDigit()
		{
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());

			var answer = a * 10 + b;
			Console.WriteLine($"{answer}");
		}

		public static void Zenkan()
		{
			var mb = new string[10];
			for (var i = 0; i < 10; ++i) {
				mb[i] = Console.ReadLine();
			}

			bool isOK = true;

			for (var i = 0; i < 10; ++i) {
				bool isOKLocal = false;
				for (var j = 0; j < 10; ++j) {
					if (mb[j][i] == 'o') {
						isOKLocal = true;
						break;
					}
				}

				if (isOKLocal == false) {
					isOK = false;
					break;
				}
			}

			var answer = isOK ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void Souwa()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var rui = new long[n + 1];
			rui[0] = 0;

			for (var i = 0; i < n; ++i) {
				rui[i + 1] = rui[i] + a[i];
			}

			/*
			for (var i = 0; i < k; ++i) {
				int index = (int)(i + k + 1);
				sum += rui[index] - rui[i];
			}

			var answer = sum;
			Console.WriteLine($"{answer}");
			*/

			long sum = rui[k];
			long temp = rui[k];
			for (var i = 0; i < n - k; ++i) {
				temp = temp - a[i] + a[k + i];
				sum += temp;
			}

			var answer = sum;
			Console.WriteLine($"{answer}");

		}
	}
}

