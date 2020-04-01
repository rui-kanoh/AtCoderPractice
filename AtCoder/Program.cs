using System;
using System.Collections.Generic;
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
		public static void Turn(bool[,] mat, int k, int l)
		{
			for (var i = 0; i < 3; ++i) {
				for (var j = 0; j < 3; ++j) {
					mat[k - 1 + i, l - 1 + j] = !mat[k - 1 + i, l - 1 + j];
				}
			}
		}

		public static void Exec()
		{
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long n = array[0];
			long m = array[1];
			bool[,] matrix = new bool[n + 2, m + 2];

			for (var i = 0; i < n; ++i) {
				for (var j = 0; j < m; ++j) {
					Turn(matrix, i + 1, j + 1);
				}
			}

			int count = 0;
			for (var i = 0; i < n; ++i) {
				for (var j = 0; j < m; ++j) {
					if (matrix[i + 1, j + 1]) {
						++count;
					}
				}
			}

			Console.WriteLine($"{count}");

			Console.ReadLine();
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
	}
}

