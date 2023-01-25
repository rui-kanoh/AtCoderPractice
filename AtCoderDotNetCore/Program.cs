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
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var a = new int[h, w];
			var hash = new HashSet<int>();
			for (var i = 0; i < h; ++i) {
				var array = Console.ReadLine().Split(" ").Select(k => int.Parse(k)).ToArray();
				for (var j = 0; j < w; ++j) {
					a[i, j] = array[j];

					if (hash.Contains(array[j]) == false) {
						hash.Add(array[j]);
					}
				}
			}

			if (h == 1) {
				var mass = new int[w];

				void Initialize()
				{
					for (var i = 0; i < w; ++i) {
						mass[i] = a[0, i];
					}
				}

				// 各マスについて任意に色を変更して連結成分の最大値を調べる
				int maxCount = 0;
				for (var j = 0; j < h; ++j) {
					Initialize();
					foreach (int color in hash) {
						int origin = mass[j];
						if (origin == color) {
							continue;
						}

						// 連結成分を塗りつぶす
						mass[j] = color;
						for (var k = j + 1; k < h; ++k) {
							if (mass[k] == origin) {
								mass[k] = color;
							}
						}

						int count = Calc(color);
						maxCount = Math.Max(maxCount, count);
					}
				}

				// 連結成分の最大の数を数える
				int Calc(int color)
				{
					int max = 0;
					int count = 1;
					for (var j = 1; j < h; ++j) {
						if (a[0, j - 1] == a[0, j]) {
							++count;

							max = Math.Max(count, max);
						} else {
							count = 1;
						}
					}

					return max;
				}

				var answer = maxCount;
				Console.WriteLine($"{answer}");
			} else {

				// 小課題2,3
				if (h <= 30 && w <= 30) {
					var map = new bool[h, w];

					// 全探索して連結成分の数を数える
					foreach (int color in hash) {
						InitializeMap();
						int max = Calc(color);
					}

					// 指定したマスの座標を起点にして隣接する同じ色のマスをtrueに変えていく
					int Dfs(int x, int y, int color, int count)
					{
						var vecterX = new int[] { -1, 1, 0, 0 };
						var vecterY = new int[] { 0, 0, -1, 1 };

						map[y, x] = true;

						for (int i = 0; i < 4; ++i) {
							int next_x = x + vecterX[i];
							int next_y = y + vecterY[i];

							if (next_x < 0 || next_y < 0 || next_x >= h || next_y >= w) {
								continue;
							}

							if (map[next_x, next_y]) {
								continue;
							}

							// 違う色の場合に抜ける
							if (a[next_x, next_y] != color) {
								break;
							}

							++count;
							return Dfs(next_x, next_y, color, count);
						}

						return count;
					}

					// ある色についてtrueとなっている領域の数の最大値を数える
					int Calc(int color)
					{
						int max = 0;
						for (int i = 0; i < h; ++i) {
							for (int j = 0; j < w; ++j) {
								if (map[i, j]) {
									continue;
								}

								int count2 = Dfs(i, j, color, 0);
								max = Math.Max(max, count2);
							}
						}

						return max;
					}

					// mapの初期化
					void InitializeMap()
					{
						for (int k = 0; k < h; ++k) {
							for (int l = 0; l < w; ++l) {
								map[k, l] = false;
							}
						}
					}
				}
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

		public static void SnakeToy()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var l = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			l.Sort((a, b) => b.CompareTo(a));

			int count = 0;
			for (var i = 0; i < k; ++i) {
				count += l[i];
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void Celcius()
		{
			int n = int.Parse(Console.ReadLine());

			var answer = (9.0 / 5.0 * n) + 32.0;
			Console.WriteLine($"{answer}");
		}

		public static void KenkenRace()
		{
			var nabcd = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nabcd[0];
			var a = nabcd[1] - 1;
			var b = nabcd[2] - 1;
			var c = nabcd[3] - 1;
			var d = nabcd[4] - 1;
			string s = Console.ReadLine();
			var mass = new bool[s.Length];

			bool isOK = true;
			for (var i = 0; i < s.Length; ++i) {
				mass[i] = s[i] == '.';

				if ((i == c || i == d) && mass[i] == false) {
					isOK = false;
					break;
				}

				if (i > 0 && i >= a && i <= d) {
					if (mass[i - 1] == false && mass[i] == false) {
						isOK = false;
						break;
					}
				}
			}

			if (isOK) {
				if (c < d) {
					isOK = true;
				} else {
					bool exists3blank = false;
					for (var i = b; i <= d; ++i) {
						if (i > 1
							&& i < s.Length - 1
							&& exists3blank == false) {
							if (mass[i - 1] && mass[i] && mass[i + 1]) {
								exists3blank = true;
								break;
							}
						}
					}

					isOK = exists3blank;
				}
			}

			var answer = isOK ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void FriendsFriend()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var lists = new HashSet<int>[n];
			for (var i = 0; i < n; ++i) {
				lists[i] = new HashSet<int>();
			}

			for (var i = 0; i < m; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var a = ab[0] - 1;
				var b = ab[1] - 1;
				lists[a].Add(b);
				lists[b].Add(a);
			}

			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				var hash = new HashSet<int>();
				foreach (var item in lists[i]) {
					foreach (var item2 in lists[item]) {
						if (hash.Contains(item2) == false && i != item2 && lists[i].Contains(item2) == false) {
							hash.Add(item2);
						}
					}
				}

				builder.AppendLine($"{hash.Count}");
			}

			var answer = builder.ToString();
			Console.Write($"{answer}");
		}
	}
}

