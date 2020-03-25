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
		public static void Exec()
		{
			int[] es = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int b = int.Parse(Console.ReadLine());
			int[] ls = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int answer = 0;

			int count = 0;
			bool bou = false;
			for (var i = 0; i < 6; ++i) {

				for (var j = 0; j < 6; ++j) {
					if (es[i] == ls[j]) {
						++count;
					}
				}

				if (ls[i] == b) {
					bou = true;
				}
			}

			switch (count) {
				case 6:
					answer = 1;
					break;

				case 5:
					if (bou) {
						answer = 2;
					} else {
						answer = 3;
					}
					break;

				case 4:
					answer = 4;
					break;

				case 3:
					answer = 5;
					break;

				default:
					answer = 0;
					break;
			}

			Console.WriteLine($"{answer}");
			Console.ReadKey();
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

