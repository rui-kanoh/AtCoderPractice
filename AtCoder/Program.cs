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

