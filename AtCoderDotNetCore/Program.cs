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
			var wh = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var w = wh[0];
			var h = wh[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var origin = Enumerable.Range(0, w).ToArray();

			for (var i = 0; i < a.Length; ++i)
            {
				if (origin.Length > a[i] + 1)
				{
					var temp = origin[a[i] + 1];
					origin[a[i] + 1] = origin[a[i]];
					origin[a[i]] = temp;
				}
			}

			int count = 0;
			for (var i = 0; i < b.Length; ++i)
            {
				if (origin[i] != b[i])
                {
					++count;
                }
            }

			var answer = count / 2;

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
			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			var answer = c / (a > b ? b : a);

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var y = int.Parse(Console.ReadLine());
			var m = int.Parse(Console.ReadLine());
			var d = int.Parse(Console.ReadLine());

			int CalcDate(int y, int m, int d)
			{
				if (m == 1 || m == 2)
				{
					y -= 1;
					m += 12;
				}

				int date = 365 * y + (y / 4) - (y / 100) + (y / 400) + ((306 * (m + 1)) / 10) + d - 429;
				return date;
			}

			var answer = CalcDate(2014, 5, 17) - CalcDate(y, m, d);
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			long n = long.Parse(Console.ReadLine());
			var s = Console.ReadLine().ToCharArray();
			long q = long.Parse(Console.ReadLine());

			long t2Count = 0;
			for (var i = 0; i < q; i++)
			{
				var tab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var t = tab[0];
				var a = tab[1] - 1;
				var b = tab[2] - 1;

				if (t == 2)
				{
					++t2Count;
				}
				else
				{
					if (IsOdd(t2Count))
					{
						if (a >= s.Length / 2)
						{
							a -= s.Length / 2;
						}
						else
						{
							a += s.Length / 2;
						}

						if (b >= s.Length / 2)
						{
							b -= s.Length / 2;
						}
						else
						{
							b += s.Length / 2;
						}

						char temp = s[a];
						s[a] = s[b];
						s[b] = temp;
					}
					else
					{
						char temp = s[a];
						s[a] = s[b];
						s[b] = temp;
					}
				}
			}

			var answer = new string(s);
			if (IsOdd(t2Count))
			{
				answer = answer.Substring(answer.Length / 2, answer.Length / 2) + answer.Substring(0, answer.Length / 2);
			}


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

