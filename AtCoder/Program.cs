using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			// 整数配列の入力
			var abk = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long a = abk[0];
			long b = abk[1];
			long k = abk[2];

			List<long> listA = new List<long>();
			for (long i = a; i < a + k && i <= b; ++i) {
				listA.Add(i);
			}

			foreach (var item in listA) {
				Console.WriteLine(item.ToString());
			}

			List<long> listB = new List<long>();
			for (long i = b; i >= b - k + 1 && i > listA.Last(); --i) {
				listB.Add(i);
			}

			listB.Reverse();
			foreach (var item in listB) {
				Console.WriteLine(item.ToString());
			}

			//Console.WriteLine(remain.ToString());

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

class BuyingSweets {

}

