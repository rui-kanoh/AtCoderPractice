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

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static void A()
		{
			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];
			Console.WriteLine($"{2 * (a * b + a * c + b * c)}");
		}

		public class Holiday
		{
			public bool isHoliday = true;
			public bool usesPaid = false;
		}

		public static void B()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var h = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var holidays = new Holiday[n];
			for (var i = 0; i < n; ++i) {
				holidays[i] = new Holiday();
				holidays[i].isHoliday = h[i] == 1 ? true : false;
			}

			int max = 0;
			int end = 0;

			int sum = 0;
			int paid = k;
			for (int start = 0; start < n; ++start) {
				// paidが0になるまでendを伸ばす
				while (end < n) {
					if (holidays[end].isHoliday) {
						++sum;
					} else {
						if (paid > 0) {
							--paid;
							holidays[end].usesPaid = true;
							++sum;
						} else {
							break;
						}
					}

					++end;
				}

				max = Math.Max(max, sum);

				if (end == start) {
					++end;
				}

				if (holidays[start].isHoliday) {
					--sum;
				} else {
					if (holidays[start].usesPaid) {
						holidays[start].usesPaid = false;
						++paid;
						--sum;
					}
				}
			}

			var answer = max;
			Console.WriteLine($"{answer}");
		}

		public class UnionFind
		{
			// 親要素のインデックスを保持する
			// 親要素が存在しない(自身がルートである)とき、マイナスでグループの要素数を持つ
			public int[] Parents { get; set; }
			public UnionFind(int n)
			{
				Parents = new int[n];
				for (int i = 0; i < n; i++) {
					// 初期状態ではそれぞれが別のグループ(ルートは自分自身)
					// ルートなのでマイナスで要素数(1個)を保持する
					Parents[i] = -1;
				}
			}

			// 要素xのルート要素はどれか
			public int Find(int x)
			{
				// 親がマイナスの場合は自分自身がルート
				if (Parents[x] < 0) return x;
				// ルートが見つかるまで再帰的に探す
				// 見つかったルートにつなぎかえる
				Parents[x] = Find(Parents[x]);
				return Parents[x];
			}

			// 要素xの属するグループの要素数を取得する
			public int Size(int x)
			{
				// ルート要素を取得して、サイズを取得して返す
				return -Parents[Find(x)];
			}

			// 要素x, yが同じグループかどうか判定する
			public bool Same(int x, int y)
			{
				return Find(x) == Find(y);
			}

			// 要素x, yが属するグループを同じグループにまとめる
			public bool Union(int x, int y)
			{
				// x, y のルート
				x = Find(x);
				y = Find(y);
				// すでに同じグループの場合処理しない
				if (x == y) return false;

				// 要素数が少ないグループを多いほうに書き換えたい
				if (Size(x) < Size(y)) {
					var tmp = x;
					x = y;
					y = tmp;
				}
				// まとめる先のグループの要素数を更新
				Parents[x] += Parents[y];
				// まとめられるグループのルートの親を書き換え
				Parents[y] = x;
				return true;
			}
		}

		public static void C()
		{
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			long q = long.Parse(Console.ReadLine());

			var grid = new bool[h + 2, w + 2];
			var indexDict = new Dictionary<(int h, int w), int>();

			int counter = 0;
			for (var i = 0; i < h + 2; ++i) {
				for (var j = 0; j < w + 2; ++j) {
					indexDict.Add((i, j), counter);
					++counter;
				}
			}

			var unionFind = new UnionFind(counter - 1);

			var answers = new List<string>();
			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				if (query[0] == 1) {
					var r = query[1];
					var c = query[2];
					grid[r, c] = true;

					var center = indexDict[(r, c)];
					if (grid[r - 1, c]) {
						var index = indexDict[(r - 1, c)];
						unionFind.Union(center, index);
					}
					if (grid[r + 1, c]) {
						var index = indexDict[(r + 1, c)];
						unionFind.Union(center, index);
					}
					if (grid[r, c - 1]) {
						var index = indexDict[(r, c - 1)];
						unionFind.Union(center, index);
					}
					if (grid[r, c + 1]) {
						var index = indexDict[(r, c + 1)];
						unionFind.Union(center, index);
					}
				} else {
					var ra = query[1];
					var ca = query[2];
					var rb = query[3];
					var cb = query[4];

					if (grid[ra, ca] == false
						&& grid[rb, cb] == false) {
						answers.Add("No");
					} else {
						var start = indexDict[(ra, ca)];
						var end = indexDict[(rb, cb)];
						var isSame = unionFind.Same(start, end);
						if (isSame) {
							answers.Add("Yes");
						} else {
							answers.Add("No");
						}
					}
				}
			}

			var builder = new StringBuilder();
			foreach (var item in answers) {
				builder.AppendLine(item);
			}

			Console.WriteLine(builder.ToString());
		}

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

		public static void D()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			long deno = (long)(Math.Pow(10, 9) + 7);

			long answer = 0;
			if (n == 1) {
				answer = k % deno;
			} else if (n == 2) {
				answer = (k % deno) * ((k - 1) % deno);
			} else {
				answer = (((k % deno) * ((k - 1) % deno)) % deno) * ModPow(k - 2, n - 2, deno);
			}

			Console.WriteLine($"{answer % deno}");
		}

		public static void E()
		{
			var nst = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nst[0];
			var s = nst[1];
			var t = nst[2];

			var list = new List<(long a, long b)>();

			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				list.Add((ab[0], ab[1]));
			}

			// DPだね
			// n:index, t:時間
			var joy = new long[n + 1, t + 1];

			// 初期条件
			for (var i = 0; i <= t; ++i) {
				joy[0, i] = 0;
			}

			if (s == 0) {
				// 時刻0で花火

				for (var i = 0; i < n; ++i) {
					for (var j = 0; j <= t; ++i) {
						if (j >= list[i].b) {
							joy[i + 1, j] = Math.Max(joy[i, j - list[i].b] + list[i].a, joy[i, j]);
						} else {
							joy[i + 1, j] = joy[i, j];
						}
					}
				}

				Console.WriteLine($"{joy[n, t]}");
			} else {

			}
		}

		public static void F()
		{

		}

		public static void G()
		{

		}

		public static void H()
		{
			var nmk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nmk[0];
			var m = nmk[1];
			var k = nmk[2];

			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			var t = long.Parse(Console.ReadLine());
		}
	}
}

