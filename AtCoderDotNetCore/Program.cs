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
			long n = long.Parse(Console.ReadLine());
			var dict = new Dictionary<(int x, int y), (int r, int w, int h)>();
			for  (var i = 0; i < n; ++i) {
				var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				dict.Add((array[0], array[1]), (array[2], 1, 1));
			}

			double GetSatisfy(long r, long s)
			{
				double value = (1.0 - (double)Math.Min(r, s) / (double)Math.Max(r, s)) * (1.0 - (double)Math.Min(r, s) / (double)Math.Max(r, s));
				value = 1.0 - value;
				return value;
			}

			var dict2 = new Dictionary<(int x, int y), (int r, int w, int h)>(dict);
			foreach (var item in dict2.Keys) {
				int width = 1;
				int height = 1;
				bool next = false;
				for (var i = 1; i <= 10000 && next == false; ++i) {
					for (var j = 1; j <= 10000 && next == false; ++j) {
						if (dict.Keys.Contains((item.x + i, item.y + j))) {
							width = i;
							height = j;
							continue;
						}

						next = true;
						break;
					}
				}

				dict[item] = (dict[item].r, dict2[item].w + width, dict2[item].h + height);
			}

			int a = 0;
			int b = 0;
			int c = 0;
			int d = 0;
			double satAll = 0.0;
			foreach (var item in dict.Keys) {
				a = item.x;
				b = item.y;
				c = item.x + dict[item].w;
				d = item.y + dict[item].h;
				long area = dict[item].w * dict[item].h;
				satAll += GetSatisfy(dict[item].r, area);
				Console.WriteLine($"{a} {b} {c} {d}");
			}
			//Console.WriteLine($"{satAll}");
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

