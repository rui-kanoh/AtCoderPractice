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
			bool IsPrime(long num)
			{
				if (num < 2) return false;
				else if (num == 2) return true;
				else if (num % 2 == 0) return false;

				double sqrtNum = Math.Sqrt(num);
				for (int i = 3; i <= sqrtNum; i += 2) {
					if (num % i == 0) {
						// 素数ではない
						return false;
					}
				}

				// 素数である
				return true;
			}

			Dictionary<long, long> GetPrimeFactor(long n)
			{
				var ret = new Dictionary<long, long>();
				for (long i = 2; i * i <= n; i++) {
					if (n % i != 0) continue;
					long tmp = 0;
					while (n % i == 0) {
						tmp++;
						n /= i;
					}

					ret.Add(i, tmp);
				}

				if (n != 1) {
					ret.Add(n, 1);
				}

				return ret;
			}

			long K = long.Parse(Console.ReadLine());
			if (IsPrime(K)) {
				Console.WriteLine($"1");
				return;
			}

			var list = new List<long>();
			var factors = GetPrimeFactor(K);
			foreach (var item in factors) {
				//Console.WriteLine($"{item.Key}, {item.Value}");
				list.Add(item.Key);
			}

			list.Sort();


			void Dfs(List<long> items, long last, int n)
			{
				if (items.Count == n) {
					foreach (var item in items) {
						Console.WriteLine(item);
					}

					// 計算ロジック
					return;
				}

				// 重複を防ぐために自分のindexより大きいものだけを選ぶ
				long start = last + 1;

				for (long i = start; i < n; i++) {
					items.Add(i);
					Dfs(items, i, n);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<long>(), -1, 3);
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

