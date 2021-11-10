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
			
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

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
			var abcd = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abcd[0];
			var b = abcd[1];
			var c = abcd[2];
			var d = abcd[3];
			var answer = "Balanced";
			if (a + b < c + d) {
				answer = "Right";
			} else if (a + b > c + d) {
				answer = "Left";
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			string w = Console.ReadLine();

			bool isBeautiful = true;
			for (char c = 'a'; c <= 'z'; ++c) {
				int count = w.Where(s => s == c).Count();
				if (IsOdd(count)) {
					isBeautiful = false;
					break;
				}
			}

			Console.WriteLine(isBeautiful ? "Yes" : "No");
		}

		public static void C()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			long time = (100 * (n - m) + 1900 * m) * (1 << m);

			var answer = time;
			Console.WriteLine($"{answer}");
		}

		public static void D()
		{

		}

		public static void E()
		{

		}
	}
}

