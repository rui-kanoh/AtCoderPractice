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
			var nk = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];

			BigInteger answer = 0;
			long denominator = (long)Math.Pow(10, 9) + 7;
			if (n == 1) {
				answer = k % denominator;
			} else if (n == 2) {
				if (k  == 1 || k == 2) {
					answer = 0;
				} else {
					answer = ((k % denominator) * ((k - 1) % denominator)) % denominator;
				}
			} else {
				answer = ((k % denominator) * ((k - 1) % denominator) % denominator);

				long exp = n - 2;
				var exponents = Lib.Calc.CalcExponentiations(k - 2, exp);
				int index = 0;
				while (exp != 0) {
					if ((exp & 0x1) != 0) {
						var ans = exponents[index] % denominator;
						answer = (answer * ans) % denominator;
					}

					exp >>= 1;
					++index;
				}
			}


			Console.WriteLine($"{answer}");
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
			long n = long.Parse(Console.ReadLine());

			if (n % 2 == 0) {
				Console.WriteLine($"{n}");
			} else {
				Console.WriteLine($"{2 * n}");
			}
		}

		public static void B()
		{
			var Q = int.Parse(Console.ReadLine());
			var deque = new Lib.Deque<int>();
			var answers = new List<int>();
			for (var i = 0; i < Q; ++i) {
				var tx = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var t = tx[0];
				var x = tx[1];
				if (t == 1) {
					deque.PushFront(x);
				} else if (t == 2) {
					deque.PushBack(x);
				} else {
					answers.Add(deque[x - 1]);
				}
			}

			foreach (var item in answers) {
				Console.WriteLine($"{item}");
			}
			/*
			var Q = int.Parse(Console.ReadLine());
			var list = new List<int>();
			var answers = new List<int>();
			for (var i = 0; i < Q; ++i) {
				var tx = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var t = tx[0];
				var x = tx[1];
				if (t == 1) {
					list.Insert(0, x);
				} else if (t == 2) {
					list.Add(x);
				} else {
					if (list.Count > x - 1) {
						answers.Add(list[x - 1]);
					}
				}
			}

			foreach (var item in answers) {
				Console.WriteLine($"{item}");
			}
			*/
		}

		public static void C()
		{

		}

		public static void D()
		{
			var n = int.Parse(Console.ReadLine());
			var listX = new List<long>();
			var listY = new List<long>();

			for (var i = 0; i < n; ++i) {
				var xy = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var x = xy[0];
				var y = xy[1];
				listX.Add(x);
				listY.Add(y);
			}

			listX.Sort();
			listY.Sort();
			int medianIndex = n / 2;
			long factoryX = listX[medianIndex];
			long factoryY = listY[medianIndex];
			long sumX = 0;
			long sumY = 0;
			foreach (var item in listX) {
				sumX += Math.Abs(item - factoryX);
			}

			foreach (var item in listY) {
				sumY += Math.Abs(item - factoryY);
			}

			long sum = sumX + sumY;

			Console.WriteLine($"{sum}");
		}

		public static void E()
		{
			
		}

		public class Holiday
		{
			public bool isHoliday = true;
			public bool usesPaid = false;
		}

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

