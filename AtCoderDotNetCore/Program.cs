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

		public static void CountOrder()
		{
			int n = int.Parse(Console.ReadLine());
			var p = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var q = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			var list = AllPermutation(Enumerable.Range(1, n).ToArray());

			int a = -1;
			int b = -1;
			for (var j = 0; j < list.Count; ++j)
			{
				bool isFoundA = true;
				for (var i = 0; i < n; i++)
				{
					if (list[j][i] != p[i])
					{
						isFoundA = false;
						break;
					}
				}

				if (isFoundA)
				{
					a = j;
				}

				bool isFoundB = true;
				for (var i = 0; i < n; i++)
				{
					if (list[j][i] != q[i])
					{
						isFoundB = false;
						break;
					}
				}

				if (isFoundB)
				{
					b = j;
				}
			}

			var answer = Math.Abs(a - b);

			Console.WriteLine($"{answer}");
		}

		
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}
	}
}

