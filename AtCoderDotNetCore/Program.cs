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
		public static void ExecTemp()
		{
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			long n = long.Parse(Console.ReadLine());
			var abDict = new Dictionary<(int a, int b), int>();

			for (var j = 0; j < n; ++j) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				int[] vx = { 0, 0, 1, 0, -1, -1, 1, 1, -1 };
				int[] vy = { 0, 1, 0, -1, 0, 1, 1, -1, -1 };
				for (int i = 0; i < vx.Length; i++) {
					int nx = a + vx[i];
					int ny = b + vy[i];

					if (abDict.ContainsKey((nx, ny)) == false) {
						if ((0 <= nx && nx < h) && (0 <= ny && ny < w)) {
							if (vx[i] == 0 && vy[i] == 0) {
								abDict[(nx, ny)] = 1;
							} else {
								abDict[(nx, ny)] = 0;
							}
						}
					} else {
						if (vx[i] == 0 && vy[i] == 0) {
							++abDict[(nx, ny)];
						}
					}
				}
			}

			int Find(int x, int y)
			{
				int count = abDict[(x, y)];
				int[] vx = { 0, 1, 0, -1, -1, 1, 1, -1};
				int[] vy = { 1, 0, -1, 0, 1,  1, -1,-1};
				for (int i = 0; i < vx.Length; i++) {
					int nx = x + vx[i];
					int ny = y + vy[i];
					if (abDict.ContainsKey((nx, ny))) {
						count += abDict[(nx, ny)];
					}
				}

				return count;
			}

			int max = 0;
			foreach (var pos in abDict) {
				int x = pos.Key.a;
				int y = pos.Key.b;
				int count = Find(x, y);
				max = Math.Max(max, count);
			}

			var answer = max;
			Console.WriteLine($"{answer}");
		}

		public static void Exec()
		{
			ExecTemp();
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

		public static void SwapP()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			Console.WriteLine($"{ab[1]} {ab[0]}");
		}

		public static void Poker()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0] == 1 ? 14 : ab[0];
			var b = ab[1] == 1 ? 14 : ab[1];

			var answer = "Draw";
			if (a > b) {
				answer = "Alice";
			} else if (a < b) {
				answer = "Bob";
			}

			Console.WriteLine($"{answer}");
		}

		public static void Snow()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];
			var diff = b - a;

			long index = 0;
			for (var i = 1; i <= 999; ++i) {
				if (i + 1 == diff) {
					index = i;
					break;
				}
			}

			var answer = index * (index + 1) / 2 - a;

			Console.WriteLine($"{answer}");
		}

		public static void Index()
		{
			string s = Console.ReadLine();
			int i = int.Parse(Console.ReadLine());
			var answer = s[i - 1];

			Console.WriteLine($"{answer}");
		}

		public static void Takahashi()
		{
			string X = Console.ReadLine();
			string s = Console.ReadLine();
			var answer = s.Replace(X, "");
			Console.WriteLine($"{answer}");
		}


		public static void A()
		{
			long n = long.Parse(Console.ReadLine());

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static void Nankisei()
		{
			string s = Console.ReadLine();

			int count = 0;
			for (var i = 0; i < s.Length; ++i)
			{
				if (Char.IsNumber(s[i]))
				{
					if (i < s.Length - 1)
					{
						if (Char.IsNumber(s[i + 1]))
						{
							count = int.Parse(s[i].ToString()) * 10 + int.Parse(s[i + 1].ToString());
						}
						else
						{
							count = int.Parse(s[i].ToString());
						}

						break;
					}
					else
					{
						count = int.Parse(s[i].ToString());
						break;
					}
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void JumpingTakahashi()
		{
			var nx = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nx[0];
			var x = nx[1];

			var dp = new bool[n + 1, x + 1];
			dp[0, 0] = true;

			for (var i = 1; i <= n; ++i)
			{
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var a = ab[0];
				var b = ab[1];

				for (int j = 0; j <= x; ++j)
				{
					if (dp[i - 1, j])
					{
						if (j <= x - a)
						{
							dp[i, j + a] = true;
						}

						if (j <= x - b)
						{
							dp[i, j + b] = true;
						}
					}
				}
			}

			/*
			for (int j = 0; j <= x; ++j)
			{
				for (var i = 0; i <= n; ++i)
                {
					Console.Write(dp[i, j] ? "1 " : "0 ");
				}

				Console.WriteLine("");
			}
			*/

			var answer = dp[n, x] ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		// https://c-taquna.hatenablog.com/entry/2020/01/15/014154
		public static int GridBFS(int h, int w, int sx, int sy, bool[,] map)
		{
			int[] vx = { 0, 1 };
			int[] vy = { 1, 0 };

			if (map[sx, sy] == false) {
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

				for (int i = 0; i < vx.Length; i++) {
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

		public static void WeakTakahashi()
		{
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var c = new bool[h, w];
			for (var i = 0; i < h; ++i) {
				var s = Console.ReadLine();
				for (var j = 0; j < s.Length; ++j) {
					c[i, j] = s[j] == '.';
				}
			}

			int step = GridBFS(h, w, 0, 0, c);

			var answer = step + 1;

			Console.WriteLine($"{answer}");
		}

		public static void SecretNumber()
		{
			string s = Console.ReadLine();

			var cList = new List<int>();
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] is 'o') {
					cList.Add(i);
				}
			}

			if (cList.Count > 4) {
				Console.WriteLine($"{0}");
				return;
			}

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

					bool isFound = true;
					int circle = 0;
					for (var j = 0; j < cList.Count; ++j) {
						if (items.Contains(cList[j]) == false) {
							isFound = false;
							break;
						} else {
							++circle;
						}
					}

					if (isFound) {
						for (var i = 0; i < items.Count; ++i) {
							if (s[items[i]] == 'x') {
								isFound = false;
								break;
							}
						}
					}

					if (isFound) {
						/*
						for (var i = 0; i < items.Count; ++i) {
							Console.Write($"{items[i]} ");
						}
						Console.WriteLine($"cCount : {cList.Count}, {circle}");
						*/

						++count;
					}

					return;
				}

				for (var i = 0; i < 10; ++i) {
					items.Add(i);
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), 4);

			var answer = count;

			Console.WriteLine($"{answer}");
		}

		public static void Fiber()
		{
			int n = int.Parse(Console.ReadLine());
			int m = int.Parse(Console.ReadLine());
			var unionFind = new Lib.UnionFind(n);

			for (var i = 0; i < m; ++i) {
				var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				unionFind.Union(array[0] - 1, array[1] - 1);
			}

			var answer = unionFind.GroupCount - 1;

			Console.WriteLine($"{answer}");
		}
	}
}

