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

		public static void Usagi()
        {
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var dict = new Dictionary<int, int>();
			for (var i = 0; i < n; ++i)
			{
				dict[i] = a[i] - 1;
			}

			var answer = 0;
			foreach (var item in dict)
			{
				var key = item.Key;
				var value = item.Value;
				if (dict.ContainsKey(value) && dict[value] == key)
				{
					++answer;
				}
			}

			if (answer > 0)
			{
				answer /= 2;
			}

			Console.WriteLine($"{answer}");
		}

		public static (int left, int right) BinarySearch(int value, List<int> list)
		{
			int left = -1;
			int right = list.Count;
			while (right - left > 1)
			{
				int mid = (right + left) / 2;
				if (list[mid] == value)
				{
					return (mid, mid);
				}
				else if (list[mid] > value)
				{
					right = mid;
				}
				else
				{
					left = mid;
				}
			}

			return (left, right);
		}

		public static void TransfomableTeacher()
        {

			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];
			var h = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var hlist = h.ToList();
			hlist.Sort();
			var w = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			var h1 = new int[(n + 1) / 2 - 1];
			var h2 = new int[(n + 1) / 2 - 1];
			var rui1 = new int[(n + 1) / 2];
			var rui2 = new int[(n + 1) / 2];
			for (var i = 1; i < (n + 1) / 2; ++i)
			{
				h1[i - 1] = Math.Abs(hlist[2 * (i - 1)] - hlist[2 * (i - 1) + 1]);
				h2[i - 1] = Math.Abs(hlist[2 * i - 1] - hlist[2 * i]);
				rui1[i] = rui1[i - 1] + h1[i - 1];
				rui2[i] = rui2[i - 1] + h2[i - 1];
			}

			var min = int.MaxValue;
			for (var i = 0; i < w.Length; ++i)
			{
				(var left, var right) = BinarySearch(w[i], hlist);
				int count = 0;
				if (left == -1)
				{
					count = rui2[rui2.Length - 1] + Math.Abs(hlist[0] - w[i]);
				}
				else if (right == n)
				{
					count = rui1[rui1.Length - 1] + Math.Abs(hlist[n - 1] - w[i]);
				}
				else
				{
					int index = left / 2;

					int value = 0;
					int value2 = 0;
					if (IsOdd(left))
					{
						count = (rui1[index + 1] - rui1[0]);
						value = Math.Abs(hlist[left + 1] - w[i]);
						value2 = (rui2[rui2.Length - 1] - rui2[index + 1]);
					}
					else
					{
						count = (rui1[index] - rui1[0]);
						value = Math.Abs(hlist[left] - w[i]);
						value2 = (rui2[rui2.Length - 1] - rui2[index]);
					}

					count += value + value2;
				}

				min = Math.Min(min, count);
			}

			var answer = min;

			Console.WriteLine($"{answer}");
		}

		public static void A()
		{
		}

		public static void B()
		{
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

		public static void J()
		{
		}

		public static void K()
		{
		}

		public static void KK()
		{
		}

		public static void KKK()
        {
		}

		public static void KKKK()
        {
		}

		public static void KKKKKK()
		{
		}
	}
}

