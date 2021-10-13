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
			var nq = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nq[0];
			var q = nq[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var diffs = new long[a.Length - 1];
			for (var i = 0; i < diffs.Length - 1; ++i) {
				diffs[i] = a[i] - a[i + 1];
			}

			long Calc(long[] e)
			{
				long value = 0;
				for (var i = 0; i < e.Length - 1; ++i) {
					value += Math.Abs(e[i] - e[i + 1]);
				}

				return value;
			}

			var total = Calc(a);

			var builder = new StringBuilder();
			for (var i = 0; i < q; ++i) {
				var lrv = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var l = lrv[0] - 1;
				var r = lrv[1] - 1;
				var v = lrv[2];

				if (l > 0) {
					total += (-Math.Abs(diffs[l - 1]) + Math.Abs(diffs[l - 1] - v));
					diffs[l - 1] -= v;
				}

				if (r < a.Length - 1) {
					total += (-Math.Abs(diffs[r]) + Math.Abs(diffs[r] + v));
					diffs[r] += v;
				}

				builder.Append($"{total}" + Environment.NewLine);
			}

			var answer = builder.ToString();
			Console.WriteLine($"{answer}");
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
			int n = int.Parse(Console.ReadLine());

			long value = 10000;
			long total = 0;
			for (var i = 1; i <= n; ++i) {
				total += value * i;
			}

			long answer = total / n;
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			bool isOK = false;
			long diff = 0;
			for (var i = 0; i < n; ++i) {
				diff += Math.Abs(a[i] - b[i]);
			}

			if (diff <= k) {
				if (IsOdd(diff) == IsOdd(k)) {
					isOK = true;
				}
			}

			var answer = isOK ? "Yes" : "No";
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

