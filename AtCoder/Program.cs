using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
			
		}
	}
}

namespace Temp {
	public class Question
	{
		public static void A()
		{

			int n = int.Parse(Console.ReadLine());
			n -= 22;
			string str = "";
			switch (n) {
				case 0:
					str = "Christmas Eve Eve Eve";
					break;
				case 1:
					str = "Christmas Eve Eve";
					break;
				case 2:
					str = "Christmas Eve";
					break;
				case 3:
					str = "Christmas";
					break;
				default:
					break;
			}

			Console.WriteLine($"{str}");
		}

		public static void B()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int height = array[0];
			int width = array[1];
			int area = height * width / 2;

			Console.WriteLine($"{area}");
		}

		public static void C()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int T = array[0];
			int X = array[1];

			Console.WriteLine($"{(double)T / X}");
		}

		public static void D()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int A = array[0];
			int B = array[1];
			if (B % A == 0) {
				Console.WriteLine($"{A + B}");
			} else {
				Console.WriteLine($"{B - A}");
			}

			Console.ReadKey();
		}

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

