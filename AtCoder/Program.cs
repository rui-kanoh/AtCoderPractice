using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			long n = long.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			
			for (var i = 1; i <= n; ++i) {
				long sum = 0;

				for (var j = 0; j <= n; ++j) {
					if (j == 0) {
						sum += Math.Abs(array[j]);
					} else if (j == n) {
						sum += Math.Abs(array[j - 1]);
					} else {
						sum += Math.Abs(array[j] - array[j - 1]);
					}
				}

				if (i == 1) {
					sum += Math.Abs(0 - array[1])
						- Math.Abs(array[1] - array[0])
						- Math.Abs(0 - array[0]);
				} else if (i == n) {
					sum += Math.Abs(0 - array[n - 2])
						- Math.Abs(array[n - 1] - array[n - 2])
						- Math.Abs(0 - array[n - 1]);
				} else {
					sum += Math.Abs(array[i] - array[i - 2])
						- Math.Abs(array[i - 1] - array[i - 2])
						- Math.Abs(array[i] - array[i - 1]);
				}

				Console.WriteLine(sum.ToString());
			}

			Console.Out.Flush();

			Console.ReadLine();
		}
	}
}

