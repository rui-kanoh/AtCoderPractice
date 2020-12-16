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
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var n = array[0];
			var m = array[1];
			var c = new long[n];
			for (var i = 0; i < n; ++i) {
				c[i] = long.Parse(Console.ReadLine());
			}

			long power = Math.Abs(m - c[0]);
			var hash = new HashSet<long>();
			for (var i = 1; i < n; ++i) {
				var val2 = Math.Abs(m - c[i]);
				if (val2 == 0) {
					continue;
				} else {
					hash.Add(val2);
				}

				for (var j = 0; j < i; ++j) {
					var val = Math.Abs(c[j] - c[i]);
					if (hash.Contains(val)) {
						break;
					} else {
						hash.Add(val);
					}
				}

				power += hash.Min();

				hash.Clear();
			}

			Console.WriteLine($"{power}");
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
			var nm = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = nm[0];
			int m = nm[1];

			int answer = (n - 1) * (m - 1);
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			string s = Console.ReadLine();
			var abcd = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			string d = "\"";
			if (abcd[0] == 0) {
				s = d + s;
			} else {
				s = s.Insert(abcd[0], d);
			}

			for (var i = 1; i < 4; ++i) {
				s = s.Insert(abcd[i] + i, d);
			}

			Console.WriteLine(s);
		}

		public static void C()
		{
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var a = array[0];
			var b = array[1];
			var k = array[2];
			var l = array[3];

			long min = long.MaxValue;
			for (var i = 0; i <= k; ++i) {
				long aa = a * i;
				long bb = b * (k / l);

				long count = aa + bb;
				if (k % l != 0) {
					if (b > a * (k % l)) {
						count += a * (k % l);
					} else {
						count += b;
					}
				}

				if (min > count) {
					min = count;
				}
			}

			long answer = min;
			Console.WriteLine($"{answer}");
		}

		public static void D()
		{
			//グラフなのでパス
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

