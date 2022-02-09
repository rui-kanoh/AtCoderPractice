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
using System.Diagnostics;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Intrinsics.X86;


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

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void A()
		{
			string s = Console.ReadLine();

			var answer = s.Count(s => s == '1');

			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var nxy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nxy[0];
			var x = nxy[1];
			var y = nxy[2];

			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
			a.Sort();

			bool isDrawed = false;
			bool winsT = false;
			var tlist = new List<int>();
			tlist.Add(x);
			var aokiList = new List<int>();
			aokiList.Add(y);

			for (var i = 0; i < n / 2; ++i)
			{
				tlist.Add(a.Last());
				a.RemoveAt(a.Count - 1);
				aokiList.Add(a.Last());
				a.RemoveAt(a.Count - 1);
			}

			var sumT = tlist.Sum();
			var sumA = aokiList.Sum();
			if (sumT == sumA)
			{
				isDrawed = true;
			}
			else
			{
				winsT = sumT > sumA;
			}

			var answer = isDrawed
				? "Draw"
				: winsT ? "Takahashi" : "Aoki";
			Console.WriteLine($"{answer}");
		}


		public static void C()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var union = new Lib.UnionFind(n);
			for (var j = 0; j < m; ++j)
			{
				var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				union.Union(ab[0] - 1, ab[1] - 1);
			}

			var answer = union.GroupCount - 1;

			Console.WriteLine($"{answer}");
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
	}
}

