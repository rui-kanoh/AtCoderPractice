using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			var Instance = new Question();
			Instance.Exec();
		}
	}

	public class Question
	{
		public void Exec()
		{
			//string s = Console.ReadLine();
			int n = int.Parse(Console.ReadLine());
			//var array = Console.ReadLine().Split(' ').Select(iii => int.Parse(iii)).ToArray();
			string name = "atcoder";
			Dictionary<string, int> pop = new Dictionary<string, int>();
			int total = 0;
			for (var i = 0; i < n; ++i) {
				string[] strs = Console.ReadLine().Split(' ');
				int num = int.Parse(strs[1]);
				pop.Add(strs[0], num);
				total += num;
			}

			foreach (var item in pop) {
				if (item.Value > total / 2) {
					name = item.Key;
					break;
				}
			}

			Console.WriteLine($"{name}");
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

			long n = long.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var inputLongArray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);

			Console.Out.Flush();

			Console.ReadKey();
		}
	}
}

