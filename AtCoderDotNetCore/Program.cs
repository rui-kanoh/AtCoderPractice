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
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var b = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			long max = a[0] * b[0];
			long maxA = a[0];
			for (var i = 0; i < n; ++i) {
				long answer = 0;
				if (i >= 1) {
					maxA = Math.Max(maxA, a[i]);
					long value = maxA * b[i];
					max = Math.Max(max, value);
				}

				answer = max;

				Console.WriteLine($"{answer}");
			}
		}

		public static void B()
		{
			var nq = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nq[0];
			var q = nq[1];
			var llist = new List<long>();
			var rlist = new List<long>();
			var tlist = new List<long>();

			for (var i = 0; i < q; ++i) {
				var lrt = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				llist.Add(lrt[0]);
				rlist.Add(lrt[1]);
				tlist.Add(lrt[2]);
			}

			var a = new long[n];
			for (var i = 0; i < q; ++i) {
				for (var j = llist[i] - 1; j <= rlist[i] - 1; ++j) {
					a[j] = tlist[i];
				}
			}

			var builder = new StringBuilder();
			for (var i = 0; i < n; ++i) {
				builder.AppendLine($"{a[i]}");
			}

			Console.WriteLine(builder.ToString());
		}

		public static void C()
		{
			long n = long.Parse(Console.ReadLine());

			var transporters = new long[5];
			transporters[0] = long.Parse(Console.ReadLine());
			transporters[1] = long.Parse(Console.ReadLine());
			transporters[2] = long.Parse(Console.ReadLine());
			transporters[3] = long.Parse(Console.ReadLine());
			transporters[4] = long.Parse(Console.ReadLine());

			long min = transporters.Min();
			long p = (long)Math.Ceiling((double)n / min);
			long time = (p - 1) + 5;

			Console.WriteLine($"{time}");
		}

		public static void D()
		{
			var nm = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nm[0];
			var m = nm[1];

			var times = new List<long>();
			var rui = new long[n];
			for (var i = 0; i < n - 1; ++i) {
				times.Add(long.Parse(Console.ReadLine()));
			}

			for (var i = 0; i < n; ++i) {
				if (i == 0) {
					rui[0] = 0;
				} else {
					rui[i] = rui[i - 1] + times[i - 1];
				}
			}

			var dates = new List<(long start, long goal)>();
			long date = 0;
			long olddate = 0;
			for (var i = 0; i < m; ++i) {
				date = long.Parse(Console.ReadLine());
				if (date > 0) {
					dates.Add((olddate, date + olddate));
				} else {
					dates.Add((date + olddate, olddate));
				}

				olddate += date;
			}

			long total = 0;
			//var values = new List<long>();
			foreach (var item in dates) {
				var value = rui[item.goal] - rui[item.start];
				//values.Add(value);
				total += value;
			}

			long denominator = 10 * 10 * 10 * 10 * 10;
			var answer = total % denominator;

			Console.WriteLine($"{answer}");
		}

		public static void E()
		{

		}
	}
}

