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
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var all = a.Sum();
			var all_10 = all / 10;
			var alist = new List<long>(a);
			alist.AddRange(a);
			/*
			var rui = new long[alist.Count + 1];
			rui[0] = alist[0];
			for (var i = 1; i < alist.Count; ++i) {
				rui[i] = rui[i - 1] + alist[i];
			}
			*/

			bool exists = false;
			/*
			if (alist[0] == all_10) {
				exists = true;
			} else {
				for (var left = 1; left < n && exists == false; ++left) {
					if (alist[left] == all_10) {
						exists = true;
						break;
					} else if (alist[left] > all_10) {
						continue;
					}

					long sum = 0;
					for (var j = 0; j < n && exists == false; ++j) {
						int right = left + 1 + j;
						sum = rui[right] - rui[left - 1];
						if (sum == all_10) {
							exists = true;
							break;
						} else if (sum > all_10) {
							break;
						}
					}
				}
			}
			*/

			int end = 1;
			long sum = 0;
			for (int start = 0; start < n; ++start) {
				// sum >= all_10になるまでendを伸ばす
				sum = alist[start];
				while (end < start + 1 + n) {
					if (sum >= all_10) {
						++end;
						break;
					}

					sum += alist[end];
					++end;
				}

				if (sum == all_10) {
					exists = true;
					break;
				}

				if (end == start) {
					end = start;
				}
			}

			var answer = exists ? "Yes" : "No";
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
			var xt = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var x = xt[0];
			var t = xt[1];

			var answer = x - t >= 0 ? x - t : 0;
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{

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

