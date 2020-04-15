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

	public static class Question
	{
		public static void Exec()
		{
			var larray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
			long N = long.Parse(Console.ReadLine());
			long Q = larray[0];
			long H = larray[1];
			long S = larray[2];
			long D = larray[3];
			var dict = new Dictionary<double, long>();
			dict.Add(0.25, Q);
			dict.Add(0.5, H);
			dict.Add(1.0, S);
			dict.Add(2.0, D);

			long answer = 0;
			long min = long.MaxValue;

			for (var i = 0; i <= N / 2; ++i) {
				for (var j = 0; j <= N; ++j) {
					for (var k = 0; k <= N * 2; ++k) {
						double q = 2.0 * i + 1.0 * j + 0.5 * k;
						var ans = dict[2.0] * i + dict[1.0] * j + dict[0.5] * k;
						if (N < q) {
							continue;
						}

						if (N - q > 0) {
							ans += (long)((N - q) / 0.25 * dict[0.25]);
						}

						if (min > ans) {
							min = ans;
						}
					}
				}
			}

			answer = min;

			Console.WriteLine($"{answer}");
			Console.ReadKey();
		}
	}
}

namespace Temp {
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

