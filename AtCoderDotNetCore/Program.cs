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
		public static (bool isFound, int left, int right) BinarySearch(long value, List<long> list)
		{
			int left = -1;
			int right = list.Count;
			while (right - left > 1) {
				int mid = (right + left) / 2;
				if (list[mid] == value) {
					return (true, mid, mid);
				} else if (list[mid] > value) {
					right = mid;
				} else {
					left = mid;
				}
			}

			if (left == -1 || right == list.Count) {
				return (false, left, right);
			} else {
				return (true, left, right);
			}
		}
		/*
9
3
7
5
9
8
10
10
11
9
*/

		public static void Exec()
		{
			var n = int.Parse(Console.ReadLine());
			var alist = new List<long>();
			for (var i = 0; i < n; ++i) {
				var a = long.Parse(Console.ReadLine());
				alist.Add(a);
			}

			var lisTable = Enumerable.Repeat(long.MaxValue, n).ToList();
			lisTable[0] = 0;

			long length = 0;

			for (var i = 1; i < alist.Count; ++i) {
				(bool isFound, int left, int right) = BinarySearch(alist[i], lisTable);
				//Console.WriteLine($"{left},{right}");

				if (isFound) {
					if (lisTable[left] != long.MaxValue
						&& lisTable[right] == long.MaxValue) {
						if (lisTable[left] > alist[i]) {
							lisTable[left] = alist[i];
						} else {
							lisTable[right] = alist[i];
						}
					}
				}

				var limitedList = lisTable.Where(s => s != long.MaxValue).ToList();
				length = limitedList.Count;

				/*
				foreach (var item in lisTable) {
					Console.Write(item == long.MaxValue ? "∞ " : $"{item} ");
				}

				Console.WriteLine($"");
				*/
			}

			Console.WriteLine($"{length}");
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

			var strList = new List<string>();

			var p = Calc.AllPermutation(Enumerable.Range(0, slist.Length).ToArray());

			foreach (var indexes in p) {
				var sb = new StringBuilder();
				//Console.WriteLine(string.Join(" ", item));
				foreach (var index in indexes) {
					sb.Append(slist[index]);
				}

				string str = sb.ToString();
				strList.Add(str);
			}

			strList = strList.Distinct().ToList();
			strList.Sort();

			Console.WriteLine($"{strList[k - 1]}");
		}

		public static void D()
		{
			var n = int.Parse(Console.ReadLine());
			var alist = new List<long>();
			for (var i = 0; i < n; ++i) {
				var a = long.Parse(Console.ReadLine());
				alist.Add(a);
			}

			long max = 0;


			void Dfs(List<int> items, int num, int start)
			{
				/*
				if () {
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");

					max = Math.Max(items.Count, max);
					return;
				}
				*/

				for (var i = start + 1; i < n - 1; ++i) {
					items.Add(i);
					if (alist[i] >= alist[i + 1]) {

						foreach (var item in items) {
							Console.Write($"{item} ");
						}

						Console.WriteLine("");

						max = Math.Max(items.Count, max);
						break;
					}

					Dfs(items, num, i);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), n, -1);

			Console.WriteLine($"{max}");
		}

		public static void E()
		{

		}
	}
}

