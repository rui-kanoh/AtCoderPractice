using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder.Lib
{
	class PrimeFactors
	{
		/// <summary>
		/// 素因数分解。
		/// 出展：https://qiita.com/y_miyoshi/items/da814d96e8890224aad3
		/// </summary>
		public static IEnumerable<long> PrimeFactorsImpl(long n)
		{
			long i = 2;
			long tmp = n;

			while (i * i <= n) //※1
			{
				if (tmp % i == 0)
				{
					tmp /= i;
					yield return i;
				}
				else
				{
					i++;
				}
			}
			if (tmp != 1) yield return tmp;//最後の素数も返す
		}
	}
}
