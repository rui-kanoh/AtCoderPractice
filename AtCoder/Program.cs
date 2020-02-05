using System;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			// 整数の入力
			long x = long.Parse(Console.ReadLine());
			long a = long.Parse(Console.ReadLine());
			long b = long.Parse(Console.ReadLine());

			long remain = x - a;
			while (remain >= b) {
				remain -= b;
			}

			Console.WriteLine(remain.ToString());

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

class BuyingSweets {

}

