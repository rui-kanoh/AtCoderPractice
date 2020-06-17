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
			var nl = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var n = nl[0];
			var l = nl[1];
			string s = Console.ReadLine();
			char[] chars = s.ToCharArray();
			int count = 1;
			int crash = 0;
			foreach (var item in chars) {
				if (item == '+') {
					++count;
					if (count > l) {
						++crash;
						count = 1;
					}
				} else {
					--count;
				}
			}

			Console.WriteLine($"{crash}");

			Console.ReadKey();
		}

		public static void B()
		{
			var ab = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];

			var dict = new Dictionary<int, char>();
			for (var i = 0; i < 10; ++i) {
				dict.Add(i, 'x');
			}

			if (a > 0) {
				var p = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
				foreach (var item in p) {
					dict[item] = '.';
				}
			} else {
				Console.ReadLine();
			}

			if (b > 0) {
				var q = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
				foreach (var item in q) {
					dict[item] = 'o';
				}
			} else {
				Console.ReadLine();
			}

			Console.Write($"{dict[7]} {dict[8]} {dict[9]} {dict[0]}");
			Console.WriteLine($"");
			Console.Write($" {dict[4]} {dict[5]} {dict[6]}");
			Console.WriteLine($"");
			Console.Write($"  {dict[2]} {dict[3]}");
			Console.WriteLine($"");
			Console.Write($"   {dict[1]}");
			Console.WriteLine($"");

			Console.ReadKey();
		}

		public static void C()
		{
			//WA

			long n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long area = 0;

			var dict = new Dictionary<long, int>();
			foreach (var item in a) {
				if (dict.ContainsKey(item) == false) {
					dict.Add(item, 1);
				} else {
					++dict[item];
				}
			}

			var list = new List<long>();
			foreach (var item in dict) {
				if (item.Value >= 2) {
					list.Add(item.Key);
				}
			}

			if (list.Count >= 2) {
				for (var i = 0; i < list.Count - 1; i = i + 2) {
					area += list[i] * list[i + 1];
				}
			}

			Console.WriteLine($"{area}");

			Console.ReadKey();

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

