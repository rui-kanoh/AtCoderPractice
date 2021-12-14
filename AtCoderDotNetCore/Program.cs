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
		// https://webbibouroku.com/Blog/Article/cs-permutation
		public static IReadOnlyList<T[]> AllPermutation<T>(params T[] array) where T : IComparable
		{
			var a = new List<T>(array).ToArray();
			var res = new List<T[]>();
			res.Add(new List<T>(a).ToArray());
			var n = a.Length;
			var next = true;
			while (next) {
				next = false;

				// 1
				int i;
				for (i = n - 2; i >= 0; i--) {
					if (a[i].CompareTo(a[i + 1]) < 0) break;
				}
				// 2
				if (i < 0) break;

				// 3
				var j = n;
				do {
					j--;
				} while (a[i].CompareTo(a[j]) > 0);

				if (a[i].CompareTo(a[j]) < 0) {
					// 4
					var tmp = a[i];
					a[i] = a[j];
					a[j] = tmp;
					Array.Reverse(a, i + 1, n - i - 1);
					res.Add(new List<T>(a).ToArray());
					next = true;
				}
			}
			return res;
		}

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void Exec()
		{
			string s = Console.ReadLine();

			bool isOK = false;

			if (s.Length < 9) {
				//O(n!)なので

				var list = AllPermutation(s.ToCharArray());
				foreach (var item in list) {
					long value = long.Parse(item);
					if (value % 8 == 0) {
						isOK = true;
						break;
					}
				}
			} else {
				// 1000は8の倍数なので下3桁だけ見ればOK

				var factors = new List<int[]>();
				// 999までの8の倍数の列挙
				for (var i = 8; i < 999; i = i + 8) {
					var digits = new int[9];
					string str = $"{i}";
					foreach (var c in str.ToCharArray()) {
						int value = int.Parse(c.ToString());
						++digits[value - 1];
					}

					factors.Add(digits);
				}

				bool Check()
				{
					return false;
				}

				for (var i = 0; i < s.Length; ++i) {

				}
			}

			var answer = isOK ? "Yes" : "No";
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
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];

			var answer = a > b ? a : b;
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var nab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nab[0];
			var a = nab[1];
			var b = nab[2];

			bool winsA = true;

			int redusue = n % (a + b);
			if (redusue == 0) {
				winsA = false;
			} else if (redusue <= a) {
				winsA = true;
			} else if (redusue - a < b) {
				winsA = false;
			}

			var answer = winsA ? "Ant" : "Bug";
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{


		}

		public static void D()
		{

		}

		public static void E()
		{

		}
	}
}

