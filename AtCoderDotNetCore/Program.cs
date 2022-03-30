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
			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var answer = 0;

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

