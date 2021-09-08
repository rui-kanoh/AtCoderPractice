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
			var nl = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nl[0];
			var l = nl[1];
			var k = long.Parse(Console.ReadLine());

			// この時点で累積和になっている
			var alist = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList();
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
			var nab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nab[0];
			var a = nab[1];
			var b = nab[2];
			if (a < b) {
				var temp = a;
				a = b;
				b = temp;
			}

			var min = 0;
			var max = 0;
			if (a == n && b == n) {
				min = n;
				max = n;
			} else {
				max = b;
				var temp = (n - a) - b;
				min = temp > 0 ? 0 : Math.Abs(temp);
			}

			Console.WriteLine($"{max} {min}");
		}

		public static void B()
		{
			(bool isFound, int left, int right) BinarySearch(long value, List<long> list)
			{
				int left = -1;
				int right = list.Count;
				while (right - left > 1) {
					int mid = (right + left) / 2;
					if (list[mid] == value
						|| right - left <= 1) {
						return (true, mid, mid);
					} else if (list[mid] > value) {
						right = mid;
					} else {
						left = mid;
					}
				}

				if (right - left <= 1) {
					return (true, left > 0 ? left : 0, right < list.Count ? right : list.Count - 1);
				}

				if (left == -1 && right == list.Count) {
					return (false, 0, list.Count - 1);
				} else if (left == -1) {
					return (false, 0, 0);
				} else if (right == list.Count) {
					return (false, list.Count - 1, list.Count - 1);
				}

				return (false, left, right);
			}

			var n = long.Parse(Console.ReadLine());
			var alist = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToList();
			var q = long.Parse(Console.ReadLine());
			var blist = new List<long>();
			for (var i = 0; i < q; ++i) {
				blist.Add(long.Parse(Console.ReadLine()));
			}

			alist.Sort();

			for (var i = 0; i < q; ++i) {
				(bool isFound, int left, int right) = BinarySearch(blist[i], alist);
				if (isFound) {
					long value = Math.Abs(blist[i] - alist[left]);
					long value2 = Math.Abs(blist[i] - alist[right]);
					var answer = Math.Min(value, value2);
					Console.WriteLine($"{answer}");
				} else {
					Console.WriteLine($"0");
				}
			}
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

