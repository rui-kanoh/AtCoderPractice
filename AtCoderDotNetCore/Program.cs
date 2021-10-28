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
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

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
			string[] abc = Console.ReadLine().Split(" ");
			string title = abc[1];
			Console.WriteLine($"A{title[0].ToString().ToUpper()}C");
		}

		public static void B()
		{
			int n = int.Parse(Console.ReadLine());
			var t = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			int m = int.Parse(Console.ReadLine());
			var xplist = new List<(int p, long x)>();
			for (var i = 0; i < m; ++i) {
				var px = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				xplist.Add(((int)px[0] - 1, px[1]));
			}

			long total = t.Sum();
			var sb = new StringBuilder();
			for (var i = 0; i < m; ++i) {
				long answer = total - t[xplist[i].p] + xplist[i].x;
				sb.Append($"{answer}" + Environment.NewLine);
			}

			Console.WriteLine(sb.ToString());
		}

		public static void C()
		{
			string[] sk = Console.ReadLine().Split(" ");
			var s = sk[0];
			var k = int.Parse(sk[1]);
			var slist = s.ToCharArray();

			// https://webbibouroku.com/Blog/Article/cs-permutation
			List<T[]> AllPermutation<T>(params T[] array) where T : IComparable
			{
				var a = new List<T>(array).ToArray();
				var res = new List<T[]>();
				res.Add(new List<T>(a).ToArray());
				var n = a.Length;
				var next = true;
				while (next) {
					next = false;

					// 1
					int i;
					for (i = n - 2; i >= 0; i--) {
						if (a[i].CompareTo(a[i + 1]) < 0) break;
					}
					// 2
					if (i < 0) break;

					// 3
					var j = n;
					do {
						j--;
					} while (a[i].CompareTo(a[j]) > 0);

					if (a[i].CompareTo(a[j]) < 0) {
						// 4
						var tmp = a[i];
						a[i] = a[j];
						a[j] = tmp;
						Array.Reverse(a, i + 1, n - i - 1);
						res.Add(new List<T>(a).ToArray());
						next = true;
					}
				}
				return res;
			}

			//var sw = new Stopwatch();
			//sw.Start();

			var strList = new List<string>();
			var hash = new HashSet<string>();

			var p = AllPermutation(Enumerable.Range(0, slist.Length).ToArray());

			foreach (var indexes in p) {
				var sb = new StringBuilder();
				//Console.WriteLine(string.Join(" ", item));
				foreach (var index in indexes) {
					sb.Append(slist[index]);
				}

				string str = sb.ToString();
				if (hash.Contains(str) == false) {
					strList.Add(str);
					hash.Add(str);
				}
			}

			strList.Sort();

			/*
			foreach (var item in strList) {
				Console.WriteLine($"{item}");
			}
			*/

			Console.WriteLine($"{strList[k - 1]}");
		}

		public static void D()
		{

		}

		public static void E()
		{

		}
	}
}

