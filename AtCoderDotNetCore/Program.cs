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
			var list = new List<string>();

			for (var i = 0; i < n; ++i) {
				var str = Console.ReadLine();
				list.Add(str);
			}

			// 番兵
			list.Add("/");

			var answer = 0;
			long countL = 0;
			long countR = 0;

			bool rNow = false;
			for (int i = 0; i < list.Count; i++) {
				if (list[i] != "\\") {
					if (rNow) {
						if (countL == countR && countL != 0) {
							++answer;
						}

						countL = 0;
						countR = 0;
					}

					rNow = false;
					++countL;
				} else {
					rNow = true;
					++countR;
				}
			}

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
			long n = long.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{
			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int a = array[0];
			int b = array[1];

			int answer = a + (a <= b ? 0 : -1);
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			long n = long.Parse(Console.ReadLine());
			var list = new List<string>();

			for (var i = 0; i < n; ++i) {
				var str = Console.ReadLine();
				list.Add(str);
			}

			var answer = 0;
			long countL = 0;
			long countR = 0;

			foreach (var item in list) {
				if (item == "/") {
					++countL;
				} else {
					++countR;
				}

				if (item == "\\" && countL > 0 && countL == countR) {
					++answer;
					countL = 0;
					countR = 0;
				}

				if (item == "\\" && countL == 0) {
					countR = 0;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			string s = Console.ReadLine();
			string t = Console.ReadLine();
			var answer = -1;

			if (s == t) {
				Console.WriteLine("0");
				return;
			}

			var str = s;
			for (var i = 1; i <= s.Length; ++i) {
				var front = str.Substring(s.Length - 1, 1);
				str = front + str.Substring(0, s.Length - 1);
				if (str == t) {
					answer = i;
					break;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void D()
		{
			string s = Console.ReadLine();
			string t = Console.ReadLine();
			var answer = "UNRESTORABLE";

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
	}
}

