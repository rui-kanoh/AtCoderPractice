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

		public static void ExecTemp()
		{
			var mn = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var m = mn[0];
			var n = mn[1];
			var abcList = new List<(int a, int b, int c)>();
			// 連接リスト
			var lists = new List<int>[m];

			for (var i = 0; i < n; ++i) {
				lists[i] = new List<int>();
			}


			for (var i = 0; i < m; ++i) {
				var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = abc[0] - 1;
				var b = abc[1] - 1;
				var c = abc[2];
				abcList.Add((a, b, c));

				lists[a].Add(b);
				lists[b].Add(a);
			}

			int q = int.Parse(Console.ReadLine());
			var stList = new List<(int s, int t)>();
			for (var i = 0; i < n; ++i) {
				var st = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var s = st[0];
				var t = st[1];
				stList.Add((s, t));
			}

			var answer = 0;
			if (q == 1) {
				Console.WriteLine($"{answer}");
			} else {
				Console.WriteLine($"{answer}");
			}
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

		public static void Exec1222()
		{
			string s = Console.ReadLine();
			var answer = s.Count(c => c == '2');

			Console.WriteLine($"{answer}");
		}

		public static void Walkman()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = new long[n];
			for (var i = 0; i < n; ++i) {
				a[i] = long.Parse(Console.ReadLine());
			}

			long count = 0;
			var answer = 0;
			for (var i = 0; i < n; ++i) {
				count += a[i];
				if (count >= k) {
					answer = i + 1;
					break;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void MazeMaster()
		{
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];

			var map = new bool[h, w];
			for (var i = 0; i < h; i++) {
				string s = Console.ReadLine();
				for (var j = 0; j < s.Length; ++j) {
					map[i, j] = s[j] == '.';
				}
			}

			var map2 = new bool[h, w];
			void Initialize()
			{
				for (var i = 0; i < h; i++) {
					for (var j = 0; j < w; ++j) {
						map2[i, j] = map[i, j];
					}
				}
			}

			long max = 0;

			// s/gを任意に決めるための4重ループ sとgを同じ点にできないこと注意
			for (var i = 0; i < h; i++) {
				for (var j = 0; j < w; ++j) {
					for (var k = 0; k < h; k++) {
						for (var l = 0; l < w; ++l) {
							if (i == k && j == l) {
								continue;
							}

							Initialize();

							int step = Calc.GridBFS(h, w, i, j, k, l, map2);
							max = Math.Max(step, max);
						}
					}
				}
			}

			var answer = max;
			Console.WriteLine($"{answer}");
		}

		public static void CardSort()
		{
			int n = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());
			var a = new int[n];
			for (var i = 0; i < n; ++i) {
				a[i] = int.Parse(Console.ReadLine());
			}

			var ans = new HashSet<int>();
			int count = 0;

			void Dfs(List<int> items, HashSet<int> hash)
			{
				if (items.Count == k) {
					/*
					for (var i = 0; i < items.Count; ++i) {
						Console.Write($"{a[items[i]]}");
					}
					Console.WriteLine("");
					*/

					string str = "";
					for (var i = 0; i < items.Count; ++i) {
						str += $"{a[items[i]]}";
					}

					var value = int.Parse(str);
					if (ans.Contains(value) == false) {
						ans.Add(value);
						++count;
					}

					return;
				}

				for (int i = 0; i < n; i++) {
					if (hash.Contains(i) == false) {
						items.Add(i);
						hash.Add(i);
						Dfs(items, hash);
						hash.Remove(items[items.Count - 1]);
						items.RemoveAt(items.Count - 1);
					}
				}
			}

			Dfs(new List<int>(), new HashSet<int>());

			var answer = count;

			Console.WriteLine($"{answer}");
		}
		
		public static void TakahashiAoki()
		{
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());

			long answer = 0;
			for (long i = n; i < int.MaxValue; ++i) {
				if (i % a == 0 && i % b == 0) {
					answer = i;
					break;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void Ongaku()
		{
			int n = int.Parse(Console.ReadLine());
			var x = new List<char[]>();

			var count = 0;

			for (var i = 0; i < n; i++) {
				var s = Console.ReadLine();
				var array = s.ToCharArray();
				count += array.Count(c => c == 'x');
				x.Add(array);
			}

			// 長押し箇所を探す
			for (var j = 0; j < 9; ++j) {
				bool starts = false;
				for (var i = 0; i < n; ++i) {
					if (x[i][j] == 'o') {
						if (starts == false) {
							starts = true;
							++count;
							continue;
						}
					}

					if (x[i][j] != 'o') {
						if (starts) {
							starts = false;
						}
					}
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void RedundantRedundancy()
		{
			int n = int.Parse(Console.ReadLine());
			long value = 2;
			for (long i = 3; i <= n; ++i) {
				value = Lcm(i, value);
			}

			long answer = value + 1;
			Console.WriteLine($"{answer}");
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
	}
}

