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
		public static int Calc(int value)
		{
			int total = 0;
			int ans = value / 10000;
			total += ans;
			value -= 10000 * ans;
			ans = value / 1000;
			total += ans;
			value -= 1000 * ans;
			ans = value / 100;
			total += ans;
			value -= 100 * ans;
			ans = value / 10;
			total += ans;
			value -= 10 * ans;
			total += value;

			return total;
		}
		
		public static void Exec()
		{
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			int n = array[0];
			int a = array[1];
			int b = array[2];

			int total = 0;
			for (var i = 1; i <= n; ++i) {
				int answer = Calc(i);
				if (a <= answer && answer <= b) {
					total += i;
				}
			}

			Console.WriteLine($"{total}");

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

