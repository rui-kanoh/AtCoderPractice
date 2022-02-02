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
		// https://c-taquna.hatenablog.com/entry/2020/01/15/014154
		public static int GridBFS(int h, int w, char[,] map)
		{
			int[] vx = { 0, 1, 0, -1 };
			int[] vy = { 1, 0, -1, 0 };

			var dist = new bool[h, w];
			var tq = new Queue<(int, int, int)>();
			int step = 0;
			tq.Enqueue((0, 0, step));
			dist[0, 0] = true;
			while (0 < tq.Count)
			{
				var q = tq.Dequeue();
				int x = q.Item1;
				int y = q.Item2;
				step = q.Item3;
				
				for (int i = 0; i < 4; i++)
				{
					int nx = x + vx[i];
					int ny = y + vy[i];
					if ((0 <= nx && nx < h) && (0 <= ny && ny < w) && map[nx, ny] == '.' && dist[nx, ny] == false)
					{
						dist[nx, ny] = true;
						tq.Enqueue((nx, ny, step + 1));
					}
				}
			}

			return step;
		}

		public static void Exec()
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
			var array = Console.ReadLine().Split(" ").Select(i => BigInteger.Parse(i)).ToArray();
			var a1 = array[0];
			var a2 = array[1];
			var a3 = array[2];

			int count = 0;
			var diff12 = a1 - a2;
			var diff23 = a2 - a3;
			if (diff12 == diff23)
			{
			}
			else
			{

			}

			var answer = count;
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

		public static void C()
		{

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

