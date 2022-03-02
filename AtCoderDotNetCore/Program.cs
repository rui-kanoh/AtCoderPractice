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
			else
			{
				parents[x] = Find(parents[x]);
				return parents[x];
			}
		}

		public void Union(int x, int y)
		{
			(x, y) = (Find(x), Find(y));

			if (x != y)
			{
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
		public static IReadOnlyList<T[]> AllPermutation<T>(params T[] array) where T : IComparable
		{
			var a = new List<T>(array).ToArray();
			var res = new List<T[]>();
			res.Add(new List<T>(a).ToArray());
			var n = a.Length;
			var next = true;
			while (next)
			{
				next = false;

				// 1
				int i;
				for (i = n - 2; i >= 0; i--)
				{
					if (a[i].CompareTo(a[i + 1]) < 0) break;
				}
				// 2
				if (i < 0) break;

				// 3
				var j = n;
				do
				{
					j--;
				} while (a[i].CompareTo(a[j]) > 0);

				if (a[i].CompareTo(a[j]) < 0)
				{
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

		public static void Exec()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var unionAB = new UnionFind(n);
			for (var i = 0; i < m; i++)
			{
				var val = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				unionAB.Union(val[0] - 1, val[1] - 1);
			}

			var unionCB = new UnionFind(n);
			for (var i = 0; i < m; i++)
			{
				var val = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				unionAB.Union(val[0] - 1, val[1] - 1);
			}

			var list = AllPermutation<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 });

			foreach (var item in list)
            {
				// 順列を全列挙して同じ組み合わせの物が見つかったらbreak
				if (false)
                {
					break;
                }
            }
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

			int size = 100000;
			var step = GridBFS(size, size, x1y1[0] - 1, x1y1[1] - 1, x2y2[0] - 1, x2y2[1] - 1);
			var answer = step + 1;
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

