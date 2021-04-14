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
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int a = ab[0];
			int b = ab[1];
			if ((a + b) % 3 == 0 || a % 3 == 0 || b % 3 == 0) {
				Console.WriteLine("Possible");
			} else {
				Console.WriteLine("Impossible");
			}
		}

		public static void B()
		{
			string a = Console.ReadLine();
			int b = int.Parse(Console.ReadLine());

			int ama = b % a.Length;
			int index = ama > 0 ? ama - 1 : a.Length - 1;
			var answer = a[index];

			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int n = nm[0];
			int m = nm[1];
			var klist = new List<int>();
			var slists = new List<List<int>>();
			for (var i = 0; i < m; ++i) {
				var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				klist.Add(array[0]);
				var slist = new List<int>();
				for (var j = 1; j <= array[0]; ++j) {
					slist.Add(array[j]);
				}

				slists.Add(slist);
			}

			var listP = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();

			int count = 0;

			void Dfs(List<int> items, int num)
			{
				if (items.Count == num) {
					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/
					int lampCount = 0;
					for (var i = 0; i < m; ++i) {
						int onCount = 0;
						for (var j = 0; j < klist[i]; ++j) {
							int index = slists[i][j] - 1;
							if (items[index] == 1) {
								++onCount;
							}
						}

						if (onCount % 2 == listP[i]) {
							++lampCount;
						}
					}

					if (lampCount == m) {
						++count;
					}

					return;
				}

				for (var i = 0; i <= 1; ++i) {
					items.Add(i);
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), n);

			Console.WriteLine($"{count}");
		}

		public static void D()
		{
				var nmk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				int n = nmk[0];
				int m = nmk[1];
				int k = nmk[2];

				var sg = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				int s = sg[0];
				int g = sg[1];
				if (s > g) {
					int temp = s;
					s = g;
					g = temp;
				}

				var alist = new List<int>();
				var blist = new List<int>();
				var dlist = new List<int>();
				var sumList = new List<int>();
				for (var i = 0; i < m; ++i) {
					var abd = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
					alist.Add(abd[0]);
					blist.Add(abd[1]);
					dlist.Add(abd[2]);
					if (i == 0) {
						sumList.Add(0);
					} else {
						sumList.Add(dlist[i - 1] + dlist[i]);
					}
				}

				var xlist = new List<int>();
				var flist = new List<int>();
				for (var i = 0; i < m; ++i) {
					var xf = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
					xlist.Add(xf[0]);
					flist.Add(xf[1]);
				}

				var answer = int.MaxValue;
				int cost = -1;

				int CalcCost(int s, int g)
				{
					int cost = -1;
					var dist = sumList[g] - sumList[s];
					int index = 0;
					for (var i = 0; i < xlist.Count; ++i) {
						if (xlist[i] >= dist) {
							index = i;
							break;
						}
					}

					cost = flist[index];
					return cost;
				}

				if (s - g == 1) {
					cost = CalcCost(s, g);
					answer = Math.Min(answer, cost);
					Console.WriteLine($"{answer}");
					return;
				}

				for (var i = 1; i < g - s; ++i) {
					int cost1 = CalcCost(s, s + i);
					int cost2 = CalcCost(s + i, g);
					cost = cost1 + cost2;
					answer = Math.Min(answer, cost);
				}

				Console.WriteLine($"{answer}");
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

