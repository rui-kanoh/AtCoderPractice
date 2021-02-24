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
			var ans = 0;

			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var s = int.Parse(Console.ReadLine());
			var tkdict = new SortedDictionary<int, int>();
			var klist = new List<int>();
			for (var i = 0; i < n; ++i) {
				var tk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				tkdict.Add(tk[0], tk[1]);
			}

			var mood = 0;
			var tkdict2 = new Dictionary<int, int>();
			foreach (var item in tkdict) {
				//Console.WriteLine($"{item.Key}, {item.Value}");
				mood += item.Value;
				tkdict2.Add(item.Key, mood);
			}

			int start = -1;
			foreach (var item in tkdict2) {
				//Console.WriteLine($"{item.Key}, {item.Value}");
				if (item.Value >= m) {
					if (start == -1) {
						start = item.Key;
					}
				} else {
					if (start != -1) {
						ans += item.Key - start;
						start = -1;
					}
				}
			}

			if (tkdict2.Last().Key < s && tkdict2.Last().Value >= m) {
				ans += s - tkdict2.Last().Key;
			}


			Console.WriteLine($"{ans}");
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

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{
			var ans = "Bad";
			int n = int.Parse(Console.ReadLine());
			if (n <= 59) {
				ans = "Bad";
			} else if (60 <= n && n <= 89) {
				ans = "Good";
			} else if (90 <= n && n <= 99) {
				ans = "Great";
			} else {
				ans = "Perfect";
			}

			Console.WriteLine($"{ans}");
		}

		public static void B()
		{
			var ans = 0.0;
			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = array[0];
			var va = array[1];
			var vb = array[2];
			var l = array[3];
			ans = l;
			for (var i = 0; i < n; ++i) {
				double time = ans / (double)va;
				ans = (double)vb * time;
			}

			Console.WriteLine($"{ans}");
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

		public static void SaitoDfs()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			int ans = int.MaxValue;

			void Dfs(List<int> items, int last)
			{
				if (items.Count == k) {
					int count = 0;

					// 計算ロジック

					if (ans > count) {
						ans = count;
					}

					return;
				}

				// 重複を防ぐために自分のindexより大きいものだけを選ぶ
				int start = last + 1;

				for (int i = start; i < n; i++) {
					items.Add(i);
					Dfs(items, i);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), -1);

			Console.WriteLine($"{ans}");
		}
	}
}

