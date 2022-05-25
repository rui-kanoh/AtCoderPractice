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
			var stamps = new[] { 'J', 'O', 'I' };
			long n = long.Parse(Console.ReadLine());
			string s = Console.ReadLine();

			// DPなんだろうけれど。。
			long max = 0;

			var answer = 0;
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

		public static void Acrostic()
		{
			string S = Console.ReadLine();
			int w = int.Parse(Console.ReadLine());
			int num = (S.Length / w) + (S.Length % w > 0 ? 1 : 0);

			var strs = new string[num];
			for (int i = 0; i < num; i++)
			{
				int length = (w * i + w) >= S.Length ? S.Length - (w * i) : w;
				strs[i] = S.Substring(w * i, length);
			}

			string str = "";
			foreach (var item in strs)
			{
				str += item[0].ToString();
			}

			var answer = str;

			Console.WriteLine($"{answer}");
		}


		public static void Niko()
		{
			long n = long.Parse(Console.ReadLine());

			long count = 0;
			for (var i = 1; i <= n; ++i)
			{
				if (i % 25 == 0)
				{
					++count;
				}
			}

			var answer = count;

			Console.WriteLine($"{answer}");
		}

		public static void StreamLine()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var x = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			x.Sort();

			int count = 0;
			if (n >= m)
			{
				count = 0;
			}
			else
			{
				// Sortして、外れ値を n - 1個除去してから、残りのグループの最小と最大の差が答え？
				// ただ、グループが複数個の分散していた場合は対応できない。
				long remain = m - n;

				// n個のグループをつくる
				// グループ分けのアルゴリズムが全く分からない
				var groups = new List<int>[n];
				var lengthArray = new long[m];
				for (var i = 0; i < m - 1; ++i)
				{
					lengthArray[i] = x[i + 1] - x[i];
				}
			}


			var answer = count;

			Console.WriteLine($"{answer}");
		}

	}
}

