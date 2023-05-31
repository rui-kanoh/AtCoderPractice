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
using System.Xml.Serialization;

namespace AtCoderDotNetCore
{
	class Program
	{
		static void Main(string[] args)
		{
			Question.Exec();
		}
	}

	public class PriorityQueue3<T> where T : IComparable<T>
	{
		public readonly T[] Array;
		public readonly bool Greater;
		public int Count { get; private set; } = 0;

		public PriorityQueue3(int capacity, bool greater = true)
		{
			this.Array = new T[capacity];
			this.Greater = greater;
		}

		public void Enqueue(T item)
		{
			this.Array[this.Count] = item;
			this.Count += 1;
			this.UpHeap();
		}

		public T Dequeue()
		{
			// 先頭要素を末尾にして再構成
			this.Swap(0, this.Count - 1);
			this.Count -= 1;
			this.DownHeap();

			return this.Array[this.Count];
		}


		private void UpHeap()
		{
			var n = this.Count - 1;
			while (n != 0) {
				// 親要素の座標
				var parent = (n - 1) / 2;

				if (this.Compare(this.Array[n], this.Array[parent]) > 0) {
					this.Swap(n, parent);
					n = parent;
				} else {
					break;
				}
			}
		}

		private void DownHeap()
		{
			var parent = 0;
			while (true) {
				var child = 2 * parent + 1;
				if (child > this.Count - 1) break;

				if (child < this.Count - 1 && this.Compare(this.Array[child], this.Array[child + 1]) < 0) {
					// 左より右の子のほうが大きい値の場合、右を入れ替え対象にする
					child += 1;
				}

				if (this.Compare(this.Array[parent], this.Array[child]) < 0) {
					this.Swap(parent, child);
					parent = child;
				} else {
					break;
				}
			}
		}

		private int Compare(T a, T b)
		{
			var c = a.CompareTo(b);
			if (!this.Greater) {
				c = -c;
			}
			return c;
		}

		private void Swap(int a, int b)
		{
			var tmp = this.Array[a];
			this.Array[a] = this.Array[b];
			this.Array[b] = tmp;
		}
	}

	public class Dijkstra2
	{
		public int N { get; set; }
		public List<Edge>[] G { get; set; }
		public Dijkstra2(int n)
		{
			this.N = n;
			this.G = new List<Edge>[N];
			for (int i = 0; i < N; i++) {
				this.G[i] = new List<Edge>();
			}
		}
		// a から b につながる辺を追加する
		public void Add(int a, int b, long cost, long sat)
		{
			this.G[a].Add(new Edge(b, cost, sat));
		}

		// 単一始点の最短経路を求める
		// 最短経路を探しつつ
		public (long[] cost, long[] sat) GetMinCost(int start, int startSat)
		{
			// 最短経路(コスト)を格納しておく配列(すべての頂点の初期値をINFにしておく)
			var cost = new long[N];
			for (int i = 0; i < N; i++) cost[i] = long.MaxValue;
			cost[start] = 0;

			var sat = new long[N];
			sat[start] = startSat;

			// 未確定の頂点を格納する優先度付きキュー(頂点とコストを格納)
			var q = new PriorityQueue3<P>(this.N, false);
			q.Enqueue(new P(start, 0, startSat));

			// 未確定の頂点があればすべて確認する
			while (q.Count > 0) {
				var p = q.Dequeue();
				// すでに記録されているコストと異なる(より大きい)場合、無視する。
				if (p.Cost > cost[p.A]) {
					continue;
				}

				// 取り出した頂点を確定する。
				// 確定した頂点から直接辺でつながる頂点をループ
				foreach (var e in this.G[p.A]) {
					// すでに記録されているコストより小さいコストの場合
					if (cost[e.To] > p.Cost + e.Cost) {
						// コストを更新して、候補としてキューに入れる
						cost[e.To] = p.Cost + e.Cost;
						sat[e.To] = p.Sat + e.Sat;
						q.Enqueue(new P(e.To, cost[e.To], sat[e.To]));
					} else if (cost[e.To] == p.Cost + e.Cost) {
						sat[e.To] = Math.Max(sat[e.To], p.Sat + e.Sat);
					}
				}
			}

			return (cost, sat);
		}

		// 接続先の頂点とコストを格納する辺のデータ
		public struct Edge
		{
			public int To;
			public long Cost;
			public long Sat;
			public Edge(int to, long cost, long sat)
			{
				this.To = to;
				this.Cost = cost;
				Sat = sat;
			}
		}

		// 頂点とその頂点までのコストを記録
		public struct P : IComparable<P>
		{
			public int A;
			public long Cost;
			public long Sat;
			public P(int a, long cost, long sat)
			{
				this.A = a;
				this.Cost = cost;
				Sat = sat;
			}

			public int CompareTo(P other)
			{
				return Cost.CompareTo(other.Cost);
			}
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
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			var dij = new Dijkstra2(n);
			for (var i = 0; i < m; ++i) {
				var uvt = Console.ReadLine().Split(" ").Select(j => int.Parse(j)).ToArray();
				var u = uvt[0] - 1;
				var v = uvt[1] - 1;
				var t = uvt[2];
				dij.Add(u, v, t, a[v]);
			}

			(var cost, var sat) = dij.GetMinCost(0, a[0]);

			var answer = sat[n - 1];
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

		public static void TwoCoins()
		{
			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			var answer = a + b >= c ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void Louis()
		{
			int n = int.Parse(Console.ReadLine());
			string[] strs = Console.ReadLine().ToLower().Split(" ");

			var dict = new Dictionary<char, string>();
			dict['a'] = "";
			dict['i'] = "";
			dict['u'] = "";
			dict['e'] = "";
			dict['o'] = "";

			dict['b'] = "1";
			dict['c'] = "1";

			dict['d'] = "2";
			dict['w'] = "2";

			dict['t'] = "3";
			dict['j'] = "3";

			dict['f'] = "4";
			dict['q'] = "4";

			dict['l'] = "5";
			dict['v'] = "5";

			dict['s'] = "6";
			dict['x'] = "6";

			dict['p'] = "7";
			dict['m'] = "7";

			dict['h'] = "8";
			dict['k'] = "8";

			dict['n'] = "9";
			dict['g'] = "9";

			dict['z'] = "0";
			dict['r'] = "0";

			var builder = new StringBuilder();

			bool isFirst = true;
			foreach (var s in strs) {
				string temp = "";
				for (var i = 0; i < s.Length; ++i) {
					if (dict.ContainsKey(s[i]) == false) {
						continue;
					}

					temp += dict[s[i]];
				}

				if (string.IsNullOrWhiteSpace(temp) == false) {
					if (isFirst == false) {
						builder.Append(" ");
					} else {
						isFirst = false;
					}

					builder.Append(temp);
				}
			}

			var answer = builder.ToString();
			Console.WriteLine($"{answer}");
		}

		public static void Kaizodo()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			var a = new int[n];
			for (var i = 0; i < n; ++i) {
				a[i] = int.Parse(Console.ReadLine());
			}

			if (n < k) {
				Console.WriteLine($"0");
				return;
			}

			if (n == 1 && k == 1) {
				Console.WriteLine($"1");
				return;
			}

			int count = 0;
			var list = new List<int>();
			list.Add(a[0]);
			for (var i = 1; i < n; ++i) {
				if (a[i - 1] < a[i]) {
					list.Add(a[i]);
				} else {
					if (list.Count >= k) {
						count += list.Count - k + 1;
					}

					list.Clear();
					list.Add(a[i]);
				}
			}

			if (list.Count >= k) {
				count += list.Count - k + 1;
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		// DPでやってみた場合（断念）
		public static void KaizodoDP()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			var a = new int[n];
			for (var i = 0; i < n; ++i) {
				a[i] = int.Parse(Console.ReadLine()) / 100;
			}

			var amax = a.Max();
			var dp = new bool[n + 1, amax + 1];
			var dpCount = new int[n + 1, amax + 1];
			dp[0, 0] = true;

			for (var i = 0; i < n; ++i) {
				for (var j = 0; j <= amax; ++j) {
					if (dp[i, j]) {
						if (a[i] > j && dpCount[i, j] < k) {
							dp[i + 1, a[i]] = true;
							dpCount[i + 1, a[i]] = Math.Min(dpCount[i + 1, a[i]], dpCount[i, j]);
						}

						dp[i + 1, j] = true;
						dpCount[i + 1, j] = Math.Min(dpCount[i + 1, j], dpCount[i, j]);
					}
				}
			}

			int count = 0;
			for (var j = 0; j <= amax; ++j) {
				if (dp[n, j] && dpCount[n, j] == k) {
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}
	}
}

