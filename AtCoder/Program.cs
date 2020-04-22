using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
		}

		public static void Exec()
		{
			var scaner = new Scanner2();
			var n = scaner.Long();
			var array = scaner.ArrayLong((int)n);
			var list = array.ToList();

			var oddList = list.Where(x => IsOdd(x)).ToList();
			var noOddList = list.Where(x => IsOdd(x) == false).ToList();

			bool isOK = false;
			if (oddList.Count == 0)
			{
				isOK = true;
			} else if (oddList.Count - 1 <= noOddList.Count)
			{
				var list4 = noOddList.Where(x => x % 4 == 0).ToList();
				if (noOddList.Count - list4.Count == 0 && oddList.Count <= list4.Count + 1)
				{
					isOK = true;
				} else if (oddList.Count <= list4.Count)
				{
					isOK = true;
				}
			}

			if (isOK) {
				Console.WriteLine($"Yes");
			} else {
				Console.WriteLine($"No");
			}

			Console.ReadKey();
		}

		public class Scanner2
		{
			private readonly char[] delimiter_ = new char[] { ' ' };
			private readonly string filePath_;
			private readonly Func<string> reader_;
			private string[] buf_;
			private int index_;

			public Scanner2(string file = "")
			{
				if (string.IsNullOrWhiteSpace(file))
				{
					reader_ = Console.ReadLine;
				}
				else
				{
					filePath_ = file;
					var fs = new StreamReader(file);
					reader_ = fs.ReadLine;
				}
				buf_ = new string[0];
				index_ = 0;
			}

			public string Next()
			{
				if (index_ < buf_.Length)
				{
					return buf_[index_++];
				}

				string st = reader_();
				while (st == "")
				{
					st = reader_();
				}

				buf_ = st.Split(delimiter_, StringSplitOptions.RemoveEmptyEntries);
				if (buf_.Length == 0)
				{
					return Next();
				}

				index_ = 0;
				return buf_[index_++];
			}

			public int Int() => int.Parse(Next());
			public long Long() => long.Parse(Next());
			public double Double() => double.Parse(Next());

			public int[] ArrayInt(int N, int add = 0)
			{
				int[] Array = new int[N];
				for (int i = 0; i < N; i++)
				{
					Array[i] = Int() + add;
				}
				return Array;
			}

			public long[] ArrayLong(int N, long add = 0)
			{
				long[] Array = new long[N];
				for (int i = 0; i < N; i++)
				{
					Array[i] = Long() + add;
				}
				return Array;
			}

			public double[] ArrayDouble(int N, double add = 0)
			{
				double[] Array = new double[N];
				for (int i = 0; i < N; i++)
				{
					Array[i] = Double() + add;
				}
				return Array;
			}
		}
	}
}

namespace Temp {
	public class Question
	{
		public void Exec()
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

