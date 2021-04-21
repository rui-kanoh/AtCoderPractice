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
			var b1 = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var b2 = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var c1 = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var c2 = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var c3 = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int num = 9;

			var dict = new Dictionary<(int i, int j), int>() {
				{ (1, 1), 0 },
				{ (1, 2), 1 },
				{ (1, 3), 2 },
				{ (2, 1), 3 },
				{ (2, 2), 4 },
				{ (2, 3), 5 },
				{ (3, 1), 6 },
				{ (3, 2), 7 },
				{ (3, 3), 8 },
			};

			int maxO = 0;
			int maxX = 0;

			void Dfs(List<string> items, int num)
			{
				if (items.Count == num) {
					int countO = items.Count(x => x == "o");
					int countX = items.Count(x => x == "x");
					if (countO != 5 || countX != 4) {
						return;
					}

					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					for (var i = 1; i <= 2; ++i) {
						for (var j = 1; j <= 3; ++j) {
							if (items[dict[(i, j)]] == items[dict[(i + 1, j)]]) {
								countO += i == 1 ? b1[j - 1] : b2[j - 1];
							} else {
								countX += i == 1 ? b1[j - 1] : b2[j -1];
							}
						}
					}

					for (var i = 1; i <= 3; ++i) {
						for (var j = 1; j <= 2; ++j) {
							if (items[dict[(i, j)]] == items[dict[(i, j + 1)]]) {
								countO += i == 1 ? c1[j - 1] : i == 2 ? c2[j - 1] : c3[j - 1];
							} else {
								countX += i == 1 ? c1[j - 1] : i == 2 ? c2[j - 1] : c3[j - 1];
							}
						}
					}

					maxO = Math.Max(countO, maxO);
					maxX = Math.Max(countX, maxX);

					return;
				}

				var strs = new[] { "o", "x" };
				foreach (var str in strs) {
					items.Add(str);
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<string>(), num);

			Console.WriteLine($"{maxO}");
			Console.WriteLine($"{maxX}");
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
			var abc = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			long answer = b;
			if (c > a + b + 1) {
				c = a + b + 1;
			}

			answer += c;

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var abc = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			BigInteger deno = (BigInteger)Math.Pow(10.0, 9.0) + 7;
			BigInteger answer = ((BigInteger)(a % deno) * (BigInteger)(b % deno) * (BigInteger)(c % deno)) % (BigInteger)deno;

			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			var answer = (long)0;
			for (var i = 0; i < n; ++i) {
				answer += a[i] - 1;
			}

			Console.WriteLine($"{answer}");
		}

		public static void D()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();

			a.Sort();
			int max = a[a.Count - 1];
			a.RemoveAt(a.Count - 1);
			if (a.Count == 1) {
				Console.WriteLine($"{max} {a[0]}");
				return;
			}

			var answer = 0;
			var ret = BinarySearch(max / 2, a);
			if (ret.isFound) {
				answer = ret.left;
			} else {
				int left = Math.Abs(max / 2 - a[ret.left]);
				int right = Math.Abs(max / 2 - a[ret.right]);
				if (left < right) {
					answer = a[ret.left];
				} else {
					answer = a[ret.right];
				}
			}

			Console.WriteLine($"{max} {answer}");

			void Exec2()
			{
				int n = int.Parse(Console.ReadLine());
				var alist = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
				alist.Sort();

				int max = alist[alist.Count - 1];
				alist.RemoveAt(alist.Count - 1);

				(bool isFound, int left, int right) BinarySearch(int value, List<int> list)
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

				var ret = BinarySearch(max / 2, alist);
				int answer = 0;
				if (alist.Count == 1) {
					answer = alist[0];
				} else if (ret.isFound) {
					answer = alist[ret.left];
				} else {
					int left = Math.Abs(max / 2 - alist[ret.left]);
					int right = Math.Abs(max / 2 - alist[ret.right]);
					int min = Math.Min(left, right);
					if (left < right) {
						answer = alist[ret.left];
					} else {
						answer = alist[ret.right];
					}
				}

				string str = $"{max} {answer}";

				Console.WriteLine(str);
			}
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

