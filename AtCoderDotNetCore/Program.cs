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
using System.Security.Cryptography;

namespace AtCoderDotNetCore
{
	class Program
	{
		static void Main(string[] args)
		{
			Question.Exec();
		}
	}

	public class UnionFind
	{
		List<int> parents;

		public int GroupCount { get; private set; }

		public UnionFind(int x)
		{
			parents = Enumerable.Repeat(-1, x).ToList();
			GroupCount = x;
		}

		public int Find(int x)
		{
			if (parents[x] < 0) return x;
			else {
				parents[x] = Find(parents[x]);
				return parents[x];
			}
		}

		public void Union(int x, int y)
		{
			(x, y) = (Find(x), Find(y));

			if (x != y) {
				if (Count(x) < Count(y)) (x, y) = (y, x);
				parents[x] += parents[y];
				parents[y] = x;
				GroupCount--;
			}
		}

		public int Count(int x) => -parents[Find(x)];

		public bool IsSame(int x, int y) => Find(x) == Find(y);
	}

	public static class Question
	{
		public static void Exec()
		{
			ExecTemp();
		}

		public static (int step, bool canReach, int fx, int fy) GridBFS(int h, int w, int sx, int sy, int gx, int gy, bool[,] map)
		{
			int[] vx = { 0, 1, 0, -1 };
			int[] vy = { 1, 0, -1, 0 };

			if (map[sx, sy] == false || map[gx, gy] == false) {
				return (0, false, 0, 0);
			}

			if (sx == gx && sy == gy) {
				return (0, false, 0, 0);
			}

			var dist = new bool[h, w];
			var tq = new Queue<(int, int, int)>();
			int step = 0;
			tq.Enqueue((sx, sy, step));
			dist[sx, sy] = true;

			bool canReach = false;

			int fx = 0;
			int fy = 0;
			while (0 < tq.Count) {
				var q = tq.Dequeue();
				int x = q.Item1;
				int y = q.Item2;
				step = q.Item3;

				if (x == gx && y == gy) {
					canReach = true;
					break;
				}

				for (int i = 0; i < 4; i++) {
					int nx = x + vx[i];
					int ny = y + vy[i];
					if ((0 <= nx && nx < h) && (0 <= ny && ny < w) && dist[nx, ny] == false
						&& map[nx, ny]) {
						/*
						if (map[nx, ny] == false) {
							if (brokenCount < 2) {
								++brokenCount;
								map[nx, ny] = true;
							} else {
								continue;
							}
						}
						*/

						dist[nx, ny] = true;
						tq.Enqueue((nx, ny, step + 1));
					}
				}

				if (0 == tq.Count) {
					Console.WriteLine($"{x} {y}");
					fx = x;
					fy = y;
					break;
				}
			}

			return (step, canReach, fx, fy);
		}

		public static void ExecTemp()
		{
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];

			var map = new bool[h, w];

			int sx = 0;
			int sy = 0;
			int gx = 0;
			int gy = 0;
			for (var i = 0; i < h; ++i) {
				var temp = Console.ReadLine();
				for (var j = 0; j < w; ++j) {
					if (temp[j] is 's' or 'g' or '.') {
						map[i, j] = true;

						if (temp[j] is 's') {
							sx = i;
							sy = j;
						} else if (temp[j] is 'g') {
							gx = i;
							gy = j;
						}
					} else {
						map[i, j] = false;
					}
				}
			}

			(int step, bool canReach, int fx, int fy) = GridBFS(h, w, sx, sy, gx, gy, map);

			if (fx == gx && fy == gy) {
				canReach = true;
			} else {
				int[] vx = { 0, 1, 0, -1 };
				int[] vy = { 1, 0, -1, 0 };
				for (int i = 0; i < 4; i++) {
					int nx = fx + vx[i];
					int ny = fy + vy[i];
					if ((0 <= nx && nx < h) && (0 <= ny && ny < w)) {
						map[nx, ny] = true;
						if (map[nx, ny]) {
							(step, canReach, fx, fy) = GridBFS(h, w, sx, sy, gx, gy, map);
							if (canReach) {
								break;
							}
						}
					}
				}

				if (fx == gx && fy == gy) {
					canReach = true;
				} else {
					for (int i = 0; i < 4; i++) {
						int nx = fx + vx[i];
						int ny = fy + vy[i];
						if ((0 <= nx && nx < h) && (0 <= ny && ny < w)) {
							map[nx, ny] = true;
							if (map[nx, ny]) {
								(step, canReach, fx, fy) = GridBFS(h, w, sx, sy, gx, gy, map);
								if (canReach) {
									break;
								}
							}
						}
					}
				}
			}

			var answer = canReach ? "YES" : "NO";
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

		public static void Tako()
		{
			var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var x = xy[0];
			var y = xy[1];

			var answer = y / x;
			Console.WriteLine($"{answer}");
		}

		public static void Overwrite()
		{
			int n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();

			var list = s.ToCharArray().ToList();
			var tlist = new List<char>();

			for (var i = 0; i < list.Count; ++i) {
				if (tlist.Contains(s[i])) {
					tlist.RemoveAll(c => c == s[i]);
				}

				tlist.Add(s[i]);
			}

			var answer = new string(tlist.ToArray());
			Console.WriteLine($"{answer}");
		}
	}
}

