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

	public class Plane
	{
		public long Time;
		public long X;
		public long Y;
	}

	public static class Question
	{
		public static void Exec()
		{
			long n = int.Parse(Console.ReadLine());
			var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			var dict = new Dictionary<long, long>();
			for (var i = 0; i < n; ++i) {
				if (dict.ContainsKey(array[i]) == false) {
					dict.Add(array[i], 1);
				} else {
					++dict[array[i]];
				}
			}

			long total = 0;
			foreach (var item in dict) {
				if (item.Key < item.Value) {
					total += item.Value - item.Key;
				} else if (item.Key > item.Value) {
					total += item.Value;
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

