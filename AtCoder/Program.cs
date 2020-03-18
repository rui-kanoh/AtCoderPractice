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
			var Instance = new Question();
			Instance.Exec();
		}
	}

	public class Question
	{
		void DFS(int max, List<char> pass)
		{
			if (pass.Count == max) {
				Console.WriteLine(new string(pass.ToArray()));
				return;
			}

			for (int i = 0; i < 3; i++) {
				pass.Add((char)('a' + i));
				DFS(max, pass);
				pass.RemoveAt(pass.Count - 1);
			}
		}

		public void Exec()
		{
			int n = int.Parse(Console.ReadLine());
			char[] passwords = { 'a', 'b', 'c' };
			var pass = new List<char>();
			DFS(n, pass);

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

