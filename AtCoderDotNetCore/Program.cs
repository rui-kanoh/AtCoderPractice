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
			string s = Console.ReadLine();
			long k = long.Parse(Console.ReadLine());
			long deno = (long)(Math.Pow(10, 9) + 7);

			int count = 0;
			void DfsBool(List<bool> items, int num)
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

					int rCount = items.Count(b => b);
					int bCount = items.Count(b => b == false);

					if (rCount == bCount)
                    {
						++count;
                    }

					return;
				}

				Array.ForEach(
					new[] { true, false },
					value => {
						items.Add(value);
						DfsBool(items, num);
						items.RemoveAt(items.Count - 1);
					});
			}

			DfsBool(new List<bool>(), s.Length);

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
			int n = int.Parse(Console.ReadLine());
			int tCount = 0;
			int acount = 0;
			for (var i = 0; i < n; i++)
			{
				string s = Console.ReadLine();
				tCount += s.Count(c => c == 'R');
				acount += s.Count(c => c == 'B');
			}


			var answer = tCount > acount
				? "TAKAHASHI"
				: (tCount != acount ? "AOKI" : "DRAW");

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];
			if (a == 0 || b == 0 || (a < 0 && b > 0))
			{
				Console.WriteLine($"Zero");
				return;
			}

			// a,bどっちも正
			if (a > 0 && b > 0)
			{
				Console.WriteLine($"Positive");
				return;
			}


			// a,bどっちも負
			var count = Math.Abs(a - b);
			var answer = IsOdd(count)
				? "Positive"
				: "Negative";

			Console.WriteLine($"{answer}");
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

