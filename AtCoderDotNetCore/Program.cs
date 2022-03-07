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
			string s = Console.ReadLine();
			var answer = $"ABC{s}";
			Console.WriteLine($"{answer}");
		}

		public static int GridBFS(int h, int w, int sx, int sy, int gx, int gy)
		{
			int[] vx = { 0, 1, 0, -1 };
			int[] vy = { 1, 0, -1, 0 };

			if (sx == gx && sy == gy)
			{
				return 0;
			}

			var width = Math.Abs(gx - sx) + 1;
			var height = Math.Abs(gy - sy) + 1;

			var dist = new bool[width, height];
			var tq = new Queue<(int, int, int)>();
			int step = 0;
			tq.Enqueue((sx, sy, step));
			dist[0, 0] = true;
			while (0 < tq.Count)
			{
				var q = tq.Dequeue();
				int x = q.Item1;
				int y = q.Item2;
				step = q.Item3;

				if (x == gx && y == gy)
				{
					break;
				}

				for (int i = 0; i < 4; i++)
				{
					int nx = x + vx[i] - sx;
					int ny = y + vy[i] - sy;
					if ((0 <= nx && nx < width) && (0 <= ny && ny < height) && dist[nx, ny] == false)
					{
						dist[nx, ny] = true;
						tq.Enqueue((nx + sx, ny + sy, step + 1));
					}
				}
			}

			return step;
		}


		public static void B()
		{
			var x1y1 = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var x2y2 = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			var step = Math.Abs(x2y2[0] - x1y1[0]) + Math.Abs(x2y2[1] - x1y1[1]);
			var answer = step + 1;
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var adjacencyAB = new int[n, n];
			for (var i = 0; i < m; i++)
			{
				var val = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				adjacencyAB[val[0] - 1, val[1] - 1] = 1;
				adjacencyAB[val[1] - 1, val[0] - 1] = 1;
			}

			var adjacencyCD = new int[n, n];
			for (var i = 0; i < m; i++)
			{
				var val = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				adjacencyCD[val[0] - 1, val[1] - 1] = 1;
				adjacencyCD[val[1] - 1, val[0] - 1] = 1;
			}

			var list = Calc.AllPermutation(Enumerable.Range(0, n).ToArray());

			var answer = false;
			foreach (var item in list)
			{
				bool isSame = true;
				for (var i = 0; i < n; ++i)
				{
					for (var j = 0; j < n; ++j)
					{
						if (adjacencyAB[i, j] != adjacencyCD[item[i], item[j]])
						{
							isSame = false;
							break;
						}

						if (isSame == false)
						{
							break;
						}
					}
				}

				// 順列を全列挙して同じ組み合わせの物が見つかったらbreak
				if (isSame)
				{
					answer = true;
					break;
				}
				else
				{
					continue;
				}
			}

			Console.WriteLine(answer ? "Yes" : "No");
		}

		public static void D()
		{
			long n = long.Parse(Console.ReadLine());

			var list = new List<(long a, long t)>();
			for (var i = 0; i < n; i++)
			{
				var array = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				list.Add((array[0], array[1]));
			}

			list.Sort((x, y) => y.a.CompareTo(x.a));

			long answer = 0;
			long time = Math.Max(list[0].a, list[0].t);

			for (var i = 1; i < list.Count; i++)
			{
				time = Math.Max(time + Math.Abs(list[i - 1].a - list[i].a), list[i].t);
			}

			time += list[list.Count - 1].a;
			answer = time;

			Console.WriteLine($"{answer}");
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

