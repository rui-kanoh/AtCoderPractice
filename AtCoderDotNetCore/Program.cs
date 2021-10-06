using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

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
			
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static void Exec()
		{
			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static void A()
		{
			int n = int.Parse(Console.ReadLine());
			bool isOK = false;
			if (n % 10 == n / 100) {
				isOK = true;
			}

			var answer = isOK ? "Yes" : "No";

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			// 貪欲法
			var n = long.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList();
			a.Sort();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList();
			b.Sort();

			if (n == 1) {
				Console.WriteLine($"{Math.Abs(a[0] - b[0])}");
				return;
			}

			long distance = 0;
			var amb = new List<long>();
			for (var i = 0; i < a.Count; ++i) {
				distance += Math.Abs(a[i] - b[i]);
			}

			var answer = distance;

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
	}
}

