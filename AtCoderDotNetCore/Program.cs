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
			var m = int.Parse(Console.ReadLine());
			var srcXY = new List<(int x, int y)>();

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var start = (array[0], array[1]);
			srcXY.Add((0, 0));
			for (var i = 1; i < m; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				srcXY.Add((xy[0] - start.Item1, xy[1] - start.Item2));
			}

			var n = int.Parse(Console.ReadLine());
			var dstXY = new HashSet<(int, int)>();
			for (var i = 1; i < n; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				dstXY.Add((xy[0], xy[1]));
			}

			foreach (var dst in dstXY) {
				bool isExist = true;
				foreach (var next in srcXY) {
					if (dstXY.Contains((dst.Item1 + next.x, dst.Item2 + next.y)) == false) {
						isExist = false;
						break;
					}
				}

				if (isExist) {
					Console.WriteLine($"{dst.Item1 - start.Item1} {dst.Item2 - start.Item2}");
					return;
				}
			}
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
			long n = long.Parse(Console.ReadLine());
			var dict = new Dictionary<string, int>();
			for (var i = 0; i < n; ++i) {
				string s = Console.ReadLine();
				if (dict.ContainsKey(s)) {
					++dict[s];
				} else {
					dict.Add(s, 1);
				}
			}

			var max = dict.Values.Max();

			var list = new List<string>();
			foreach (var item in dict) {
				if (item.Value < max) {
					continue;
				}

				list.Add(item.Key);
			}

			list.Sort();

			foreach (var item in list) {
				var ans = item;
				Console.WriteLine($"{ans}");
			}
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

