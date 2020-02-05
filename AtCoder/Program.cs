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

			for (long i = a; i < a + k && i <= b; ++i) {
				Console.WriteLine(i.ToString());
			}

			List<long> list = new List<long>();
			for (long i = b; i > b - k + 1 && i >= a; --i) {
				list.Add(i);
			}

			for (int i = list.Count - 1; i >= 0; --i) {
				//Console.WriteLine(list[i].ToString());
			}

			//Console.WriteLine(remain.ToString());

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

class BuyingSweets {

}

