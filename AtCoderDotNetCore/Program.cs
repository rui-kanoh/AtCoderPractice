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
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			int k = array[1];
			var dlist = new List<long>();
			for (int i = 0; i < n; ++i) {
				dlist.Add(long.Parse(Console.ReadLine()));
			}

			var xydict = new Dictionary<int, List<int>>();
			for (int i = 0; i < k; ++i) {
				var xy = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();

				if (xydict.ContainsKey(xy[0]) == false) {
					xydict.Add(xy[0], new List<int>() { xy[1] });
				} else {
					xydict[xy[0]].Add(xy[1]);
				}

				if (xydict.ContainsKey(xy[1]) == false) {
					xydict.Add(xy[1], new List<int>() { xy[0] });
				} else {
					xydict[xy[1]].Add(xy[0]);
				}
			}

			static void CalculatePoint(int start, ref long ans, Dictionary<int, List<int>> dict, List<long> list, ref int count, int max)
			{
				ans += list[start];
				++count;
				if (dict.ContainsKey(start) == false
					|| count >= max) {
					return;
				}

				start = dict[start];
				CalculatePoint(start, ref ans, dict, list, ref count, max);
			}

			long max = 0;

			for (int i = 0; i < n; ++i) {
				long answer = 0;
				int count = 0;

				CalculatePoint(i, ref answer, xydict, dlist, ref count, n);
				if (answer > max) {
					max = answer;
				}
			}

			Console.WriteLine($"{max}");
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
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int h = array[0];
			int w = array[1];
			int answer = 0;

			if (h == 1 && w == 1) {
				answer = 0;
			} else if (h == 1 || w == 1) {
				answer = h == 1 ? w - 1 : h - 1;
			} else {
				answer = (h - 1) * w + h * (w - 1);
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());
			int c = int.Parse(Console.ReadLine());

			var dict = new Dictionary<int, int>();
			if (a > b && b > c) {
				dict.Add(a, 1);
				dict.Add(b, 2);
				dict.Add(c, 3);
			} else if (a > b && b < c && c < a) {
				dict.Add(a, 1);
				dict.Add(b, 3);
				dict.Add(c, 2);
			} else if (a < b && b > c && c < a) {
				dict.Add(a, 2);
				dict.Add(b, 1);
				dict.Add(c, 3);
			} else if (c > a && a > b) {
				dict.Add(a, 2);
				dict.Add(b, 3);
				dict.Add(c, 1);
			} else if (a < c && c < b) {
				dict.Add(a, 3);
				dict.Add(b, 1);
				dict.Add(c, 2);
			} else if (a < c && b < c && a < b) {
				dict.Add(a, 3);
				dict.Add(b, 2);
				dict.Add(c, 1);
			}


			Console.WriteLine($"{dict[a]}");
			Console.WriteLine($"{dict[b]}");
			Console.WriteLine($"{dict[c]}");
		}

		public static void C()
		{
			int answer = 654231;
			Console.WriteLine($"{answer}");
		}

		public static void D()
		{

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

