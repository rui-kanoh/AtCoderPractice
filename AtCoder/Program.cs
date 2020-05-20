using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AtCoder
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
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			int q = array[1];
			var s = new string[q];
			for (var i = 0; i < q; ++i) {
				s[i] = Console.ReadLine();
			}

			var f = new string[n, n];
			for (var i = 0; i < n; ++i) {
				for (var j = 0; j < n; ++j) {
					f[i, j] = "N";
				}
			}

			for (var i = 0; i < q; ++i) {
				var sarray = s[i].Split(' ').Select(j => int.Parse(j)).ToArray();
				int index = sarray[0];
				switch (index) {
					case 1:
					default: {
						int a = sarray[1] - 1;
						int b = sarray[2] - 1;
						f[a, b] = "Y";
					}
						break;

					case 2: {
						int a = sarray[1] - 1;
						for (var j = 0; j < n; ++j) {
							if (f[j, a] == "Y") {
								f[a, j] = "Y";
							}
						}
					}
						break;

					case 3: {
						int a = sarray[1] - 1;
						for (var j = 0; j < n; ++j) {
							if (f[a, j] == "Y") {
								for (var k = 0; k < n; ++k) {
									if (f[j, k] == "Y") {
										f[a, k] = "Y";
									}
								}
							}
						}
					}
						break;
				}
			}

			for (var i = 0; i < n; ++i) {
				for (var j = 0; j < n; ++j) {
					Console.Write($"{f[i, j]}"); ;
				}

				Console.WriteLine("");
			}

			Console.ReadKey();
		}
	}
}

namespace Temp {
	public class Question
	{
		public static void Exec()
		{
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
			Console.SetOut(sw);

			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			long n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);

			Console.Out.Flush();

			Console.ReadKey();
		}

		public static void A()
		{
			string str = Console.ReadLine();
			try {
				int n = int.Parse(str);
				if (n <= 999) {
					Console.WriteLine($"{n * 2}");
				} else {
					Console.WriteLine("error");
				}
			} catch {
				Console.WriteLine("error");
			}
		}

		public static void B()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new long[n];
			for (var i = 0; i < n; ++i) {
				a[i] = long.Parse(Console.ReadLine());
			}

			for (var i = 0; i < n - 1; ++i) {
				if (a[i + 1] == a[i]) {
					Console.WriteLine($"stay");
				} else if (a[i + 1] < a[i]) {
					Console.WriteLine($"down {a[i] - a[i + 1]}");
				} else {
					Console.WriteLine($"up {a[i + 1] - a[i]}");
				}
			}
		}

		public static void C()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			var list = array.ToList();
			list.Sort();
			list.Reverse();
			Console.WriteLine($"{list[2]}");
		}

		public static void D()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new int[n];
			for (var i = 0; i < n; ++i) {
				a[i] = int.Parse(Console.ReadLine());
			}

			List<int> correctList = Enumerable.Range(1, n).ToList();
			var list = a.ToList();
			var diffList = correctList.Except<int>(list).ToList();
			if (diffList.Any() == false) {
				Console.WriteLine($"Correct");
			} else {
				int diff = diffList[0];
				var duplicates = list.GroupBy(name => name).Where(name => name.Count() > 1)
					.Select(group => group.Key).ToList();

				Console.WriteLine($"{duplicates[0]} {diff}");
			}
		}

		public static void E()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			int q = array[1];
			var s = new string[q];
			for (var i = 0; i < q; ++i) {
				s[i] = Console.ReadLine();
			}

			var f = new string[n, n];
			for (var i = 0; i < n; ++i) {
				for (var j = 0; j < n; ++j) {
					f[i, j] = "N";
				}
			}

			for (var i = 0; i < q; ++i) {
				var sarray = s[i].Split(' ').Select(j => int.Parse(j)).ToArray();
				int index = sarray[0];
				switch (index) {
					case 1:
					default: {
						int a = sarray[1] - 1;
						int b = sarray[2] - 1;
						f[a, b] = "Y";
					}
					break;

					case 2: {
						int a = sarray[1] - 1;
						for (var j = 0; j < n; ++j) {
							if (f[j, a] == "Y") {
								f[a, j] = "Y";
							}
						}
					}
					break;

					case 3: {
						int a = sarray[1] - 1;
						for (var j = 0; j < n; ++j) {
							if (f[a, j] == "Y") {
								for (var k = 0; k < n; ++k) {
									if (f[j, k] == "Y") {
										f[a, k] = "Y";
									}
								}
							}
						}
					}
					break;
				}
			}

			for (var i = 0; i < n; ++i) {
				for (var j = 0; j < n; ++j) {
					Console.Write($"{f[i, j]}"); ;
				}

				Console.WriteLine("");
			}
		}

		public static void F()
		{
		}

		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static long Gcd(long a, long b)
		{
			if (b == 0)
			{
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

