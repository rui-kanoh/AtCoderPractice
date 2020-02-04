using AtCoder.Abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Exec(args);
				Console.WriteLine("============ Retry ============");
				Console.Out.Flush();
			}
		}

		private static void Exec(string[] args)
		{
			QuestionA
				.Main(args);
		}

		public class Debug
		{
			public static void Log(string message)
			{
				Console.WriteLine("DEBUG:" + message);
			}
		}
	}
}
