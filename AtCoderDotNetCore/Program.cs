using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;


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
			var np = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			long n = np[0];
			long p = np[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			long temp = 1;
			int r = 0;
			for (int l = 0; l < n;) {
				while (r < n && temp < p) {
					temp *= a[r];
					++r;
				}

				if (temp == p) {
					Console.WriteLine("Yay!");
					return;
				}

				while (l < r && temp > p) {
					temp /= a[l];
					++l;
				}

				if (temp == p) {
					Console.WriteLine("Yay!");
					return;
				}

				if (r == n) {
					break;
				}
			}

			Console.WriteLine(":(");
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static void Exec()
		{
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
			Console.SetOut(sw);

			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			long n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{
			int n = int.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			int answer = 0;
			bool canDivide = true;
			while (canDivide) {
				for (var i = 0; i < array.Length; ++i) {
					if (IsOdd(array[i])) {
						canDivide = false;
						break;
					}

					array[i] /= 2;
				}

				if (canDivide) {
					++answer;
				}
			}

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			string str = Console.ReadLine();
			var deleteChars = new[] { "a", "i", "u", "e", "o" };

			string answer = str;
			for (var i = 0; i < deleteChars.Length; ++i) {
				answer = answer.Replace(deleteChars[i], "");
			}

			Console.WriteLine($"{answer}");
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

		public static void I()
		{

		}

		public static void J()
		{

		}

		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static long Gcd(long a, long b)
		{
			if (b == 0) {
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

