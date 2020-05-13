﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoder
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
			//int n = int.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			int m = array[1];
			double angleN = (n % 12) * (360.0 / 12.0) + m * (360.0 / 12.0 / 60.0);
			double angleM = m * (360.0 / 60.0);
			double diff = Math.Abs(angleM - angleN);
			diff = diff >= 180.0 ? 360.0 - diff : diff;
			Console.WriteLine($"{diff}");

			Console.ReadKey();
		}
	}
}

namespace Temp {
	public class Question
	{
		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static void Exec()
		{
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
			Console.SetOut(sw);

			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			long n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);

			Console.Out.Flush();

			Console.ReadKey();
		}

		public static long Gcd(long a, long b)
		{
			if (b == 0)
			{
				return a;
			}

			return Gcd(b, a % b);
		}

		public static long Lcm(long a, long b)
		{
			long g = Gcd(a, b);
			return a / g * b;
		}
	}
}

