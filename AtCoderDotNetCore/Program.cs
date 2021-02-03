using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;


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
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			int n = nk[0];
			int k = nk[1];
			var p = new List<string>();
			for (var i = 0; i < n; ++i) {
				p.Add(Console.ReadLine());
			}

			int answer = 0;

			if (n < k || n % k != 0) {
				Console.WriteLine($"{answer}");
				return;
			}

			while (p.Count != 0) {
				string str = p[0];
				var strs = new List<string>();
				strs.Add(str);
				p.RemoveAt(0);

				var indexes = new List<int>();
				int count = 1;
				for (var i = 0; i < p.Count; ++i) {
					bool isOK = true;
					for (var j = 0; j < strs.Count; ++j) {
						if (p[i][0] == strs[j][0]) {
							isOK = false;
							break;
						}
					}

					if (isOK) {
						indexes.Add(i);
						strs.Add(p[i]);
						if (k > 1) {
							++count;
						}
					}

					if (count == k) {
						break;
					}

					if (i == p.Count - 1) {
						Console.WriteLine($"{answer}");
						return;
					}
				}

				for (var i = indexes.Count - 1; i >= 0; --i) {
					if (indexes.Count == 0) {
						continue;
					}

					if (indexes[i] > p.Count - 1) {
						continue;
					}

					p.RemoveAt(indexes[i]);
				}

				strs.Clear();
				indexes.Clear();
				++answer;
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

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{
			string s = Console.ReadLine();
			bool isOK = s.StartsWith("YAKI");
			string answer = isOK ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{
			string s = Console.ReadLine();
			string answer = s.Replace("O", "0");
			answer = answer.Replace("D", "0");
			answer = answer.Replace("I", "1");
			answer = answer.Replace("Z", "2");
			answer = answer.Replace("S", "5");
			answer = answer.Replace("B", "8");
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{

		}

		public static void D()
		{

		}

		public static void E()
		{

		}

		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static long Gcd(long a, long b)
		{
			if (b == 0) {
				return a;
			}

			return Gcd(b, a % b);
		}

		public static long Lcm(long a, long b)
		{
			long g = Gcd(a, b);
			return a / g * b;
		}
	}
}

