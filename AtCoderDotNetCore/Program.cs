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
			long a = long.Parse(Console.ReadLine());
			long b = long.Parse(Console.ReadLine());
			long n = long.Parse(Console.ReadLine());

			var answer = a * b;
			for (var i = n; i <= 30000; ++i)
			{
				if (((i % a) == 0) && ((i % b) == 0))
				{
					answer = i;
					break;
				}
			}

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
			string s = Console.ReadLine();
			var answer = s.Last() == 'T';

			Console.WriteLine(answer ? "YES" : "NO");
		}

		public static void B()
		{
			string s = Console.ReadLine();
			int count = 0;
			for (var i = 0; i < s.Length; i++)
			{
				if (s[i] == '+')
				{
					++count;
				}
				else
				{
					--count;
				}
			}

			Console.WriteLine($"{count}");
		}

		public static bool IsPrime(long num)
		{
			if (num < 2) return false;
			else if (num == 2) return true;
			else if (num % 2 == 0) return false;

			double sqrtNum = Math.Sqrt(num);
			for (int i = 3; i <= sqrtNum; i += 2)
			{
				if (num % i == 0)
				{
					// 素数ではない
					return false;
				}
			}

			// 素数である
			return true;
		}

		public static void C()
		{
			int count = 0;
			int n = int.Parse(Console.ReadLine());
			for (var i = 1; i < n; i++)
			{
				if (IsPrime(i))
				{
					++count;
				}
			}

			Console.WriteLine($"{count}");
		}

		/*
		public static void niko()
        {
			int count = 0;
			long n = long.Parse(Console.ReadLine());


			var niko = new int[] { 25, 2525, 252525, 25252525, };

			var hash = new HashSet<long>();
			foreach (var item in niko)
			{
				var list = GetDivisors(item);
				foreach (var l in list)
				{
					if (hash.Contains(l) == false)
					{
						hash.Add(l);
						++count;
					}
				}
			}
		}
		*/

		public static void D()
		{
			int n = int.Parse(Console.ReadLine());
			var answer = (9.0 / 5.0 * n) + 32.0;
			Console.WriteLine($"{answer}");
		}

		public static void E()
		{
			string[] ab = Console.ReadLine().Split(" ");
			var a = ab[0];
			var b = ab[1];

			var answer = true;
			if ((a == "H" && b == "H")
				|| (a == "D" && b == "D"))
			{
				answer = true;
			}
			else
			{
				answer = false;
			}

			Console.WriteLine(answer ? "H" : "D");


		}

		public static void F()
		{
			string[] sss = Console.ReadLine().Split(" ");
			var s1 = sss[0];
			var s2 = sss[1];
			var s3 = sss[2];


			var answer = (s1[0].ToString() + s2[0].ToString() + s3[0].ToString()).ToUpper();

			Console.WriteLine($"{answer}");

		}

		public static void G()
		{
			long n = int.Parse(Console.ReadLine());
			var list = new List<int>();
			for (var i = 0; i < n; i++)
			{
				list.Add(int.Parse(Console.ReadLine()));
			}

			list.Sort();

			var answer = list[0];

			Console.WriteLine($"{answer}");
		}

		public static void H()
		{
			var aop = Console.ReadLine().Split(" ");
			var a = int.Parse(aop[0]);
			var op = aop[1];
			var b = int.Parse(aop[2]);

			var answer = 0;
			if (op == "+")
			{
				answer = a + b;
			}
			else
			{
				answer = a - b;
			}

			Console.WriteLine($"{answer}");
		}

		public static void J()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var list = a.Where(s => s > 0).ToList();
			double ave = list.Average();
			var answer = (int)Math.Ceiling(ave);

			Console.WriteLine($"{answer}");
		}

		public static void aoki()
		{
			long a = long.Parse(Console.ReadLine());
			long b = long.Parse(Console.ReadLine());
			long n = long.Parse(Console.ReadLine());

			var answer = a * b;
			for (var i = n; i <= (a * b); ++i)
			{
				if (((i % a) == 0) && ((i % b) == 0))
				{
					answer = i;
					break;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void K()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			a.Sort();
			a.Reverse();
			var answer = 0;
			for (int i = 0; i < n; i = i + 2)
			{
				answer += a[i];
			}

			Console.WriteLine($"{answer}");
		}

		public static void KK()
		{
			string x = Console.ReadLine();
			string s = Console.ReadLine();
			var answer = s.Replace(x, "");
			Console.WriteLine($"{answer}");
		}

		public static void KKK()
        {
			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var answer = abc[0] <= abc[2] && abc[2] <= abc[1];

			Console.WriteLine(answer ? "Yes" : "No");
		}

		public static void KKKK()
        {
			var a = BigInteger.Parse(Console.ReadLine());
			var b = BigInteger.Parse(Console.ReadLine());

			var answer = "EQUAL";
			if (a > b)
			{
				answer = "GREATER";
			}
			else if (a < b)
			{
				answer = "LESS";
			}

			Console.WriteLine($"{answer}");
		}

		public static void KKKKKK()
		{
			var a = int.Parse(Console.ReadLine());
			var b = int.Parse(Console.ReadLine());

			var answer = 0;
			if (a % b != 0)
			{
				for (var i = 0; i < a; i++)
				{
					++a;
					++answer;
					if (a % b == 0)
					{
						break;
					}
				}
			}

			Console.WriteLine($"{answer}");
		}
	}
}

