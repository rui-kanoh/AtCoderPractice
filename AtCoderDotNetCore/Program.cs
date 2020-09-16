using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;


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

		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static void Exec()
		{
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
			Console.SetOut(sw);

			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			long n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{
			var a = int.Parse(Console.ReadLine());
			var b = int.Parse(Console.ReadLine());
			var h = int.Parse(Console.ReadLine());
			Console.WriteLine($"{(a + b) * h / 2}");
		}

		public static void B()
		{
			var dn = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var d = dn[0];
			var n = dn[1];

			long answer = 0;
			if (n != 100) {
				if (d == 0) {
					answer = n;
				} else if (d == 1) {
					answer = 100 * n;
				} else {
					answer = 100 * 100 * n;
				}
			} else {
				if (d == 0) {
					answer = 101;
				} else if (d == 1) {
					answer = 100 * 101;
				} else {
					answer = 100 * 100 * 101;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			/*
			long n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var b = new List<long>();
			for (var i = 0; i < n; ++i) {
				b.Add(a[i]);
				if (b.Any()) {
					b.Reverse();
				}
			}

			for (var i = 0; i < b.Count; ++i) {
				if (i < b.Count - 1) {
					Console.Write($"{b[i]} ");
				} else {
					Console.WriteLine($"{b[i]} ");
				}
			}
			*/

			long n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();


			if (n % 2 == 1) {
				for (var i = n - 1; i >= 0; i = i - 2) {
					Console.Write($"{a[i]}");
					Console.Write(" ");
				}

				for (var i = 1; i < n - 1; i = i + 2) {
					Console.Write($"{a[i]}");

					if (i < n - 1 - 1) {
						Console.Write(" ");
					} else {
						Console.WriteLine();
					}
				}
			} else {
				for (var i = n - 1; i >= 1; i = i - 2) {
					Console.Write($"{a[i]}");
					Console.Write(" ");
				}

				for (var i = 0; i < n; i = i + 2) {
					Console.Write($"{a[i]}");

					if (i < n - 1) {
						Console.Write(" ");
					} else {
						Console.WriteLine();
					}
				}
			}
		}

		public static void D()
		{
			var nx = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var n = nx[0];
			var x = nx[1];
			var a = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long answer = -1;
			Console.WriteLine($"{answer}");
		}

		public static void E()
		{

		}

		public static void F()
		{

		}

		public static void G()
		{

		}

		public static void H()
		{

		}

		public static void I()
		{

		}

		public static void J()
		{

		}

		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
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
	}
}

