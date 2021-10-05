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

			long count = 0;

			
			Console.WriteLine($"{count}");
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
			var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var value = ab[0] * ab[1];
			var answer = value % 2 == 1 ? "Odd" : "Even";
			Console.WriteLine($"{answer}");
		}

		public static BigInteger Gcd(BigInteger a, BigInteger b)
		{
			if (b == 0) {
				return a;
			}

			return Gcd(b, a % b);
		}

		public static BigInteger Lcm(BigInteger a, BigInteger b)
		{
			BigInteger g = Gcd(a, b);
			return a / g * b;
		}

		public static void B()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => BigInteger.Parse(i)).ToArray();
			var lcm = Lcm(ab[0], ab[1]);
			var max = (BigInteger)Math.Pow(10.0, 18.0);
			if (lcm > max) {
				Console.WriteLine("Large");
			} else {
				Console.WriteLine($"{lcm}");
			}
		}

		public static void C()
		{
			bool IsPrime(long num)
			{
				if (num < 2) return false;
				else if (num == 2) return true;
				else if (num % 2 == 0) return false;

				double sqrtNum = Math.Sqrt(num);
				for (int i = 3; i <= sqrtNum; i += 2) {
					if (num % i == 0) {
						// 素数ではない
						return false;
					}
				}

				// 素数である
				return true;
			}


			long n = long.Parse(Console.ReadLine());
			if (IsPrime(n)) {
				Console.WriteLine($"0");
				return;
			}

			// https://algo-logic.info/prime-fact/
			static Dictionary<long, long> GetPrimeFactor(long n)
			{
				var ret = new Dictionary<long, long>();
				for (long i = 2; i * i <= n; i++) {
					if (n % i != 0) continue;
					long tmp = 0;
					while (n % i == 0) {
						tmp++;
						n /= i;
					}

					ret.Add(i, tmp);
				}

				if (n != 1) {
					ret.Add(n, 1);
				}

				return ret;
			}

			long count = 0;
			var factors = GetPrimeFactor(n);
			foreach (var item in factors) {
				count += item.Value;
			}

			long devideNum = (long)Math.Ceiling(Math.Log2(count));

			Console.WriteLine($"{devideNum}");
		}

		public static void D()
		{

		}

		public static void E()
		{

		}
	}
}

