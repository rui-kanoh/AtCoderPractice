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


		// https://c-taquna.hatenablog.com/entry/2020/01/15/014154
		public static int GridBFS(int h, int w, int sx, int sy, int gx, int gy, bool[,] map)
		{
			int[] vx = { 0, 1, 0, -1 };
			int[] vy = { 1, 0, -1, 0 };

			/*
			if (map[sx, sy] == false || map[gx, gy] == false) {
				return 0;
			}
			*/

			if (sx == gx && sy == gy) {
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

				if (x == gx && y == gy) {
					break;
				}

				for (int i = 0; i < 4; i++) {
					int nx = x + vx[i];
					int ny = y + vy[i];
					if ((0 <= nx && nx < h) && (0 <= ny && ny < w) && (map[nx, ny] != map[x, y]) && dist[nx, ny] == false) {
						dist[nx, ny] = true;
						tq.Enqueue((nx, ny, step + 1));
					}
				}
			}

			return step;
		}

		public static void ExecTemp()
		{
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var map = new bool[h, w];
			for (int i = 0; i < h; i++) {
				var array = Console.ReadLine();
				for (var j = 0; j < w; ++j) {
					map[i, j] = array[j] == '.';
				}
			}

			int step = GridBFS(h, w, 0, 0, h - 1, w - 1, map);

			var answer = step == 0 ? -1 : step;

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

		public static void AC()
		{
			string s = Console.ReadLine();
			var answer = s.Contains("AC") ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void String25()
		{
			string s = Console.ReadLine();
			int n = int.Parse(Console.ReadLine());
			var list = new List<string>();

			for (var i = 0; i < s.Length; i++) {
				for (var j = 0; j < s.Length; j++) {
					var str2 = $"{s[i]}{s[j]}";
					list.Add(str2);
				}
			}

			var answer = list[n - 1];
			Console.WriteLine($"{answer}");
		}

		public static void Iroha()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var d = Console.ReadLine().Split(" ").Select(i => char.Parse(i)).ToList();

			int number = 0;
			for (var i = n; i <= 10000 * 10; ++i) {
				var chars = i.ToString().ToCharArray();
				bool next = false;
				for (var j = 0; j < chars.Length; ++j) {
					if (d.Contains(chars[j])) {
						next = true;
						break;
					}
				}

				if (next) {
					continue;
				}

				if (i >= n) {
					number = i;
					break;
				}
			}

			var answer = number;
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

		public static void Eating()
		{
			string s = Console.ReadLine();

			var answer = 0;
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] == '+') {
					++answer;
				} else {
					--answer;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void TakahashiOtsukai()
		{
			int n = int.Parse(Console.ReadLine());

			int count = 0;
			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				count += ab[0] * ab[1];
			}

			count = (int)Math.Floor(count * 1.05);

			var answer = count;
			Console.WriteLine($"{answer}");
		}
	}
}

