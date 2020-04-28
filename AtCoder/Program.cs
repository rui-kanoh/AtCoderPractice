using System;
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
		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static void Exec()
		{
			string s = Console.ReadLine();
			string t = Console.ReadLine();
			if (s == t) {
				Console.WriteLine($"No");
				Console.ReadKey();
				return;
			}

			if (t.Contains(s) && s.Length < t.Length) {
				Console.WriteLine($"Yes");
				Console.ReadKey();
				return;
			}

			var slist = s.ToCharArray().ToList();
			slist.Sort();
			string ss = new string(slist.ToArray());

			var tlist = t.ToCharArray().ToList();
			tlist.Sort();
			tlist.Reverse();
			string tt = new string(tlist.ToArray());
			bool isOK = false;
			for (int i = 0; i < ss.Length && i < tt.Length; ++i) {
				if (ss[i] < tt[i]) {
					isOK = true;
					break;
				}
			}

			if (isOK){
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

