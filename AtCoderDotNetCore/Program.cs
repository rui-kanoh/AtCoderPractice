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
			var a = new int[n, n];
			for (var i = 0; i < n; ++i) {
				var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				for (var j = 0; j < array.Length; ++j) {
					a[i, j] = array[j];
				}
			}

			List<T[]> NextPermutation<T>(params T[] array) where T : IComparable
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

			var rDict = new Dictionary<int, int>();
			var rDict2 = new Dictionary<int, int>();
			int m = int.Parse(Console.ReadLine());
			for (var i = 0; i < m; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				rDict[xy[0] - 1] = xy[1] - 1;
				rDict2[xy[1] - 1] = xy[0] - 1;
			}

			int min = int.MaxValue;

			/*
			var list = NextPermutation<int>(Enumerable.Range(0, 3).ToArray());
			foreach (var items in list) {
				foreach (var item in items) {
					Console.Write($"{item} ");
				}
				Console.WriteLine("");
			}
			*/


			void Dfs(List<int> items, int num)
			{
				if (items.Count == num) {
					if (items.Distinct().Count() != items.Count()) {
						return;
					}

					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					for (var i = 1; i < items.Count - 1; ++i) {
						if (rDict.ContainsKey(items[i])) {
							if (rDict[items[i]] == items[i - 1]
								|| rDict[items[i]] == items[i + 1]) {
								return;
							}
						}

						if (rDict2.ContainsKey(items[i])) {
							if (rDict2[items[i]] == items[i - 1]
							|| rDict2[items[i]] == items[i + 1]) {
								return;
							}
						}
					}

					int time = 0;
					for (var j = 0; j < items.Count; ++j) {
						time += a[items[j], j];
					}

					min = Math.Min(min, time);
					return;
				}


				for (var i = 0; i < num; ++i) {
					items.Add(i);
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), n);

			/*
			if (min == int.MaxValue) {
				Console.WriteLine("-1");
			} else {
				Console.WriteLine($"{min}");
			}
			*/
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
			var answer = s + "pp";
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			int n = int.Parse(Console.ReadLine());

			var carray = new[] { "(", ")", };
			var validList = new List<string>();

			bool Check(List<string> items)
			{
				int numL = items.Count(s => s == "(");
				int numR = items.Count(s => s == ")");
				if (numL != numR) {
					return false;
				}

				bool isValid = true;
				numL = 0;
				numR = 0;
				for (var i = 0; i < items.Count; ++i) {
					if (items[i] == "(") {
						++numL;
					} else {
						if (numL > numR) {
							++numR;
						} else {
							isValid = false;
							break;
						}

						if (numL == numR) {
							numL = numR = 0;
						}
					}
				}

				return isValid;
			}

			void Dfs(List<string> items, int num)
			{
				if (items.Count == num) {
					/*
					foreach (var item in items) {
						Console.Write($"{item} ");
					}
					Console.WriteLine("");
					*/

					bool isValid = Check(items);
					if (isValid) {
						string all = "";
						foreach (var item in items) {
							all += item;
						}

						validList.Add(all);
					}

					return;
				}


				for (var i = 0; i < carray.Length; ++i) {
					items.Add(carray[i]);
					Dfs(items, num);
					items.RemoveAt(items.Count - 1);
				}
			}

			if (n % 2 == 1) {
				return;
			}


			Dfs(new List<string>(), n);
			if (validList.Any()) {
				validList.Sort();
			}

			foreach (var item in validList) {
				Console.WriteLine($"{item}");
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

