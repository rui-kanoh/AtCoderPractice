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
			int n = int.Parse(Console.ReadLine());
			List<int> nlist = new List<int>();
			var array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			for (int i = 0; i < n; ++i) {
				nlist.Add(array[i]);
			}


			nlist.Sort();
			int index = n > 2 ? n / 2 : 1;
			int median = nlist[index];
			for (int i = 0; i < n; ++i) {
				if (array[i] < median) {
					Console.WriteLine($"{median}");
				} else {
					Console.WriteLine($"{nlist[index - 1]}");
				}
			}

			Console.Out.Flush();
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

