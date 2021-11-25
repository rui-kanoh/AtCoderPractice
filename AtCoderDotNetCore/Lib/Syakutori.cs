using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderDotNetCore.Lib
{
	public class Holiday
	{
		public bool isHoliday = true;
		public bool usesPaid = false;
	}

	public class SyakutoriTest
	{
		public static void Syakutori()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var h = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var holidays = new Holiday[n];
			for (var i = 0; i < n; ++i) {
				holidays[i] = new Holiday();
				holidays[i].isHoliday = h[i] == 1 ? true : false;
			}

			int max = 0;
			int end = 0;

			int sum = 0;
			int paid = k;
			for (int start = 0; start < n; ++start) {
				// paidが0になるまでendを伸ばす
				while (end < n) {
					if (holidays[end].isHoliday) {
						++sum;
					} else {
						if (paid > 0) {
							--paid;
							holidays[end].usesPaid = true;
							++sum;
						} else {
							break;
						}
					}

					++end;
				}

				max = Math.Max(max, sum);
				//Console.WriteLine($"{start} {end} {paid} {sum} {max}");

				if (end == start) {
					++end;
				}

				if (holidays[start].isHoliday) {
					--sum;
				} else {
					if (holidays[start].usesPaid) {
						holidays[start].usesPaid = false;
						++paid;
						--sum;
					}
				}

				//Console.WriteLine($"{start} {end} {paid} {sum}");
			}

			var answer = max;

			Console.WriteLine($"{answer}");
		}
	}

}
