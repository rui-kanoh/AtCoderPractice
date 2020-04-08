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

	public class Plane
	{
		public long Time;
		public long X;
		public long Y;
	}

	public static class Question
	{
		public static void Exec()
		{
			long n = int.Parse(Console.ReadLine());
			List<Plane> list = new List<Plane>();
			var p = new Plane();
			p.Time = 0;
			p.X = 0;
			p.Y = 0;
			list.Add(p);

			for (var j = 0; j < n; ++j) {
				var array = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
				var plane = new Plane();
				plane.Time = array[0];
				plane.X = array[1];
				plane.Y = array[2];
				list.Add(plane);
			}

			string answer = "Yes";
			for (var j = 1; j <= n; ++j) {
				long time = list[j].Time - list[j - 1].Time;
				long x = Math.Abs(list[j].X - list[j - 1].X);
				long y = Math.Abs(list[j].Y - list[j - 1].Y);
				if (x + y > time) {
					answer = "No";
					break;
				}

				if ((x + y) % 2 != time % 2) {
					answer = "No";
					break;
				}
			}

			Console.WriteLine($"{answer}");

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

