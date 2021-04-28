﻿using System;
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
			var hwk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int h = hwk[0];
			int w = hwk[1];
			int k = hwk[2];
			int countR = 0;
			var c = new string[h, w];
			var cOrigin = new string[h, w];
			for (var i = 0; i < h; ++i) {
				var array = Console.ReadLine();
				for (var j = 0; j < array.Length; ++j) {
					c[i, j] = cOrigin[i, j] = array[j].ToString();
					if (array[j] == '#') {
						++countR;
					}
				}
			}

			void Origin(string[,] c)
			{
				for (var i = 0; i < h; ++i) {
					for (var j = 0; j < w; ++j) {
						c[i, j] = cOrigin[i, j];
					}
				}
			}

			var answer = 0;
			var number = h + w;

			int Count(string[,] lists)
			{
				int count = 0;
				for (var i = 0; i < lists.GetLength(0); ++i) {
					for (var j = 0; j < lists.GetLength(1); ++j) {
						if (lists[i, j] == "#") {
							++count;
						}
					}
				}

				return count;
			}

			void Dfs(List<int> items, int num)
			{
				if (items.Count == num) {
					/*
					if (items.Count(s => s == 1) == 0) {
						return;
					}
					*/

					for (var i = 0; i < h; ++i) {
						if (items[i] == 1) {
							for (var j = 0; j < w; ++j) {
								c[i, j] = "*";
							}
						}
					}

					for (var i = 0; i < w; ++i) {
						if (items[i + h] == 1) {
							for (var j = 0; j < h; ++j) {
								c[j, i] = "*";
							}
						}
					}

					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/
					int count = Count(c);
					if (count == k) {
						++answer;
					}

					Origin(c);
					return;
				}

				for (var i = 0; i < 2; ++i) {
					items.Add(i);
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), number);
			Console.WriteLine($"{answer}");
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

			string answer = "";

			Console.WriteLine($"{answer}");
		}

		public static void A()
		{
			int n = int.Parse(Console.ReadLine());

			int parentCount = n >= 2 ? (n - 2) : 0;
			long answer = 1 + parentCount;
			if (n < 2) {
				Console.WriteLine($"{answer}");
				return;
			}

			for (var i = 2; i <= n; i = i + 2) {
				answer += n - i;
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var lh = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int l = lh[0];
			int h = lh[1];
			int n = int.Parse(Console.ReadLine());
			var alist = new List<int>();
			for (var i = 0; i < n; ++i) {
				alist.Add(int.Parse(Console.ReadLine()));
			}

			for (var i = 0; i < n; ++i) {
				var answer = 0;
				if (h < alist[i]) {
					answer = -1;
				} else if (l <= alist[i]) {
					answer = 0;
				} else {
					answer = l - alist[i];
				}

				Console.WriteLine($"{answer}");
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

		public static (bool isFound, int left, int right) BinarySearch(int value, List<int> list)
		{
			int left = -1;
			int right = list.Count;
			while (right - left > 1) {
				int mid = (right + left) / 2;
				if (list[mid] == value) {
					return (true, mid, mid);
				} else if (list[mid] > value) {
					right = mid;
				} else {
					left = mid;
				}
			}

			if (left == -1 && right == list.Count) {
				return (false, 0, list.Count - 1);
			} else if (left == -1) {
				return (false, 0, 0);
			} else if (right == list.Count) {
				return (false, list.Count - 1, list.Count - 1);
			}

			return (false, left, right);
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

		public static long[,] GetPascal(int n)
		{
			var pascal = new long[n, n];
			pascal[0, 0] = 1;
			pascal[1, 0] = 1;
			pascal[1, 1] = 1;
			for (var i = 2; i < n; ++i) {
				pascal[i, 0] = 1;
				pascal[i, i] = 1;
				for (var j = 1; j < i; ++j) {
					pascal[i, j] = pascal[i - 1, j - 1] + pascal[i - 1, j];
				}
			}

			return pascal;
		}

		public static void GetIndexTest()
		{
			var mas = new int[3, 3];
			for (var i = 0; i < mas.GetLength(1); ++i) {
				for (var j = 0; j < mas.GetLength(0); ++j) {
					mas[i, j] = i * mas.GetLength(0) + j + 1;
				}
			}

			var mas2 = new int[5, 5];
			for (var i = 1; i <= mas.GetLength(1); ++i) {
				for (var j = 1; j <= mas.GetLength(0); ++j) {
					mas2[i, j] = mas[i - 1, j - 1];
				}
			}

			for (var i = 0; i < mas2.GetLength(1); ++i) {
				for (var j = 0; j < mas2.GetLength(0); ++j) {
					Console.Write($"{mas2[i, j]} ");
				}

				Console.WriteLine("");
			}

			Console.WriteLine("");
			Console.WriteLine("");

			for (var i = 1; i <= mas.GetLength(1); ++i) {
				for (var j = 1; j <= mas.GetLength(0); ++j) {
					var ret = GetIndexes(mas2, i, j);
					string str = $"{ret.center} {ret.top} {ret.bottom} {ret.left} {ret.right}";
					Console.WriteLine($"{str} ");
				}
			}
		}

		public static (int center, int top, int bottom, int left, int right) GetIndexes(int[,] mas, int centerX, int centerY)
		{
			if (mas.GetLength(0) < 3 || mas.GetLength(1) < 3) {
				return (0, 0, 0, 0, 0);
			}

			int center = mas[centerX, centerY];
			var list = new List<int>();
			for (int x = -1, y = 0, i = 0; i < 4; x += y, y = x - y, x = y - x, ++i) {
				list.Add(mas[x + centerX, y + centerY]);
			}

			return (center, list[0], list[2], list[1], list[3]);
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

		public static void TerabunDFS()
		{
			int num = 10;
			var map = new bool[num, num];
			var mapOrigin = new bool[num, num];

			for (int i = 0; i < num; ++i) {
				string s = Console.ReadLine();
				for (int j = 0; j < num; ++j) {
					if (s[j] == 'x') {
						map[i, j] = mapOrigin[i, j] = false;
					} else {
						map[i, j] = mapOrigin[i, j] = true;
					}
				}
			}

			// 指定したマスの座標を起点にして隣接するマスをfalseに変えていく
			void Dfs(int x, int y)
			{
				var vecterX = new int[] { -1, 1, 0, 0 };
				var vecterY = new int[] { 0, 0, -1, 1 };

				map[y, x] = false;

				for (int i = 0; i < 4; ++i) {
					int next_x = x + vecterX[i];
					int next_y = y + vecterY[i];

					if (next_x < 0 || next_y < 0 || next_x >= num || next_y >= num) {
						continue;
					}

					if (map[next_y, next_x] == false) {
						continue;
					}


					Dfs(next_x, next_y);
				}
			}

			// trueとなっている領域の数を数える
			int CalcIslandNum()
			{
				int count = 0;
				for (int i = 0; i < num; ++i) {
					for (int j = 0; j < num; ++j) {
						if (map[i, j] == false) {
							continue;
						}

						Dfs(j, i);
						count++;
					}
				}

				return count;
			}

			// mapの初期化
			void InitializeMap()
			{
				for (int k = 0; k < num; ++k) {
					for (int l = 0; l < num; ++l) {
						map[k, l] = mapOrigin[k, l];
					}
				}
			}

			// 最初から連結成分が1つの場合
			int count = CalcIslandNum();
			if (count == 1) {
				Console.WriteLine("YES");
				return;
			}

			bool isOK = false;

			// 任意の海の1つを島にしてからmapを全探索して連結成分の数を数える
			for (int i = 0; i < num && isOK == false; ++i) {
				for (int j = 0; j < num && isOK == false; ++j) {
					InitializeMap();
					if (map[i, j]) {
						continue;
					}

					// 任意の海の1つを島にしてみる
					map[i, j] = true;

					count = CalcIslandNum();
					if (count == 1) {
						isOK = true;
						break;
					}
				}
			}

			if (isOK) {
				Console.WriteLine("YES");
			} else {
				Console.WriteLine("NO");
			}
		}

		public static void SaitoBSF()
		{
			int n = 10;
			var a = new bool[n, n];
			for (int i = 0; i < n; i++) {
				string temp = Console.ReadLine();
				for (int j = 0; j < n; j++) {
					a[i, j] = temp[j] == 'o';
				}
			}

			void DoIn4(int i, int j, int imax, int jmax, Action<int, int> action)
			{
				int[] delta4_ = { 1, 0, -1, 0, 1 };
				for (int dn = 0; dn < delta4_.Length - 1; ++dn) {
					int d4i = i + delta4_[dn];
					int d4j = j + delta4_[dn + 1];
					if ((uint)d4i < (uint)imax && (uint)d4j < (uint)jmax) {
						action(d4i, d4j);
					}
				}
			}

			bool Check(bool[,] b)
			{
				bool found = false;
				(int i, int j) first = (0, 0);
				for (int i = 0; i < n; i++) {
					for (int j = 0; j < n; j++) {
						if (b[i, j]) {
							first = (i, j);
							found = true;
							break;
						}
					}

					if (found) {
						break;
					}
				}

				var done = new bool[n, n];
				var canReach = new bool[n, n];
				done[first.i, first.j] = true;
				canReach[first.i, first.j] = true;
				var que = new Queue<(int i, int j)>();
				que.Enqueue(first);
				while (que.Count > 0) {
					var cur = que.Dequeue();
					DoIn4(cur.i, cur.j, n, n, (ii, jj) => {
						if (b[ii, jj] && done[ii, jj] == false) {
							canReach[ii, jj] = true;
							que.Enqueue((ii, jj));
						}

						done[ii, jj] = true;
					});
				}

				for (int i = 0; i < n; i++) {
					for (int j = 0; j < n; j++) {
						if (b[i, j] && canReach[i, j] == false) {
							return false;
						}
					}
				}

				return true;
			}

			bool ok = false;
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					bool old = a[i, j];
					a[i, j] = true;
					ok = ok || Check(a);
					a[i, j] = old;
				}
			}

			Console.WriteLine(ok ? "YES" : "NO");
		}

		public static void DfsSample2()
		{
			int n = int.Parse(Console.ReadLine());
			var listXY = new List<(int x, int y)>();
			for (var i = 0; i < n; ++i) {
				var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				listXY.Add((array[0], array[1]));
			}

			long CalcDistance2((int x, int y) p0, (int x, int y) p1)
			{
				long dist = (p0.x - p1.x) * (p0.x - p1.x) + (p0.y - p1.y) * (p0.y - p1.y);
				return dist;
			}

			long answer2 = 0;

			void Dfs(List<int> items, int num, int start)
			{
				if (items.Count == num) {
					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					long max = CalcDistance2(listXY[items[0]], listXY[items[1]]);
					if (answer2 < max) {
						answer2 = max;
					}

					return;
				}

				for (var i = start + 1; i < listXY.Count; ++i) {
					items.Add(i);
					Dfs(items, num, i);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), 2, -1);

			double answer = Math.Round(Math.Sqrt(answer2), 4);
			Console.WriteLine($"{answer}");
		}
	}
}

