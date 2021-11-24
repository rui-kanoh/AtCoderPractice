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
			var hw = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var mas = new char[h, w];
			for (var i = 0; i < h; ++i) {
				string s = Console.ReadLine();
				for (var j = 0; j < s.Length; ++j) {
					mas[i, j] = s[j];
				}
			}

			long count = 0;

			for (var i = 0; i < h; ++i) {
				for (var j = 0; j < w; ++j) {
					if (mas[i, j] == 'J') {
						int countI = 0;
						for (var k = i + 1; k < h; ++k) {
							if (mas[k, j] == 'I') {
								++countI;
							}
						}

						int countO = 0;
						for (var k = j + 1; k < w; ++k) {
							if (mas[i, k] == 'O') {
								++countO;
							}
						}

						count += (countI * countO);
					}
				}
			}

			Console.WriteLine($"{count}");
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
			var answer = n % 3 == 0 ? "YES" : "NO";
			Console.WriteLine($"{answer}");
		}

		public static long Gcd(long a, long b)
		{
			if (b == 0) {
				return a;
			}

			return Gcd(b, a % b);
		}

		public static void B()
		{
			/*
			 * 余計なことをすると
			 * 実行時間	2762 ms
			 * メモリ	24104 KB
			 * 
			 * 愚直にやると
			 * 実行時間	1032 ms
			 * メモリ	17800 KB
			 */

			int k = int.Parse(Console.ReadLine());

			long sum = 0;
			for (var a = 1; a <= k; ++a) {
				for (var b = 1; b <= k; ++b) {
					for (var c = 1; c <= k; ++c) {
						long value = Gcd(a, b);
						value = Gcd(value, c);
						sum += value;
					}
				}
			}

			Console.WriteLine($"{sum}");
		}

		public static void C()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			string name = Console.ReadLine();
			var dict = new Dictionary<char, int>();
			foreach (var c in name.ToCharArray()) {
				if (dict.ContainsKey(c) == false) {
					dict.Add(c, 1);
				} else {
					++dict[c];
				}
			}

			string kit = Console.ReadLine();

			int max = 0;
			foreach (var item in dict) {
				int charCount = kit.Count(s => s == item.Key);
				if (charCount == 0) {
					Console.WriteLine("-1");
					return;
				}

				int count = (int)Math.Ceiling((double)item.Value / charCount);

				max = Math.Max(max, count);
			}

			Console.WriteLine($"{max}");
		}

		public static void D()
		{

		}

		public static void E()
		{

		}

		public static void Christmas()
		{
			var nx = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nx[0];
			var x = nx[1];

			var burger = "P";
			for (var i = 1; i <= n; ++i) {
				burger = $"B{burger}P{burger}B";
			}

			var sub = burger.Substring(0, (int)x);
			var answer = sub.Count(s => s == 'P');
			Console.WriteLine($"{answer}");
		}
	}
}

