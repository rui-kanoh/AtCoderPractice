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

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void A()
		{
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			long answer = 0;

			double v = (a[0] + a[2]) / 2.0;
			if (v < a[1])
			{
				answer = a[1] * 2 - (a[0] + a[3]);
			}
			else if (v > a[1])
			{
				if (v > (long)v)
				{
					answer = ((a[0] + a[2] + 1) - 2 * a[1] + 2) / 2;
				}
				else
				{
					answer = (long)v - a[1];
				}
			}
			else
			{
				// 何もしない
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			long count = a[0];
			for (var i = 1; i < n; ++i)
			{
				count = count + a[i] + count;
			}

			long answer = count;
			Console.WriteLine($"{answer}");
		}

		public static class Question
		{
			// https://c-taquna.hatenablog.com/entry/2020/01/15/014154
			public static int GridBFS(int h, int w, char[,] map)
			{
				int[] vx = { 0, 1, };
				int[] vy = { 1, 0, };

				var dist = new bool[h, w];
				var tq = new Queue<(int, int, int)>();
				int step = 0;
				tq.Enqueue((0, 0, step));
				dist[0, 0] = true;
				while (0 < tq.Count)
				{
					var q = tq.Dequeue();
					int x = q.Item2;
					int y = q.Item1;
					step = q.Item3;

					for (int i = 0; i < vx.Length; i++)
					{
						int nx = x + vx[i];
						int ny = y + vy[i];
						if ((0 <= nx && nx < w) && (0 <= ny && ny < h) && map[ny, nx] == '.' && dist[ny, nx] == false)
						{
							dist[ny, nx] = true;
							tq.Enqueue((ny, nx, step + 1));
						}
					}
				}

				return step;
			}

			public static void C()
			{
				var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var h = hw[0];
				var w = hw[1];

				var grid = new char[h, w];
				for (var i = 0; i < h; i++)
				{
					var ss = Console.ReadLine();
					for (var j = 0; j < ss.Length; ++j)
					{
						grid[i, j] = ss[j];
					}
				}

				int step = GridBFS(h, w, grid);
				Console.WriteLine($"{step + 1}");
			}
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

