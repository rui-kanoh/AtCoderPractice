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
			long n = long.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{
			var array = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var x = array[0];
			var a = array[1];
			var b = array[2];
			if (Math.Abs(x - a) < Math.Abs(x - b)) {
				Console.WriteLine("A"); ;
			} else {
				Console.WriteLine("B"); ;
			}
		}

		public static void B()
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

		public static void B2 (){
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

		public static void C()
		{
			int K = int.Parse(Console.ReadLine());

			int CalcCount(int d, int K)
			{
				int r = d / 2;
				int rr = r * r;
				int blockCount = d / K;

				var lists = new List<List<bool>>();
				for (var i = 0; i <= blockCount; ++i) {
					var list = new List<bool>();
					for (var j = 0; j <= blockCount; ++j) {
						long distX = Math.Abs(K * i - r);
						long distY = Math.Abs(K * j - r);
						long dist = distX * distX + distY * distY;
						bool inCircle = false;
						if (dist <= rr) {
							inCircle = true;
						}
						list.Add(inCircle);
					}
					lists.Add(list);
				}

				int count = 0;
				for (var i = 0; i < blockCount; ++i) {
					for (var j = 0; j < blockCount; ++j) {
						if (lists[i][j]
							&& lists[i + 1][j]
							&& lists[i][j + 1]
							&& lists[i + 1][j + 1]
							&& lists[i + 1][j + 1]) {
							++count;
						}
					}
				}

				//int count = list.Count(x => x != false);
				//int sqCount = (int)Math.Sqrt(count) - 1;
				//sqCount = sqCount * sqCount;
				return count;
			}

			int sqCount200 = CalcCount(200, K);
			int sqCount300 = CalcCount(300, K);
			Console.WriteLine($"{sqCount200} {sqCount300}");
		}

		public static void D()
		{
			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			var dict = new Dictionary<string, int>();
			dict.Add("a", array[1]);
			dict.Add("b", array[2]);
			dict.Add("c", array[3]);

			var listL = new List<int>();
			for (var i = 0; i < n; ++i) {
				listL.Add(int.Parse(Console.ReadLine()));
			}

			int min = int.MaxValue;

			void Dfs(List<string> items, int num)
			{
				if (items.Count == num) {
					var sumA = 0;
					var sumB = 0;
					var sumC = 0;
					var countA = -1;
					var countB = -1;
					var countC = -1;
					for (var i = 0; i < items.Count; ++i) {
						if (items[i] == "a") {
							sumA += listL[i];
							++countA;
						} else if (items[i] == "b") {
							sumB += listL[i];
							++countB;
						} else if (items[i] == "c") {
							sumC += listL[i];
							++countC;
						}
					}

					if (countA == -1 || countB == -1 || countC == -1) {
						return;
					}

					int answer = (countA + countB + countC) * 10
						+ Math.Abs(dict["a"] - sumA)
						+ Math.Abs(dict["b"] - sumB)
						+ Math.Abs(dict["c"] - sumC);
					if (min > answer) {
						min = answer;
					}

					return;
				}

				for (var i = 0; i <= (int)('d' - 'a'); ++i) {
					items.Add($"{(char)('a' + i)}");
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<string>(), n);

			Console.WriteLine($"{min}");
		}

		public static void E()
		{
			//int n = int.Parse(Console.ReadLine());

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			var dict = new Dictionary<string, int>();
			dict.Add("a", array[1]);
			dict.Add("b", array[2]);
			dict.Add("c", array[3]);

			var listL = new List<int>();
			for (var i = 0; i < n; ++i) {
				listL.Add(int.Parse(Console.ReadLine()));
			}

			int min = int.MaxValue;

			void Dfs(List<string> items, int num)
			{
				if (items.Count == num) {
					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					var sumA = 0;
					var sumB = 0;
					var sumC = 0;
					var countA = -1;
					var countB = -1;
					var countC = -1;
					for (var i = 0; i < items.Count; ++i) {
						if (items[i] == "a") {
							sumA += listL[i];
							++countA;
						} else if (items[i] == "b") {
							sumB += listL[i];
							++countB;
						} else if (items[i] == "c") {
							sumC += listL[i];
							++countC;
						}
					}

					if (countA == -1 || countB == -1 || countC == -1) {
						return;
					}

					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					int answer = (countA + countB + countC) * 10
						+ Math.Abs(dict["a"] - sumA)
						+ Math.Abs(dict["b"] - sumB)
						+ Math.Abs(dict["c"] - sumC);
					//Console.WriteLine($"{answer}");
					if (min > answer) {
						min = answer;
					}

					return;
				}

				for (var i = 0; i <= (int)('d' - 'a'); ++i) {
					items.Add($"{(char)('a' + i)}");
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<string>(), n);

			Console.WriteLine($"{min}");
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
	}
}

