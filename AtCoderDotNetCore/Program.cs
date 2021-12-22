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
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			long q = long.Parse(Console.ReadLine());

			var vecterX = new int[] { -1, 1, 0, 0 };
			var vecterY = new int[] { 0, 0, -1, 1 };
			bool canReach = false;

			// https://c-taquna.hatenablog.com/entry/2020/01/15/014154
			int GridBFS(int sx, int sy, int gx, int gy, bool[,] map)
			{
				if (map[sx, sy] == false || map[gx, gy] == false) {
					canReach = false;
					return 0;
				}

				int[,] dist = new int[h, w];
				for (int y = 0; y < w; y++) {
					for (int x = 0; x < h; x++) {
						dist[x, y] = -1;
					}
				}
				var tq = new Queue<(int, int, int)>();
				int step = 0;
				tq.Enqueue((sx, sy, step));
				dist[sx, sy] = 0;
				int[] vx = { 0, 1, 0, -1 };
				int[] vy = { 1, 0, -1, 0 };
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
						if ((0 <= nx && nx < h) && (0 <= ny && ny < w) && map[nx, ny] && dist[nx, ny] == -1) {
							dist[nx, ny] = dist[x, y] + 1;
							tq.Enqueue((nx, ny, step + 1));
						}
					}
				}

				return step;
			}

			var grid = new bool[h, w];
			var answers = new List<string>();
			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				if (query[0] == 1) {
					var r = query[1] - 1;
					var c = query[2] - 1;
					grid[r, c] = true;
				} else {
					var ra = query[1] - 1;
					var ca = query[2] - 1;
					var rb = query[3] - 1;
					var cb = query[4] - 1;

					canReach = false;
					GridBFS(ra, ca, rb, cb, grid);

					if (canReach) {
						answers.Add("Yes");
					} else {
						answers.Add("No");
					}
				}
			}

			var builder = new StringBuilder();
			foreach (var item in answers) {
				builder.AppendLine(item);
			}

			Console.WriteLine(builder.ToString());
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

		public class Train
		{
			public long Front { get; set; }
			public long Back { get; set; }
			public long Value { get; set; }
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
	}
}

