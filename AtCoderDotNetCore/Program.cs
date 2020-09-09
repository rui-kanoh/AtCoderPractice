using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		public static bool IsPrime(int n)
		{
			if (n <= 1) {
				return false;
			}

			bool isPrime = true;
			for (var i = 2; i < n; ++i) {
				if (n % i == 0) {
					isPrime = false;
					break;
				}
			}

			return isPrime;
		}

		public static void Exec()
		{
			long q = int.Parse(Console.ReadLine());
			var counts = new int[q];
			for (var i = 0; i < q; ++i) {
				var lr = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
				int l = lr[0];
				int r = lr[1];
				for (var j = l; j <= r; j = j + 2) {
					if (IsPrime(j)) {
						int jj = (j + 1) / 2;
						if (IsPrime(jj)) {
							++counts[i];
						}
					}
				}
			}

			for (var i = 0; i < q; ++i) {
				Console.WriteLine($"{counts[i]}");
			}
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

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);

			Console.Out.Flush();

			Console.ReadKey();
		}

		public static void A()
		{
			var n = int.Parse(Console.ReadLine());
			if (n % 2 == 0) {
				Console.WriteLine("Blue");
			} else {
				Console.WriteLine("Red");
			}
		}

		public static void B()
		{
			var n = int.Parse(Console.ReadLine());
			var t1 = "TAKAHASHIKUN";
			var t2 = "Takahashikun";
			var t3 = "takahashikun";
			int count = 0;
			string[] inputStrArray = Console.ReadLine().Split(' ');
			for (var i = 0; i < n; ++i) {
				string str = inputStrArray[i];
				if (i == n - 1) {
					str = str.Trim('.');
				}

				if (str == t1
					|| str == t2
					|| str == t3) {
					++count;
				}
			}

			Console.WriteLine($"{count}");
		}

		public static void C()
		{
			var xy = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long x = xy[0];
			long y = xy[1];
			long a = x;
			var count = 1;
			for (var i = 1; i < y / x; ++i) {
				a *= 2;
				if (a > y) {
					break;
				}

				++count;
			}

			Console.WriteLine($"{count}");
		}

		public static void D()
		{
			long q = int.Parse(Console.ReadLine());
			var counts = new int[q];
			for (var i = 0; i < q; ++i) {
				var lr = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
				int l = lr[0];
				int r = lr[1];
				for (var j = l; j <= r; j = j + 2) {
					if (IsPrime(j)) {
						int jj = (j + 1) / 2;
						if (IsPrime(jj)) {
							++counts[i];
						}
					}
				}
			}

			for (var i = 0; i < q; ++i) {
				Console.WriteLine($"{counts[i]}");
			}
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

