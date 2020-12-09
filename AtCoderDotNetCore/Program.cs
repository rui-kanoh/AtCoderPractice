using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
			string s = Console.ReadLine();
			var xy = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long gx = xy[0];
			long gy = xy[1];
			var position = new long[] { 0, 0 };
			var wCount = s.Count(c => c == 'W');
			var xCount = s.Count(c => c == 'X');
			var yCount = s.Count(c => c == 'Y');
			var zCount = s.Count(c => c == 'Z');
			var command = new char[]{ 'L', 'R', 'U', 'D' };

			var counts = new int[]{
				s.Count(c => c == 'W'),
				s.Count(c => c == 'X'),
				s.Count(c => c == 'Y'),
				s.Count(c => c == 'Z')
			};

			bool canPass = false;

			if (counts[0] - counts[1] == gx
				&& counts[2] - counts[3] == gy) {
				canPass = true;
			}

			if (counts[0] - counts[2] == gx
				&& counts[1] - counts[3] == gy) {
				canPass = true;
			}

			if (counts[0] - counts[3] == gx
				&& counts[1] - counts[2] == gy) {
				canPass = true;
			}

			if (counts[0] - counts[1] == gy
				&& counts[2] - counts[3] == gx) {
				canPass = true;
			}

			if (counts[0] - counts[2] == gy
				&& counts[1] - counts[3] == gx) {
				canPass = true;
			}

			if (counts[0] - counts[3] == gy
				&& counts[1] - counts[2] == gx) {
				canPass = true;
			}


			//
			if (counts[0] - counts[1] == -gx
				&& counts[2] - counts[3] == -gy) {
				canPass = true;
			}

			if (counts[0] - counts[2] == -gx
				&& counts[1] - counts[3] == -gy) {
				canPass = true;
			}

			if (counts[0] - counts[3] == -gx
				&& counts[1] - counts[2] == -gy) {
				canPass = true;
			}

			if (counts[0] - counts[1] == -gy
				&& counts[2] - counts[3] == -gx) {
				canPass = true;
			}

			if (counts[0] - counts[2] == -gy
				&& counts[1] - counts[3] == -gx) {
				canPass = true;
			}

			if (counts[0] - counts[3] == -gy
				&& counts[1] - counts[2] == -gx) {
				canPass = true;
			}



			if (canPass) {
				Console.WriteLine("Yes");
			} else {
				Console.WriteLine("No");
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
		}

		public static void A()
		{
			string s = Console.ReadLine();
			//int index = s.IndexOf("FESTIVAL");
			//Console.WriteLine($"{index}");
			string sub = s.Substring(0, s.Length - 8);
			Console.WriteLine($"{sub}");
		}

		public static void B()
		{
			var hw = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int h = hw[0];
			int w = hw[1];
			var lists = new List<string>();
			for (var i = 0; i < h; ++i) {
				string s = Console.ReadLine();
				lists.Add(s);
				lists.Add(s);
			}

			for (var i = 0; i < lists.Count; ++i) {
				Console.WriteLine($"{lists[i]}");
			}
		}

		public static void C()
		{
			string s = Console.ReadLine();
			var c = new List<char>();
			for (var i = 0; i < s.Length; ++i) {
				if (s[i] != 'B') {
					c.Add(s[i]);
				} else {
					if (c.Any()) {
						c.RemoveAt(c.Count - 1);
					}
				}
			}

			for (var i = 0; i < c.Count; ++i) {
				Console.Write($"{c[i]}");
			}

			Console.WriteLine();
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

