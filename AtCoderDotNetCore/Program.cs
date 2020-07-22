using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

			Console.Out.Flush();

			Console.ReadKey();
		}

		public static void A()
		{
			Dictionary<char, char> dict = new Dictionary<char, char>();
			dict.Add('A', 'T');
			dict.Add('C', 'G');
			dict.Add('G', 'C');
			dict.Add('T', 'A');
			char c = Console.ReadLine()[0];

			Console.WriteLine($"{dict[c]}");
		}

		public static void B()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int k = array[0];
			int x = array[1];

			for (var i = x - k + 1; i < x + k; ++i) {
				Console.Write($"{i}");
				if (i < x + k - 1) {
					Console.Write($" ");
				}
			}

			Console.WriteLine($"");
		}

		public static void C()
		{
			var a = new int[3, 3];
			var dict = new Dictionary<(int, int), bool>();
			for (var j = 0; j < 3; ++j) {
				var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
				for (var k = 0; k < 3; ++k) {
					a[j, k] = array[k];
					dict.Add((j, k), false);
				}
			}

			long n = int.Parse(Console.ReadLine());
			var b = new int[n];
			for (var j = 0; j < n; ++j) {
				b[j] = int.Parse(Console.ReadLine());
			}

			for (var j = 0; j < 3; ++j) {
				for (var k = 0; k < 3; ++k) {
					for (var l = 0; l < n; ++l) {
						if (b[l] == a[j, k]) {
							dict[(j, k)] = true;
						}
					}
				}
			}

			bool bingo = dict[(0, 0)] && dict[(0, 1)] && dict[(0, 2)];
			bingo = bingo || (dict[(1, 0)] && dict[(1, 1)] && dict[(1, 2)]);
			bingo = bingo || (dict[(2, 0)] && dict[(2, 1)] && dict[(2, 2)]);
			bingo = bingo || (dict[(0, 0)] && dict[(1, 0)] && dict[(2, 0)]);
			bingo = bingo || (dict[(0, 1)] && dict[(1, 1)] && dict[(2, 1)]);
			bingo = bingo || (dict[(0, 2)] && dict[(1, 2)] && dict[(2, 2)]);
			bingo = bingo || (dict[(0, 0)] && dict[(1, 1)] && dict[(2, 2)]);
			bingo = bingo || (dict[(0, 2)] && dict[(1, 1)] && dict[(2, 0)]);

			if (bingo) {
				Console.WriteLine("Yes");
			} else {
				Console.WriteLine("No");
			}
		}

		public static void D()
		{
			long deno = 1;
			for (int i = 0; i < 9; ++i) {
				deno *= 10;
			}
			deno += 7;

			long n = long.Parse(Console.ReadLine());
			long power = 1;
			for (long i = 1; i <= n; ++i) {
				power *= i;
				power = power % deno;
			}

			Console.WriteLine($"{power}");
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

