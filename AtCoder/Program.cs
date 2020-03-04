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
			long N = long.Parse(Console.ReadLine());
			List<string> nlist = new List<string>();
			for (int i = 0; i < N; ++i) {
				nlist.Add(Console.ReadLine());
			}

			long M = long.Parse(Console.ReadLine());
			List<string> mlist = new List<string>();
			for (int i = 0; i < M; ++i) {
				mlist.Add(Console.ReadLine());
			}

			int max = 0;
			for (int i = 0; i < nlist.Count; ++i) {
				int total = 0;
				for (int j = 0; j < nlist.Count; ++j) {
					if (nlist[i] == nlist[j]) {
						++total;
					}
				}

				for (int j = 0; j < mlist.Count; ++j) {
					if (nlist[i] == mlist[j]) {
						--total;
					}
				}

				if (max < total) {
					max = total;
				}
			}

			Console.WriteLine($"{max}");
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

