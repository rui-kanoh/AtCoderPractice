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
			string dirs = Console.ReadLine();

			int max = 0;

			for (int i = 1; i < dirs.Length - 1; ++i) {
				string a = dirs.Substring(0, i);
				a = new string(a.Distinct().ToArray());
				string b = dirs.Substring(i, dirs.Length - i);
				b = new string(b.Distinct().ToArray());

				int count = 0;
				for (int j = 0; j < a.Length; ++j) {
					if (b.Contains(a[j])) {
						++count;
					}
				}

				if (max < count) {
					max = count;
				}
			}

			Console.WriteLine($"{max}");
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

