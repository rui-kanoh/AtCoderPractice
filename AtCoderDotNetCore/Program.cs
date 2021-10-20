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
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
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
			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			var answer = 0;
			if (a == b) {
				answer = c;
			} else if (b == c) {
				answer = a;
			} else {
				answer = b;
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			// 約数かどうか
			long[] GetDivisors(long k, bool doesSort = false)
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

			long K = long.Parse(Console.ReadLine());
			long[] divisors = GetDivisors(K, true);

			int count = 0;
			foreach (var a in divisors) {
				foreach (var b in divisors) {
					if ((K / a) % b == 0) {
						long c = K / a / b;
						if (a <= b && b <= c) {
							//Console.WriteLine($"{a} {b} {c}");
							++count;
						}
					}
				}
			}

			Console.WriteLine($"{count}");
		}

		public static void C()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			int end = 0;
			long max = 0;
			var hash = new Dictionary<long, int>();

			for (int start = 0; start < n; ++start) {
				// endを伸ばす
				while (end < n) {
					if (hash.ContainsKey(a[end]) == false) {
						if (hash.Count >= k) {
							break;
						}

						hash[a[end]] = 1;
					} else {
						++hash[a[end]];
					}

					++end;
				}

				max = Math.Max(max, end - start);

				if (end == start) {
					++end;
				}

				if (hash.ContainsKey(a[start])) {
					if (hash[a[start]] == 1) {
						hash.Remove(a[start]);
					} else { --hash[a[start]]; }
				}
			}

			Console.WriteLine($"{max}");
		}

		public static void D()
		{

		}

		public static void E()
		{

		}
	}
}

