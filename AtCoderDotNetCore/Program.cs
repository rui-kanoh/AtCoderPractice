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
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void Show(bool[,] dist)
        {
			for (var i = 0; i < dist.GetLength(0); i++)
			{
				for (var j = 0; j < dist.GetLength(1); j++)
				{
					Console.Write($"{dist[i, j]} ");
				}

				Console.WriteLine("");
			}
		}

		// https://c-taquna.hatenablog.com/entry/2020/01/15/014154
	public static (int step, bool canReach) GridBFS(int h, int w, int sx, int sy, int gx, int gy, char[,] map)
		{
			bool canReach = false;
			int[] vx = { 0, 1, 0, -1 };
			int[] vy = { 1, 0, -1, 0 };

			if (map[sx, sy] == '#' || map[gx, gy] == '#')
			{
				canReach = false;
				return (0, canReach);
			}

			if (sx == gx && sy == gy)
			{
				canReach = true;
				return (0, canReach);
			}


			var tq = new Queue<(int x, int y, bool isVertical)>();
			var distances = new int[h, w, 2];
			for (var i = 0; i < h; ++i)
            {
				for (var j = 0; j < w; ++j)
                {
					distances[i, j, 0] = int.MaxValue;
					distances[i, j, 1] = int.MaxValue;
				}
            }


			bool isVertical = (sx == gx);
			tq.Enqueue((sx, sy, isVertical));
			distances[sx, sy, ] = true;

			while (0 < tq.Count)
			{
				var q = tq.Dequeue();
				int x = q.x;
				int y = q.y;
				step = q.step;

				if (x == gx && y == gy)
				{
					canReach = true;
					break;
				}

				for (int i = 0; i < 4; i++)
				{
					int nx = x + vx[i];
					int ny = y + vy[i];
					if ((0 <= nx && nx < h) && (0 <= ny && ny < w) && map[nx, ny] == '.' && dist[nx, ny] == false)
					{
						bool isVertical2 = (i == 0 || i == 2);

						if (tq.Count > 0)
						{
							if (tq.Last().isVertical != isVertical2)
							{
								dist[nx, ny] = true;
								tq.Enqueue((nx, ny, step + 1, isVertical2));
								Show(dist);
							}
						}
						else
						{
							if (isVertical != isVertical2)
							{
								dist[nx, ny] = true;
								tq.Enqueue((nx, ny, step + 1, isVertical2));
								Show(dist);
							}
						}
					}
				}

				isVertical = q.isVertical;
			}

			return (step, canReach);
		}

		public static void Exec()
		{
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var sg = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var sx = sg[0] - 1;
			var sy = sg[1] - 1;
			var gx = sg[2] - 1;
			var gy = sg[3] - 1;

			var grid = new char[h, w];
			for (var i = 0; i < h; i++)
            {
				var ss = Console.ReadLine();
				for (var j = 0; j < ss.Length; ++j)
				{
					grid[i, j] = ss[j];
				}
			}

			(var step, var canReach) = GridBFS(h, w, sx, sy, gx, gy, grid);
			Console.WriteLine($"{step} {canReach}");

			//var answer = step;
			//Console.WriteLine($"{answer}");
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

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void A()
		{

		}

		public static void B()
		{
			int n = int.Parse(Console.ReadLine());
			var words = new string[n];
			for (var i = 0; i < n; ++i) {
				words[i] = Console.ReadLine();
			}

			bool wins = false;
			bool isfinished = true;
			if (n > 1) {
				var hash = new HashSet<string>();
				hash.Add(words[0]);

				for (var i = 1; i < words.Length; ++i) {
					if (hash.Contains(words[i])) {
						wins = IsOdd(i) ? true : false;
						isfinished = false;
						break;
					}

					string old = words[i - 1];
					if (old[old.Length - 1] != words[i][0]) {
						wins = IsOdd(i) ? true : false;
						isfinished = false;
						break;
					}

					hash.Add(words[i]);
				}
			}

			var answer = isfinished
				? "DRAW"
				: wins ? "WIN" : "LOSE";
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			string s = Console.ReadLine();
			var deq = new Deque.Deque<char>(s.Length);
			int reverseCount = 0;

			for (var i = 0; i < s.Length; ++i) {
				if (s[i] == 'R') {
					if (deq.Length > 0) {
						++reverseCount;
					}
				} else {
					if (IsOdd(reverseCount)) {
						if (deq.Length > 0 && deq[0] == s[i]) {
							deq.PopFront();
						} else {
							deq.PushFront(s[i]);
						}
					} else {
						if (deq.Length > 0 && deq[deq.Length - 1] == s[i]) {
							deq.PopBack();
						} else {
							deq.PushBack(s[i]);
						}
					}
				}
			}

			string t = "";
			if (deq.Length > 0) {
				var builder = new StringBuilder();
				for (var i = 0; i < deq.Length; ++i) {
					int index = IsOdd(reverseCount)
						? deq.Length - 1 - i
						: i;
					builder.Append(deq[index]);
				}

				t = builder.ToString();
			}

			Console.WriteLine(t);
		}

		public static void D()
		{
		}

		public static void E()
		{
		}

		public static void F()
		{
		}

		public static void G()
		{

		}

		public static void H()
		{

		}
	}
}

