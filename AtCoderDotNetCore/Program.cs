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
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int n = nm[0];
			int m = nm[1];
			var gate = new List<List<long>>();
			for (var i = 0; i < n; ++i) {
				gate.Add(Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList());
			}

			var time = new List<List<long>>();
			for (var i = 0; i < n; ++i) {
				time.Add(Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList());
			}

			long ans = 0;
			for (int i = 0; i < n; i++) {
				long cur = ans;
				long min = long.MaxValue;
				for (int j = 0; j < m; j++) {
					long gate2 = gate[i][j];
					long time2 = time[i][j];
					long wait = cur % gate2 == 0
						? 0
						: gate2 - (cur % gate2);
					long temp = cur + wait + time2;
					if (min > temp) {
						min = temp;
					}
				}

				ans = min;
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
			var array = Console.ReadLine().Split(" ").Select(i => double.Parse(i)).ToArray();
			double height_m = array[0] / 100.0;
			double bmi = array[1];
			double weight_kg = bmi * height_m * height_m;
			Console.WriteLine(weight_kg.ToString("f3"));
		}

		public static void B()
		{
			var list = Enumerable.Range(1, 1000).ToList();
			var strs = new List<string>();
			foreach (var item in list) {
				strs.Add(item.ToString());
			}

			strs.Sort((a, b) => a.CompareTo(b));

			foreach (var item in strs) {
				Console.WriteLine($"{item}");
			}
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

