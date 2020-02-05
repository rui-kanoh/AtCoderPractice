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

			long j = 0;
			for (var i = a; i <= b; ++i) {
				if (j < k || b - k < i) {
					Console.WriteLine(i.ToString());
				}

				++j;
			}

			//Console.WriteLine(remain.ToString());

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

class BuyingSweets {

}

