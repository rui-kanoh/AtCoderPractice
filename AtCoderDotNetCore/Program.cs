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
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Reflection;
using System.Drawing;
using System.Net;
using System.Xml.Schema;
using System.ComponentModel.Design;

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
			ExecTemp();
		}

		public static bool Check(int value, List<long> list)
		{
			return list[value] >= 0;
		}

		public static (int ng, int ok) BinarySearch(List<long> list, int count)
		{
			int ng = -1;
			int ok = count;
			while (ok - ng > 1) {
				int mid = (ok + ng) / 2;
				if (Check(mid, list)) {
					ok = mid;
				} else {
					ng = mid;
				}
			}

			return (ng, ok);
		}

		public static void ExecTemp()
		{
			var n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var sumA = (long)0;
			var sumB = (long)0;
			for (var i = 0; i < n; ++i) {
				sumA += a[i];
				sumB += b[i];
			}

			if (sumA < sumB) {
				Console.WriteLine($"-1");
				return;
			}

			var diffList = new List<long>();
			for (var i = 0; i < n; ++i) {
				diffList.Add(a[i] - b[i]);
			}

			diffList.Sort();

			// 2butanで-1と0の切り替わりポイントを探す
			(int ng, int ok) = BinarySearch(diffList, n);

			var rui = new long[diffList.Count + 1];
			rui[0] = 0;
			for (var i = 0; i < n; ++i) {
				rui[i + 1] = diffList[i] + rui[i];
			}

			// 負の合計
			var sumM = rui[ok];

			if (sumM >= 0) {
				Console.WriteLine($"0");
				return;
			}

			// 正の合計数が負の合計を上回るポイントをニブタンで探す

			bool Check2(int value, long[] list, int start)
			{
				return (rui[value] - rui[start]) + diffList[start] >= Math.Abs(sumM);
			}
			(int ng, int ok) BinarySearch2(long[] list, int start, int end)
			{
				int ng = start;
				int ok = end;

				if (ok - ng <= 1) {
					return (end, end);
				}

				while (ok - ng > 1) {
					int mid = (ok + ng) / 2;
					if (Check2(mid, list, start)) {
						ok = mid;
					} else {
						ng = mid;
					}
				}

				return (ng, ok);
			}

			(int ng2, int ok2) = BinarySearch2(rui, ok, n);

			var count = ng2;

			var answer = count;
			Console.WriteLine($"{answer}");
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static void ExecTemp()
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

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
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

		public static void TravelingBudget()
		{
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());
			int c = int.Parse(Console.ReadLine());
			int d = int.Parse(Console.ReadLine());

			var answer = (a <= b ? a : b) + (c <= d ? c : d);
			Console.WriteLine($"{answer}");
		}

		public static void ThreeBoxes()
		{
			int n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();

			int x = 1;
			int count = 0;
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] == 'L') {
					if (x == 1) {
						x = 1;
					} else {
						x -= 1;
					}
				} else {
					if (x == 3) {
						x = 3;
					} else {
						x += 1;
					}
				}

				if (x == 3) {
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void RatingGoals()
		{
			int r = int.Parse(Console.ReadLine());
			int g = int.Parse(Console.ReadLine());

			var answer = 2 * g - r;
			Console.WriteLine($"{answer}");
		}

		public static void TwoProblems()
		{
			var tabcd = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var t = tabcd[0];
			var a = tabcd[1];
			var b = tabcd[2];
			var c = tabcd[3];
			var d = tabcd[4];

			var answer = (long)0;

			if (t < a && t < c) {
				answer = (long)0;
			} else {
				if (a + c <= t) {
					answer = d + b;
				} else {
					if (a <= t && c > t) {
						answer = b;
					} else if (a > t && c <= t) {
						answer = d;
					} else {
						answer = d;
					}
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void Redocta()
		{
			string str = "atcoder";
			string s = Console.ReadLine();
			if (s == "atcoder") {
				Console.WriteLine($"0");
				return;
			}

			// atcoderの文字を数字に置き換えてバブルソートする
			var dict = new Dictionary<char, int>();
			for (var i = 0; i < str.Length; ++i) {
				dict.Add(str[i], i);
			}

			var array = new int[str.Length];
			for (var i = 0; i < str.Length; ++i) {
				array[i] = dict[str[i]];
			}

			// 後ろから順番に隣同士を比較していき、正しい順番になっていなければ2つのデータを入れ替えていきます
			int count = 0;
			for (var i = 0; i < s.Length; ++i) {
				array[i] = dict[s[i]];
			}

			// https://www.momoyama-usagi.com/entry/info-algo-sort-basic#1
			int n = str.Length;
			for (int i = 0; i < n - 1; i += 1) {
				for (int j = n - 1; j >= i + 1; j -= 1) {
					// 配列の右側から順番に比較、昇順でなければ入れ替え
					if (array[j - 1] > array[j]) { //  条件を data[j-1] < [j] に変えると降順ソートに
												   // data[j-1] と data[j]の入れ替え
						int tmp = array[j - 1];
						array[j - 1] = array[j];
						array[j] = tmp;
						// 入れ替え終わり
						++count;
					}
				}
			}


			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void AddSubMul()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];
			var answer = Math.Max(Math.Max(a + b, a - b), a * b);
			Console.WriteLine($"{answer}");
		}

		public static void JointTheCompany()
		{
			string s = Console.ReadLine();
			string t = Console.ReadLine();
			var answer = s + t;
			Console.WriteLine($"{answer}");
		}

		public static void MartialArts()
		{
			int n = int.Parse(Console.ReadLine());

			var tlist = new List<long>();
			var klist = new List<long>();
			var alists = new Dictionary<int, List<int>>();
			for (var i = 0; i < n; ++i) {
				var tka = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var t = tka[0];
				var k = tka[1];
				tlist.Add(t);
				klist.Add(k);

				var alist = new List<int>();
				for (var j = 0; j < k; ++j) {
					alist.Add(tka[j + 2] - 1);
				}

				if (alist.Any()) {
					alists.Add(i, alist);
				}
			}

			// 後ろから考える。
			// 技nの修練に必要な時間を初期値として、後ろから見ていく
			var time = (long)0;

			var hash = new HashSet<int>();

			void Dfs(List<int> items, int n)
			{
				if (hash.Contains(n)) {
					return;
				}

				time += tlist[n];
				hash.Add(n);

				if (alists.ContainsKey(n) == false) {
					return;
				}

				var children = alists[n];
				foreach (var child in children) {
					items.Add(child);
					Dfs(items, child);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), n - 1);

			var answer = time;
			Console.WriteLine($"{answer}");
		}

		public static void Restaurant()
		{
			int n = int.Parse(Console.ReadLine());
			int x = n * 800;
			int y = (n / 15) * 200;
			var answer = x - y;
			Console.WriteLine($"{answer}");
		}

		public static IReadOnlyList<T[]> AllPermutation<T>(params T[] array) where T : IComparable
		{
			var a = new List<T>(array).ToArray();
			var res = new List<T[]>();
			res.Add(new List<T>(a).ToArray());
			var n = a.Length;
			var next = true;
			while (next) {
				next = false;

				// 1
				int i;
				for (i = n - 2; i >= 0; i--) {
					if (a[i].CompareTo(a[i + 1]) < 0) break;
				}
				// 2
				if (i < 0) break;

				// 3
				var j = n;
				do {
					j--;
				} while (a[i].CompareTo(a[j]) > 0);

				if (a[i].CompareTo(a[j]) < 0) {
					// 4
					var tmp = a[i];
					a[i] = a[j];
					a[j] = tmp;
					Array.Reverse(a, i + 1, n - i - 1);
					res.Add(new List<T>(a).ToArray());
					next = true;
				}
			}
			return res;
		}

		public static void Chairの適切な解()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = new int[] { ab[0], ab[1], ab[2], };
			var b = new int[] { ab[3], ab[4], ab[5], };

			var items = AllPermutation(new[] { 0, 1, 2 });
			var min = int.MaxValue;
			foreach (var item in items) {
				var dist = Math.Abs(a[0] - b[item[0]]) + Math.Abs(a[1] - b[item[1]]) + Math.Abs(a[2] - b[item[2]]);
				min = Math.Min(min, dist);
			}

			var answer = min;
			Console.WriteLine($"{answer}");
		}

		public static void Chair()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = new int[] { ab[0], ab[1], ab[2], }.ToList();
			var b = new int[] { ab[3], ab[4], ab[5], }.ToList();

			a.Sort();
			b.Sort();
			var min = Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]) + Math.Abs(a[2] - b[2]);

			var answer = min;
			Console.WriteLine($"{answer}");
		}

		public static bool IsOdd(BigInteger n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static BigInteger Abs(BigInteger value)
		{
			return value >= 0 ? value : -1 * value;
		}

		public static void WalkingTakahashi()
		{
			var xkd = Console.ReadLine().Split(" ").Select(i => BigInteger.Parse(i)).ToArray();
			var x = Abs(xkd[0]); // 正の場合だけ考える
			var k = xkd[1];
			var d = xkd[2];

			var distance = (BigInteger)0;
			if (x > d) {
				// x > d の場合 なるべく0に近づくようにする |x - n * d|
				var count = x / d;
				if (count <= k) {
					var dist1 = x % d;
					if (IsOdd(k - count) == false) {
						distance = Abs(dist1);
					} else {
						distance = Abs(dist1 - d);
					}
				} else {
					distance = Abs(x - (k * d));
				}
			} else {
				// x <= d の場合
				// Kが偶数なら留まる(|x|)
				// Kが奇数なら |d - x|

				if (IsOdd(k) == false) {
					distance = Abs(x);
				} else {
					distance = Abs(d - x);
				}
			}

			var answer = distance;
			Console.WriteLine($"{answer}");
		}
	}
}

