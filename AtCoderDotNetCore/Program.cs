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
				
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void Festival()
		{
			string s = Console.ReadLine();
			var answer = s.Substring(0, 4) + " " + s.Substring(4, 8);
			Console.WriteLine($"{answer}");
		}

		public static void BestBody()
		{
			var nst = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nst[0];
			var s = nst[1];
			var t = nst[2];
			long weight = long.Parse(Console.ReadLine());

			long count = 0;
			if (s <= weight && weight <= t)
			{
				++count;
			}

			for (var i = 1; i < n; i++)
			{
				var w = long.Parse(Console.ReadLine());
				weight += w;

				if (weight < 0)
				{
					weight = 0;
				}

				if (s <= weight && weight <= t)
				{
					++count;
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}


	}
}

