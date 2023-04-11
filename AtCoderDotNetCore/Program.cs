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
			string s = Console.ReadLine();

			var answer = s;
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

		public static void Moving()
		{
			int x = int.Parse(Console.ReadLine());
			int y = int.Parse(Console.ReadLine());
			int z = int.Parse(Console.ReadLine());

			var answer = x + y <= z ? 1 : 0;
			Console.WriteLine($"{answer}");
		}

		public static void ManyOranges()
		{
			var abw = Console.ReadLine().Split(" ").Select(i => decimal.Parse(i)).ToArray();
			var a = abw[0];
			var b = abw[1];
			var w = abw[2] * 1000;

			if (a > w && b > w) {
				Console.WriteLine($"UNSATISFIABLE");
				return;
			}

			var amariMax = w % a;
			var amariMin = w % b;
			var countMax = (int)(w / a);
			var countMin = (int)(w / b);

			if (amariMax > 0) {
				bool isOK = false;
				for (var i = 0; i <= countMin; ++i) {
					if ((amariMin + (b * i)) >= a * (i + 1)) {
						isOK = true;
						break;
					}
				}

				if (isOK == false) {
					Console.WriteLine($"UNSATISFIABLE");
					return;
				}
			}

			int max = countMax;

			int min = countMin;
			if (amariMin > 0) {
				++min;
			}

			var answer = $"{min} {max}";
			Console.WriteLine($"{answer}");
		}
	}
}

