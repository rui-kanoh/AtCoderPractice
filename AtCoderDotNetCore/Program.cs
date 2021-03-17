using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
			//int n = int.Parse(Console.ReadLine());

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			var dict = new Dictionary<string, int>();
			dict.Add("a", array[1]);
			dict.Add("b", array[2]);
			dict.Add("c", array[3]);

			var listL = new List<int>();
			for (var i = 0; i < n; ++i) {
				listL.Add(int.Parse(Console.ReadLine()));
			}

			int min = int.MaxValue;

			void Dfs(List<string> items, int num)
			{
				if (items.Count == num) {
					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					var sumA = 0;
					var sumB = 0;
					var sumC = 0;
					var countA = -1;
					var countB = -1;
					var countC = -1;
					for (var i = 0; i < items.Count; ++i) {
						if (items[i] == "a") {
							sumA += listL[i];
							++countA;
						} else if (items[i] == "b") {
							sumB += listL[i];
							++countB;
						} else if (items[i] == "c") {
							sumC += listL[i];
							++countC;
						}
					}

					if (countA == -1 || countB == -1 || countC == -1) {
						return;
					}

					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					int answer = (countA + countB + countC) * 10
						+ Math.Abs(dict["a"] - sumA)
						+ Math.Abs(dict["b"] - sumB)
						+ Math.Abs(dict["c"] - sumC);
					//Console.WriteLine($"{answer}");
					if (min > answer) {
						min = answer;
					}

					return;
				}

				for (var i = 0; i <= (int)('d' - 'a'); ++i) {
					items.Add($"{(char)('a' + i)}");
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<string>(), n);

			Console.WriteLine($"{min}");
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
			long n = long.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{

		}

		public static void B()
		{

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

		public static void DfsSample(List<string> items, int num)
		{
			if (items.Count == num) {

				foreach (var item in items) {
					Console.Write($"{item} ");
				}
				Console.WriteLine("");

				return;
			}

			for (var i = 0; i <= (int)('d' - 'a'); ++i) {
				items.Add($"{(char)('a' + i)}");
				DfsSample(items, num);
				items.RemoveAt(items.Count - 1);
			}
		}

		public static void SaitoDfs()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			long ans = long.MaxValue;

			void Dfs(List<long> items, long last)
			{
				if (items.Count == k) {
					long count = 0;

					// 計算ロジック

					if (ans > count) {
						ans = count;
					}

					return;
				}

				// 重複を防ぐために自分のindexより大きいものだけを選ぶ
				long start = last + 1;

				for (long i = start; i < n; i++) {
					items.Add(i);
					Dfs(items, i);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<long>(), -1);

			Console.WriteLine($"{ans}");
		}
	}
}

