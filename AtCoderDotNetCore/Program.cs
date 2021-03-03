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
			var srcX = new List<int>();
			var srcY = new List<int>();
			for (var i = 0; i < m; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				srcXY.Add((xy[0], xy[1]));
				srcX.Add(xy[0]);
				srcY.Add(xy[1]);
			}

			var n = int.Parse(Console.ReadLine());
			var dstXY = new List<(int x, int y)>();
			var dstX = new List<int>();
			var dstY = new List<int>();
			for (var i = 0; i < n; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				dstXY.Add((xy[0], xy[1]));
				dstX.Add(xy[0]);
				dstY.Add(xy[1]);
			}

			//int min = 0;
			int max = 1000000;
			int maxX = srcX.Max();
			int minX = srcX.Min();
			int maxY = srcY.Max();
			int minY = srcY.Min();

			var shiftXY = (0, 0);
			//var indexes = new List<int>();
			//var listX = new List<int>(srcX);
			var listXY = new List<(int, int)>(srcXY);
			for (var i = -1 * minX; i <= max - maxX; ++i) {
				for (var j = -1 * minY; j <= max - maxY; ++j) {
					int count = 0;
					for (var k = 0; k < srcX.Count; ++k) {
						listXY[k] = (srcXY[k].x + i, srcXY[k].y + j);
					}

					for (var k = 0; k < listXY.Count; ++k) {
						if (dstXY.Contains(listXY[k])) {
							++count;
						}
					}

					if (count == listXY.Count) {
						shiftXY.Item1 = i;
						shiftXY.Item2 = j;

						Console.WriteLine($"{shiftXY.Item1} {shiftXY.Item2}");
						return;
					}
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

