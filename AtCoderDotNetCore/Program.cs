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
			var answer = count;

			Console.WriteLine($"{answer}");
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
		}

		public static void C()
		{
			string s = Console.ReadLine();
			var oklist = new List<int>();
			var qlist = new List<int>();
			var nglist = new List<int>();
			for (var i = 0; i < s.Length; i++)
			{
				if (s[i] == 'o')
				{
					oklist.Add(i);
				}
				else if (s[i] == '?')
				{
					qlist.Add(i);
				}
				else
				{
					nglist.Add(i);
				}
			}

			if (oklist.Count > 4)
			{
				Console.WriteLine("0");
				return;
			}

			int count = 0;
			void Dfs(List<int> items, int num)
			{
				if (items.Count == num)
				{
					/*
					foreach (var item in items)
					{
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					bool isOK = true;
					foreach (var item in items)
					{
						if (nglist.Contains(item))
						{
							isOK = false;
							break;
						}
					}

					foreach (var okitem in oklist)
					{
						if (items.Contains(okitem) == false)
						{
							isOK = false;
							break;
						}
					}

					if (isOK)
					{
						++count;
					}

					return;
				}

				for (var i = 0; i < 10; ++i)
				{
					items.Add(i);
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), 4);

			var answer = count;

			Console.WriteLine($"{answer}");
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

