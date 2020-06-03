using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
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
			

			Console.ReadKey();
		}
	}
}

namespace AtCoder {
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
			string s = Console.ReadLine();
			int count = 0;
			for (int i = 0; i < 3; ++i) {
				if (s[i] == '1') {
					++count;
				}
			}

			Console.WriteLine($"{count}");
		}

		public static void B()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int r = array[0];
			int g = array[1];
			int b = array[2];

			int value = r * 100 + g * 10 + b;
			if (value % 4 == 0) {
				Console.WriteLine("YES");
			} else {
				Console.WriteLine("NO");
			}
		}

		public static void C()
		{
			string s = Console.ReadLine();
			List<char> list = s.ToCharArray().ToList();
			var list2 = list.Distinct().ToList();

			if (list.Count == list2.Count) {
				Console.WriteLine("yes");
			} else {
				Console.WriteLine("no");
			}

			Console.ReadKey();
		}

		public static void D()
		{
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long a = array[0];
			long b = array[1];
			long k = array[2];

			if (b - a >= 2 * k) {
				for (var i = 0; i < k; ++i) {
					Console.WriteLine($"{a + i}");
				}

				for (var i = 1; i <= k; ++i) {
					Console.WriteLine($"{b - k + i}");
				}
			} else {
				for (var i = a; i <= b; ++i) {
					Console.WriteLine($"{i}");
				}
			}

			Console.ReadKey();
		}

		public static void E()
		{
			long n = long.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			long total = 0;
			for (var i = 0; i < n; ++i) {
				total += array[i];
			}

			long min = int.MaxValue;

			long sunuke = 0;
			long arai = 0;

			for (var i = 0; i < n - 1; ++i) {
				sunuke += array[i];
				arai = total - sunuke;
				long ans = Math.Abs(sunuke - arai);
				if (ans < min) {
					min = ans;
				}
			}

			Console.WriteLine($"{min}");
			Console.ReadKey();
		}

		public static void F()
		{
			var nm = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = nm[0];
			int m = nm[1];

			var fromIsland1 = new List<int>();
			var toIslandN = new List<int>();

			for (var i = 0; i < m; ++i) {
				var array = Console.ReadLine().Split(' ').Select(j => int.Parse(j)).ToArray();

				if (array[0] == 1) {
					fromIsland1.Add(array[1]);
				}

				if (array[1] == n) {
					toIslandN.Add(array[0]);
				}
			}

			bool canVoyage = false;

			if (fromIsland1.Count == 0 || toIslandN.Count == 0) {
			} else {
				var interSect = fromIsland1.Intersect(toIslandN).ToList();
				if (interSect.Count > 0) {
					canVoyage = true;
				}
			}


			if (canVoyage) {
				Console.WriteLine("POSSIBLE");
			} else {
				Console.WriteLine("IMPOSSIBLE");
			}

			Console.ReadKey();
		}

		public static void G()
		{
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long N = array[0];
			long Y = array[1];
			long x = -1;
			long y = -1;
			long z = -1;
			long maxCount = Y / 1000;

			for (var i = 0; i <= maxCount; ++i) {
				for (var j = 0; j <= maxCount; ++j) {
					long k = N - i - j;
					if (k < 0) {
						break;
					}

					long total = 10000 * i + 5000 * j + 1000 * k;
					if (total == Y) {
						x = i;
						y = j;
						z = k;
						break;
					}
				}
			}

			Console.WriteLine($"{x} {y} {z}");
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

