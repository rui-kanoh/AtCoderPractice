﻿using System;
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
			var nx = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nx[0];
			var x = nx[1];
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			a.Sort();

			int count = 0;
			long total = 0;

			if (a[0] > x) {
				count = 0;
			} else {
				for (var i = 0; i < n; ++i) {
					total += a[i];

					if (i < n - 1) {
						if (total > x) {
							count = i + 1;
							break;
						}
					} else {
						count = i + 1;
					}
				}
			}


			var answer = (long)0;

			if (count == 0) {
				answer = 0;
			} else {
				if (total == x) {
					answer = n;
				} else {
					answer = count - 1;
				}
			}

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

		public static void Dice()
		{
			int a = int.Parse(Console.ReadLine());
			var answer = 7 - a;
			Console.WriteLine($"{answer}");
		}
	}
}

