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
			long n = long.Parse(Console.ReadLine());
			long baseNumber = 26;

			string str = "";
			while (n > 0) {
				--n;
				var ans = n % baseNumber;
				char c = (char)(ans + 'a');
				str = c.ToString() + str;
				n /= baseNumber;
			}

			Console.WriteLine(str);
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		// 約数の列挙
		public static long[] GetDivisors(long k, bool doesSort = false)
		{
			var list = new List<long>();
			long max = (long)Math.Sqrt(k);
			for (var i = 1; i <= max; ++i) {
				if (k % i == 0) {
					list.Add(i);
					if (i != k / i) {
						list.Add(k / i);
					}
				}
			}

			if (doesSort) {
				list.Sort();
			}

			return list.ToArray();
		}

		public static void Exec()
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

		public static void A()
		{
			int n = int.Parse(Console.ReadLine());
			var m = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var point = 80;
			var answer = 0;
			for (var i = 0; i < n; ++i) {
				answer += Math.Max(0, point - m[i]);
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var nab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nab[0];
			var a = nab[1];
			var b = nab[2];
			int position = 0;
			for (var i = 0; i < n; ++i) {
				var sd = Console.ReadLine().Split(" ");

				int dir = sd[0] == "East" ? 1 : -1;
				int distance = int.Parse(sd[1]);
				if (distance < a) {
					distance = a;
				} else if (b < distance) {
					distance = b;
				}

				position += dir * distance;

			}

			if (position == 0) {
				Console.WriteLine($"0");
			} else if (position > 0) {
				Console.WriteLine($"East {position}");
			} else {
				Console.WriteLine($"West {Math.Abs(position)}");
			}
		}

		public static void C()
		{

		}

		public static void D()
		{

		}

		public static void E()
		{
			int q = int.Parse(Console.ReadLine());
			var answers = new StringBuilder();
			for (var i = 0; i < q; ++i) {
				long n = long.Parse(Console.ReadLine());
				int max = 1;
				int index = 1000;
				for (var j = 1; j <= n; ++j) {
					var divisors = GetDivisors(j);
					if (max < divisors.Length) {
						max = divisors.Length;
						index = j;
					}
				}

				answers.AppendLine($"{max} {index}");
			}

			Console.Write(answers.ToString());
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
	}
}

