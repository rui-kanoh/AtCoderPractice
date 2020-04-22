using System;
using System.Collections.Generic;
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
		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static void Exec()
		{
			var n = long.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			var list = array.ToList();

			var oddList = list.Where(x => IsOdd(x)).ToList();
			var noOddList = list.Where(x => IsOdd(x) == false).ToList();

			bool isOK = false;
			if (oddList.Count == 0)
			{
				isOK = true;
			} else if (oddList.Count - 1 <= noOddList.Count)
			{
				var list4 = noOddList.Where(x => x % 4 == 0).ToList();
				if (noOddList.Count - list4.Count == 0 && oddList.Count <= list4.Count + 1)
				{
					isOK = true;
				} else if (oddList.Count <= list4.Count)
				{
					isOK = true;
				}
			}

			if (isOK) {
				Console.WriteLine($"Yes");
			} else {
				Console.WriteLine($"No");
			}

			Console.ReadKey();
		}
	}
}

namespace Temp {
	public class Question
	{
		public void Exec()
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

