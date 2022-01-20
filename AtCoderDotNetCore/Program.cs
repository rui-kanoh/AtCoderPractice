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
		public static long Calc(long a, long b)
		{
			return Math.Max(a - b, 0);
		}

		public static void Exec()
		{
			long n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList();
			var c = new long[n + 1];

			b.Sort();

			var aa = new List<(int index, long value)>();
			for (var i = 0; i <= n; ++i) {
				aa.Add((i, a[i]));
			}

			aa.Sort((a, b) => a.value < b.value);


			for (var i = 0; i <= n; ++i) {
				var list = new List<long>(a);
				list.RemoveAt(i);
				list.Sort();

				long max = 0;
				for (var j = 0; j < list.Count; ++j) {
					var val = Calc(list[j], b[j]);
					max = Math.Max(max, val);
				}

				c[i] = max;
			}

			var answer = string.Join(" ", c);
			Console.WriteLine($"{answer}");
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
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
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			double ave = a.Average();

			double min = 101;
			var answer = 0;
			for (var i = 0; i < a.Count; ++i) {
				if (Math.Abs(a[i] - ave) < min) {
					min = Math.Abs(a[i] - ave);
					answer = i;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var nmab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nmab[0];
			var m = nmab[1];
			var a = nmab[2];
			var b = nmab[3];

			var c = new long[m];
			for (var i = 0; i < m; ++i) {
				c[i] = long.Parse(Console.ReadLine());
			}

			var cardCount = n;
			var date = 0;
			bool completes = true;
			for (var i = 0; i < m; ++i) {
				if (cardCount <= a) {
					cardCount += b;
				}

				if (cardCount >= c[i]) {
					cardCount -= c[i];
				} else {
					date = i + 1;
					completes = false;
					break;
				}
			}

			var answer = completes ? "complete" : $"{date}";
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			long l = long.Parse(Console.ReadLine());
			var answer = 0;
			Console.WriteLine($"{answer}");
		}

		public static long Calc(long a, long b)
		{
			return Math.Max(a - b, 0);
		}

		public static void D()
		{
			long n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList();
			var c = new long[n + 1];

			b.Sort();

			for (var i = 0; i <= n; ++i) {
				var list = new List<long>(a);
				list.RemoveAt(i);
				list.Sort();

				long max = 0;
				for (var j = 0; j < list.Count; ++j) {
					var val = Calc(list[j], b[j]);
					max = Math.Max(max, val);
				}

				c[i] = max;
			}

			var answer = string.Join(" ", c);
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
	}
}

