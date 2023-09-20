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
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];

			var pazzel = new char[h, w];

			var array = new (bool isBlock, int label)[h, w];

			for (var i = 0; i < h; ++i) {
				string s = Console.ReadLine();
				for (var j = 0; j < w; ++j) {
					pazzel[i, j] = s[j];
				}
			}


			int label = 1;
			for (var i = 0; i < h; ++i) {
				for (var j = 2; j < w; ++j) {
					if (pazzel[i, j - 2] == pazzel[i, j - 1] && pazzel[i, j - 2] == pazzel[i, j]) {

						if (array[i, j - 2].isBlock == false && array[i, j - 1].isBlock == false) {
							if (i >= 1
								&& ((array[i - 1, j - 2].isBlock && pazzel[i - 1, j - 2] == pazzel[i, j])
								|| (array[i - 1, j - 1].isBlock && pazzel[i - 1, j - 1] == pazzel[i, j])
								|| (array[i - 1, j - 0].isBlock && pazzel[i - 1, j - 0] == pazzel[i, j]))) {
								if (array[i - 1, j - 2].isBlock) {
									array[i, j - 2] = (true, array[i - 1, j - 2].label);
									array[i, j - 1] = (true, array[i - 1, j - 2].label);
									array[i, j - 0] = (true, array[i - 1, j - 2].label);
								}

								if (array[i - 1, j - 1].isBlock) {
									array[i, j - 2] = (true, array[i - 1, j - 1].label);
									array[i, j - 1] = (true, array[i - 1, j - 1].label);
									array[i, j - 0] = (true, array[i - 1, j - 1].label);
								}

								if (array[i - 1, j - 0].isBlock) {
									array[i, j - 2] = (true, array[i - 1, j - 0].label);
									array[i, j - 1] = (true, array[i - 1, j - 0].label);
									array[i, j - 0] = (true, array[i - 1, j - 0].label);
								}
							} else {
								array[i, j - 2] = (true, label);
								array[i, j - 1] = (true, label);
								array[i, j - 0] = (true, label);

								++label;
							}
						} else {
							array[i, j - 2] = (true, array[i - 1, j - 0].label);
							array[i, j - 1] = (true, array[i - 1, j - 0].label);
							array[i, j - 0] = (true, array[i - 1, j - 0].label);
						}
					}
				}
			}

			for (var i = 0; i < h; ++i) {
				for (var j = 0; j < w; ++j) {
					Console.Write($"{array[i, j].label} ");
				}

				Console.WriteLine($"");
			}

			Console.WriteLine($"");

			for (var j = 0; j < w; ++j) {
				for (var i = 2; i < h; ++i) {
					if (pazzel[i - 2, j] == pazzel[i - 1, j] && pazzel[i - 2, j] == pazzel[i, j]) {
						if (array[i - 2, j].isBlock == false && array[i - 1, j].isBlock == false && array[i, j].isBlock == false) {
							array[i - 2, j] = (true, label);
							array[i - 1, j] = (true, label);
							array[i - 0, j] = (true, label);

							++label;
						} else {
							if (array[i - 2, j].isBlock) {
								array[i - 1, j] = (true, array[i - 2, j].label);
								array[i - 0, j] = (true, array[i - 2, j].label);
							}

							if (array[i - 1, j].isBlock) {
								array[i - 2, j] = (true, array[i - 1, j].label);
								array[i - 0, j] = (true, array[i - 1, j].label);
							}

							if (array[i, j].isBlock) {
								array[i - 2, j] = (true, array[i - 0, j].label);
								array[i - 1, j] = (true, array[i - 0, j].label);
							}
						}
					}
				}
			}

			for (var i = 0; i < h; ++i) {
				for (var j = 0; j < w; ++j) {
					Console.Write($"{array[i, j].label} ");
				}

				Console.WriteLine($"");
			}

			var answer = label - 1;
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

		public static void i18n()
		{
			string s = Console.ReadLine();
			var answer = $"{s[0]}{s.Length - 2}{s[s.Length - 1]}";
			Console.WriteLine($"{answer}");
		}

		public static void Fox()
		{
			int n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();

			var builder = new StringBuilder();
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] is not 'f' and not 'o' and not 'x') {
					builder.Append('?');
				} else {
					builder.Append(s[i]);
				}
			}

			s = builder.ToString();

			var hash = s.ToCharArray().ToHashSet();

			while (hash.Contains('f') && hash.Contains('o') && hash.Contains('x')) {
				s = s.Replace("fox", "");

				hash = s.ToCharArray().ToHashSet();
			}

			var answer = s.Length;
			Console.WriteLine($"{answer}");
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

