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
		public static void Exec()
		{
			var nk = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var dict = new Dictionary<(int, int), int>();
			string answer = "";
			for (var i = 0; i < k; ++i) {
				var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
				if (array[0] == 1) {
					var c = array[1];
					var d = array[2];
					var e = array[3];
					if (dict.ContainsKey((c, d)) == false
						&& dict.ContainsKey((d, c)) == false) {
						dict.Add((c, d), e);
						dict.Add((d, c), e);
					}
				} else if (array[0] == 0) {
					var a = array[1];
					var b = array[2];
					if (dict.ContainsKey((a, b)) == false
						&& dict.ContainsKey((b, a)) == false) {
						answer += "-1" + Environment.NewLine;
					} else {
						if (dict.ContainsKey((a, b))) {
							answer += dict[(a, b)] + Environment.NewLine;
						} else {
							answer += dict[(b, a)] + Environment.NewLine;
						}
					}
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
			int n = int.Parse(Console.ReadLine());
			var d = new List<int>();
			for (int i = 0; i < n; ++i) {
				int dd = int.Parse(Console.ReadLine());
				if (d.Contains(dd) == false) {
					d.Add(dd);
				}
			}

			Console.WriteLine($"{d.Count()}");
		}

		public static void B()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new List<int>();
			for (var i = 0; i < n; ++i) {
				a.Add(int.Parse(Console.ReadLine()));
			}

			bool isOK = false;
			int count = 1;

			int index = a[0];
			if (index == 2) {
				isOK = true;
			} else {
				for (var i = 0; i < n; ++i) {
					if (index > a.Count) {
						break;
					}

					++count;

					index = a[index - 1];
					if (index == 2) {
						isOK = true;
						break;
					}
				}
			}

			if (isOK == false) {
				Console.WriteLine($"-1");
			} else {
				Console.WriteLine($"{count}");
			}
		}

		public static void C()
		{
			int n = int.Parse(Console.ReadLine());
			var s = Console.ReadLine();

			bool isOK = false;
			int count = 0;
			string ax = "b";

			if (s == "b") {
				isOK = true;
			} else {
				for (int i = 1; i < n; ++i) {
					if (i % 3 == 1) {
						ax = "a" + ax + "c";
					} else if (i % 3 == 2) {
						ax = "c" + ax + "a";
					} else {
						ax = "b" + ax + "b";
					}

					++count;
					if (ax == s) {
						isOK = true;
						break;
					}
				}
			}

			if (isOK == false) {
				Console.WriteLine($"-1");
			} else {
				Console.WriteLine($"{count}");
			}
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

