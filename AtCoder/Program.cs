using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			var Instance = new SS();
			Instance.Exec();
		}
	}

	public class SS
	{
		public void Exec()
		{
			string s = Console.ReadLine();
			string gu = s;
			bool isGu = false;
			int max = 0;

			Console.WriteLine($"{s.Length}");

			for (var i = 0; i < s.Length / 2; ++i) {
				int pivot = new Random().Next(gu.Length);
				gu = s.Remove(pivot, 1);
				pivot = new Random().Next(gu.Length);
				gu = gu.Remove(pivot, 1);
				string sub = gu.Substring(0, gu.Length / 2);
				if (gu.Contains(sub)) {
					isGu = true;
				} else {
					pivot = new Random().Next(gu.Length);
					gu = s.Remove(pivot, 1);
					pivot = new Random().Next(gu.Length);
					gu = gu.Remove(pivot, 1);
					sub = gu.Substring(0, gu.Length / 2);

					if (gu.Contains(sub)) {
						isGu = true;
					}
				}

				if (isGu && max < gu.Length) {
					max = gu.Length;
				}

				Console.WriteLine($"{i}, {max}, {gu}, {sub}");
			}

			Console.WriteLine($"{max}");

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

namespace Temp {

	public class Bridge
	{
		public void Exec()
		{
			var nm = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long n = nm[0];
			long m = nm[1];
			List<long> alist = new List<long>();
			List<long> blist = new List<long>();
			for (var j = 0; j < m; ++j) {
				var ab = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
				alist.Add(ab[0]);
				blist.Add(ab[1]);
			}

			Console.Out.Flush();

			Console.ReadLine();
		}
	}

	public class SplittingPile
	{
		public void Exec()
		{
			long n = long.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			long sum = array.Sum();
			//Console.WriteLine($"{sum}");
			//int pivot = new Random().Next(n);

			long min = (long)int.MaxValue;
			long sunuke = array[0];
			long arai = sum - sunuke;
			long diff = Math.Abs(arai - sunuke);
			if (min > diff) {
				min = diff;
			}

			//Console.WriteLine($"{sunuke}, {arai}");

			for (var i = 1; i < n - 1; ++i) {
				sunuke += array[i];
				arai = sum - sunuke;
				diff = Math.Abs(arai - sunuke);
				if (min > diff) {
					min = diff;
				}

				//Console.WriteLine($"{i}, {sunuke}, {arai}");
			}

			Console.WriteLine($"{min}");

			Console.Out.Flush();

			Console.ReadLine();
		}
	}

	public class Grouping
	{
		public void Exec()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int x = array[0];
			int y = array[1];
			List<int> g1 = new List<int>() { 1, 3, 5, 7, 8, 10, 12 };
			List<int> g2 = new List<int>() { 4, 6, 9, 11 };
			List<int> g3 = new List<int>() { 2 };

			bool contains = false;
			if ((g1.Contains(x) && g1.Contains(y))
				|| (g2.Contains(x) && g2.Contains(y))) {
				contains = true;
			}

			Console.WriteLine(contains ? "Yes" : "No");

			Console.Out.Flush();

			Console.ReadLine();
		}
	}

	public class QuestionA
	{
		public void Exec()
		{
			long n = long.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

