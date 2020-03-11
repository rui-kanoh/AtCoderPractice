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


			Func<List<char>, bool> checker2 = c2 => {
				bool ok = checker(c2[0]) && checker(c2[1]) && checker(c2[2]);
				ok = ok && (c2[0] != c2[1] && c2[0] != c2[2]);
				return ok;
			};

			int count = 0;
			for (var i = 0; i < names.Count; ++i) {
				for (var j = i; j < names.Count; ++j) {
					for (var k = j; k < names.Count; ++k) {
						List<char> chars = new List<char>() { names[i][0], names[j][0], names[k][0] };
						if (checker2(chars)) {
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

