using System;
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

			for (var i = a; i <= b; ++i) {
				if (i <= k || b - k <= i) {
					Console.WriteLine(i.ToString());
				}
			}

			//Console.WriteLine(remain.ToString());

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

class BuyingSweets {

}

