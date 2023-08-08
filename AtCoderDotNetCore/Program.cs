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

			var tasks = new Dictionary<int, List<int>>();

			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				int day = ab[0] - 1;
				int point = ab[1];
				if (tasks.ContainsKey(day)) {
					tasks[day].Add(point);
				} else {
					tasks[day] = new List<int>() { point, };
				}
			}

			var points = new List<int>();

			int maxPoint = 0;
			int max = 0;
			int nextMax = 0;
			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				if (tasks.ContainsKey(i)) {
					for (var j = 0; j < tasks[i].Count; ++j) {
						if (max < tasks[i][j]) {
							nextMax = max;
							max = tasks[i][j];
						} else {
							if (nextMax == 0) {
								nextMax = tasks[i][j];
							}
						}

						points.Add(tasks[i][j]);
					}
				}

				if (points.Any()) {
					//points.Sort();
					int index = points.IndexOf(max);
					if (index != -1) {
						maxPoint += max;
						points.RemoveAt(index);
						max = nextMax;
					}
				}

				builder.AppendLine($"{maxPoint}");
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

		public static void ThreeLetter()
		{
			string[] s = Console.ReadLine().Split(" ");

			var answer = $"{s[0][0]}{s[1][0]}{s[2][0]}".ToUpper();
			Console.WriteLine($"{answer}");
		}

		public static void Gacha()
		{
			int n = int.Parse(Console.ReadLine());
			var dict = new HashSet<string>();
			for (var i = 0; i < n; ++i) {
				string s = Console.ReadLine();
				if (dict.Contains(s) == false) {
					dict.Add(s);
				}
			}

			var answer = dict.Count;
			Console.WriteLine($"{answer}");
		}

		public static void Kasaka()
		{
			string s = Console.ReadLine();

			int aCount = s.Count(s => s == 'a');
			var deq = new Deque.Deque<char>(s.Length);
			for (var i = 0; i < s.Length; ++i) {
				deq.PushBack(s[i]);
			}

			// a以外の部分が回文ならOKという判定
			var deqWithoutA = new Deque.Deque<char>(s.Length);
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] != 'a') {
					deqWithoutA.PushBack(s[i]);
				}
			}

			bool IsPalindrome(Deque.Deque<char> d)
			{
				bool isPalindrome = true;
				int length = d.Length;
				for (var i = 0; i < length / 2; ++i) {
					if (d[i] != d[length - 1 - i]) {
						return false;
					}
				}

				return isPalindrome;
			}

			if (IsPalindrome(deq)) {
				Console.WriteLine("Yes");
				return;
			}

			/*
			if (deq.Contains('a') == false) {
				Console.WriteLine("No");
				return;
			}
			*/

			// さすがにこれはTLE
			/*
			for (var i = 0; i < aCount; ++i) {
				deq.PushFront('a');
				if (IsPalindrome(deq)) {
					Console.WriteLine("Yes");
					return;
				}
			}

			Console.WriteLine("No");
			*/

			var answer = IsPalindrome(deqWithoutA) ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}
	}
}

