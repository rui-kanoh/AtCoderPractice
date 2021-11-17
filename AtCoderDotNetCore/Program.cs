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
			long n = long.Parse(Console.ReadLine());

			long keta = (long)Math.Log10(n);

			long value = n;
			long hardShat = 0;
			long deno = 1;
			for (var i = 1; i <= keta + 1; ++i) {
				deno *= 10;
				hardShat += (value % deno) / (deno / 10);
			}

			var answer = n % hardShat == 0;

			Console.WriteLine(answer ? "Yes" : "No");
		}

		public static void B()
		{
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());

			int min = int.MaxValue;

			int diff = Math.Abs(a - b);

			int value = 0;
			if (a > b) {
				value = (9 - a) + b + 1;
			} else {
				value = a + (9 - b) + 1;
			}

			min = Math.Min(diff, value);

			var answer = min;
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new int[n, 6];
			for (var i = 0; i < n; ++i) {
				var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				for (var j = 0; j < array.Length; ++j) {
					a[i, j] = array[j];
				}
			}

			BigInteger deno = (BigInteger)(Math.Pow(10, 9) + 7);

			BigInteger mul = 1;

			for (var i = 0; i < n; ++i) {
				BigInteger sum = 0;
				for (var j = 0; j < 6; ++j) {
					sum += a[i, j];
				}

				mul = (mul * sum) % deno;
			}

			var answer = mul;
			Console.WriteLine($"{answer}");
		}

		public static void D()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var p = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var abcList = new List<(long a, long b, long c)>();

			for (var i = 0; i < n - 1; ++i) {
				var abc = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				abcList.Add((abc[0], abc[1], abc[2]));
			}

			var table = new long[n];
			for (var i = 0; i < p.Length - 1; ++i) {
				// いもす法（ただし、入場・出場地点に注意
				var a = p[i] < p[i + 1] ? p[i] : p[i + 1];
				var b = p[i] < p[i + 1] ? p[i + 1] : p[i];

				++table[a - 1];
				--table[b - 1];
			}

			for (var i = 1; i < n; ++i) {
				table[i] += table[i - 1];
			}

			long cost = 0;
			for (var i = 0; i < n - 1; ++i) {
				long paper = abcList[i].a * table[i];
				long card = abcList[i].c + abcList[i].b * table[i];
				cost += Math.Min(paper, card);
			}

			Console.WriteLine($"{cost}");
		}

		public static void E()
		{

		}
	}
}

