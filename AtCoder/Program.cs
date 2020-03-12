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
			List<string> names = new List<string>();
			long n = long.Parse(Console.ReadLine());
			for (var i = 0; i < n; ++i) {
				names.Add(Console.ReadLine());
			}

			Func<char, bool> checker = c => {
				if (c == 'M' || c == 'A' || c == 'R' || c == 'C' || c == 'H') {
					return true;
				} else {
					return false;
				}
			};

			int[] P = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 2 };
			int[] Q = { 1, 1, 1, 2, 2, 3, 2, 2, 3, 3 };
			int[] R = { 2, 3, 4, 3, 4, 4, 3, 4, 4, 4 };

			Func<char, char, char, bool> checker2 = (c0, c1, c2) => {
				bool ok = checker(c0) && checker(c1) && checker(c2);
				ok = ok && c0 != c1 && c0 != c2 && c1 != c2;
				return ok;
			};

			int count = 0;
			for (var i = 0; i < names.Count; ++i) {
				for (var j = i + 1; j < names.Count; ++j) {
					for (var k = j + 1; k < names.Count; ++k) {
						if (checker2(names[i][0], names[j][0], names[k][0])) {
							++count;
						}
					}
				}
			}

			Console.WriteLine($"{count}");
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

