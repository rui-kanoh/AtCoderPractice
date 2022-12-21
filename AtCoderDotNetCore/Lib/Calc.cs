using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderDotNetCore
{
	public static class Calc
	{
		public static long Factrial(long i)
		{
			if (i == 0) {
				return 1;
			}

			return i * Factrial(i - 1);
		}

		/// <summary>
		/// x / a以上の最大の整数を求める
		/// </summary>
		public static long Ceiling(long x, long a)
		{
			return Convert.ToInt32(Math.Ceiling((double)x / a));
		}

		//------------------------------------------------------------------------------------//
		/// <summary>
		/// べき乗の配列を作成
		/// </summary>
		/// <param name="value">べき乗の数</param>
		/// <param name="exp">
		/// べき乗の指数
		/// </param>
		/// <returns>2のべき乗の配列</returns>
		//! @author KANOH Rui
		//------------------------------------------------------------------------------------//
		public static BigInteger[] CalcExponentiations(long value, long exp)
		{
			int number = (int)Math.Round(Math.Log2(exp)) + 1;
			var exponentiations = new BigInteger[number];
			exponentiations[0] = value;
			for (var i = 1; i < number; ++i) {
				exponentiations[i] = exponentiations[i - 1] * exponentiations[i - 1];
			}

			return exponentiations;
		}

		public static void DfsBool(List<bool> items, int num)
		{
			if (items.Count == num) {
				foreach (var item in items) {
					Console.Write($"{item} ");
				}
				Console.WriteLine("");

				return;
			}

			Array.ForEach(
				new[] { true, false },
				value => {
					items.Add(value);
					DfsBool(items, num);
					items.RemoveAt(items.Count - 1);
				});
		}

		public static bool IsPrime(long num)
		{
			if (num < 2) return false;
			else if (num == 2) return true;
			else if (num % 2 == 0) return false;

			double sqrtNum = Math.Sqrt(num);
			for (int i = 3; i <= sqrtNum; i += 2) {
				if (num % i == 0) {
					// 素数ではない
					return false;
				}
			}

			// 素数である
			return true;
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

		public static void SaitoBFS()
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


		// https://algo-logic.info/prime-fact/
		public static Dictionary<long, long> GetPrimeFactor(long n)
		{
			var ret = new Dictionary<long, long>();
			for (long i = 2; i * i <= n; i++) {
				if (n % i != 0) continue;
				long tmp = 0;
				while (n % i == 0) {
					tmp++;
					n /= i;
				}

				ret.Add(i, tmp);
			}

			if (n != 1) {
				ret.Add(n, 1);
			}

			return ret;
		}

		// 約数の列挙
		public static long[] GetDivisors(long k, bool doesSort = false)
		{
			var list = new List<long>();
			long max = (long)Math.Sqrt(k);
			for (var i = 1; i <= max; ++i) {
				if (k % i == 0) {
					list.Add(i);
					if (i != k / i) {
						list.Add(k / i);
					}
				}
			}

			if (doesSort) {
				list.Sort();
			}

			return list.ToArray();
		}

		// https://webbibouroku.com/Blog/Article/cs-permutation
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

		// https://oraclesqlpuzzle.ninja-web.net/kyoupro-old/kyoupro-memo-006.html
		public static bool NextPermutation(ref string pStr)
		{
			//右から左に見ていき、初めて小さくなった要素を求める
			int WillChangeInd = -1;
			char[] wkCharArr = pStr.ToCharArray();
			for (int I = wkCharArr.GetUpperBound(0) - 1; I >= 0; I--) {
				if (wkCharArr[I] < wkCharArr[I + 1]) {
					WillChangeInd = I;
					break;
				}
			}

			if (WillChangeInd == -1) {
				pStr = new string(wkCharArr.Reverse().ToArray());
				return false;
			}

			//初めて小さくなった要素より右の変更すべき要素を求める
			int MinCharInd = WillChangeInd + 1;
			for (int I = WillChangeInd + 2; I <= wkCharArr.GetUpperBound(0); I++) {
				if (wkCharArr[WillChangeInd] > wkCharArr[I]) continue;

				if (wkCharArr[MinCharInd] > wkCharArr[I]) {
					MinCharInd = I;
				}
			}

			//変更すべき要素と3角交換
			char wkChar = wkCharArr[WillChangeInd];
			wkCharArr[WillChangeInd] = wkCharArr[MinCharInd];
			wkCharArr[MinCharInd] = wkChar;

			//正順で連結
			var sb = new System.Text.StringBuilder();
			for (int I = 0; I <= WillChangeInd; I++) {
				sb.Append(wkCharArr[I]);
			}
			//逆順で連結
			for (int I = wkCharArr.GetUpperBound(0); I >= WillChangeInd + 1; I--) {
				sb.Append(wkCharArr[I]);
			}

			pStr = sb.ToString();
			return true;
		}

		// 組み合わせ列挙
		//https://qiita.com/gushwell/items/74a96f56ccb64db3660c
		public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items, int k, bool withRepetition)
		{
			if (k == 1) {
				foreach (var item in items)
					yield return new T[] { item };
				yield break;
			}
			foreach (var item in items) {
				var leftside = new T[] { item };

				// item よりも前のものを除く （順列と組み合わせの違い)
				// 重複を許さないので、unusedから item そのものも取り除く
				var unused = withRepetition ? items : items.SkipWhile(e => !e.Equals(item)).Skip(1).ToList();

				foreach (var rightside in Enumerate(unused, k - 1, withRepetition)) {
					yield return leftside.Concat(rightside).ToArray();
				}
			}
		}

		// 2分累乗法とmod演算
		public static long ModPow(long x, long e, long denominator)
		{
			long value = 1;

			while (e != 0x0) {
				if ((e & 0x1) != 0x0) {
					value = (value * x) % denominator;
				}

				e >>= 1;
				x = (x * x) % denominator;
			}

			return value;
		}

		// https://c-taquna.hatenablog.com/entry/2020/01/15/014154
		public static int GridBFS(int h, int w, int sx, int sy, int gx, int gy, bool[,] map)
		{
			int[] vx = { 0, 1, 0, -1 };
			int[] vy = { 1, 0, -1, 0 };

			if (map[sx, sy] == false || map[gx, gy] == false)
			{
				return 0;
			}

			if (sx == gx && sy == gy)
			{
				return 0;
			}

			var dist = new bool[h, w];
			var tq = new Queue<(int, int, int)>();
			int step = 0;
			tq.Enqueue((sx, sy, step));
			dist[sx, sy] = true;
			while (0 < tq.Count) {
				var q = tq.Dequeue();
				int x = q.Item1;
				int y = q.Item2;
				step = q.Item3;

				if (x == gx && y == gy) {
					break;
				}

				for (int i = 0; i < 4; i++) {
					int nx = x + vx[i];
					int ny = y + vy[i];
					if ((0 <= nx && nx < h) && (0 <= ny && ny < w) && map[nx, ny] && dist[nx, ny] == false) {
						dist[nx, ny] = true;
						tq.Enqueue((nx, ny, step + 1));
					}
				}
			}

			return step;
		}

		// https://qiita.com/asksaito/items/8fe448d21b394eb35582
		public static List<int> GeneratePrime(int max)
		{
			System.Diagnostics.Debug.Assert(max >= 2);  // maxは2以上の数

			int prime;
			double sqrtMax = Math.Sqrt(max);
			var primeList = new List<int>();

			// ■ステップ 1
			// 探索リストに2からxまでの整数を昇順で入れる。
			var searchList = Enumerable.Range(2, max - 1).ToList();

			do {
				// ■ステップ 2
				// 探索リストの先頭の数を素数リストに移動し、その倍数を探索リストから篩い落とす。
				prime = searchList.First();
				// 素数リストに追加
				primeList.Add(prime);
				// 倍数をふるい落とす
				searchList.RemoveAll(n => n % prime == 0);

				// ■ステップ 3
				// 上記の篩い落とし操作を探索リストの先頭値がxの平方根に達するまで行う。
			} while (prime < sqrtMax);

			// ■ステップ 4
			// 探索リストに残った数を素数リストに移動して処理終了。
			primeList.AddRange(searchList);

			return primeList;
		}

		// https://www.hanachiru-blog.com/entry/2020/03/15/120000
		public static BigInteger nCk(long n, long k)
		{
			if (n < k) return 0;
			if (n == k) return 1;

			BigInteger x = 1;
			for (BigInteger i = 0; i < k; i++) {
				x = x * (n - i) / (i + 1);
			}

			return x;
		}
	}
}
