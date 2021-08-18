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
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			List<long> list = new();
			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				list.Add(ab[1]);
				list.Add(ab[0] - ab[1]);
			}

			list.Sort();

			long answer = 0;
			for (var i = 0; i < k; ++i) {
				answer += list[list.Count - 1 - i];
			}

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
			var answer = n / 3;
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			long Gcd(long a, long b)
			{
				if (b == 0) {
					return a;
				}

				return Gcd(b, a % b);
			}

			var abc = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			BigInteger answer = 0;
			if (a == b && b == c) {
				answer = 0;
			} else {
				// 2面の切る回数を考えれば良い
				// a-b面
				var gcdAB = Gcd(a, b);
				var length = Gcd(gcdAB, c);
				//Console.WriteLine($"{length}");
				answer += a / length - 1;
				answer += b / length - 1;

				// b-c面
				answer += c / length - 1;
			}

			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			List<(long a, long b)> list = new();
			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				list.Add((ab[0], ab[1]));
			}

			list.Sort((a, b) => a.a.CompareTo(b.a));

			long total = 0;
			for (var i = list.Count - 1; i >= 0 && k > 0; --i) {
				if (i > 0) {
					if (k > 1) {
						if (list[i].a > list[i].b + list[i - 1].b) {
							total += list[i].a;
						} else {
							total += list[i].b + +list[i - 1].b;
							--i;
						}
						k -= 2;
					}
				} else {
					if (k > 1) {
						total += list[i].a;
						k -= 2;
					} else if (k > 0) {
						total += list[i].b;
						--k;
					}
				}
			}

			long answer = total;

			Console.WriteLine($"{answer}");
		}

		public static void D()
		{
			var nkp = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nkp[0];
			var k = nkp[1];
			var p = nkp[2];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
		}

		public static void E()
		{

		}

	}
}

