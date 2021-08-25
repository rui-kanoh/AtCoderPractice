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
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var mat = new int[h, w];

			var rList = new int[h];
			var cList = new int[w];
			for (var i = 0; i < h; ++i) {
				var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				int rsum = 0;
				for (var j = 0; j < a.Length; ++j) {
					mat[i, j] = a[j];
					rsum += a[j];
					cList[j] += a[j];
				}

				rList[i] = rsum;
			}

			for (var i = 0; i < rList.Length; ++i) {
				for (var j = 0; j < cList.Length; ++j) {
					var matB = rList[i] + cList[j] - mat[i, j];
					if (j < w - 1) {
						Console.Write($"{matB} ");
					} else {
						Console.WriteLine($"{matB}");
					}
				}
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
			string s = Console.ReadLine();
			var list = s.ToCharArray().ToList();
			int sindex = list.IndexOf('A');
			list.Reverse();
			int eindex = list.Count - list.IndexOf('Z');

			int answer = eindex - sindex;
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			//TLE
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var mat = new int[h, w];

			var rList = new int[h];
			var cList = new int[w];
			for (var i = 0; i < h; ++i) {
				var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				int rsum = 0;
				for (var j = 0; j < a.Length; ++j) {
					mat[i, j] = a[j];
					rsum += a[j];
					cList[j] += a[j];
				}

				rList[i] = rsum;
			}

			for (var i = 0; i < rList.Length; ++i) {
				for (var j = 0; j < cList.Length; ++j) {
					var matB = rList[i] + cList[j] - mat[i, j];
					if (j < w - 1) {
						Console.Write($"{matB} ");
					} else {
						Console.WriteLine($"{matB}");
					}
				}
			}
		}

		public static void C()
		{
			var nl = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nl[0];
			var l = nl[1];

			long deno = (long)(Math.Pow(10.0, 9.0) + 7.0);
			BigInteger answer = 0;

			long fact(long n, long r)
			{
				if (n == r) {
					return r;
				}

				return fact(n - 1, r) * n;
			}

			long comb(long n, long r)
			{
				var fn = fact(n, r);
				var fr = fact(r, 1);
				return fn / fr;
			}

			long lcount = n / l;

			if (lcount == 0) {
				answer = 1;
			} else {
				for (var i = 1; i <= lcount; ++i) {
					long count = n - (i * l) + i;
					answer += comb(count, i);
				}

				// 全部1の場合を加算
				++answer;
			}

			answer %= deno;

			Console.WriteLine($"{answer}");
		}

		public static void D()
		{
			var ns = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = ns[0];
			var s = ns[1];
			var alist = new List<long>();
			var blist = new List<long>();
			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				alist.Add(ab[0]);
				blist.Add(ab[1]);
			}

			// n <= 100 なのでビット全探索は無理
			// DPでやるんだろうけどどうやればいいんだ？


		}

		public static void E()
		{

		}
	}
}

