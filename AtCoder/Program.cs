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
			var array = Console.ReadLine().Split(' ').Select(i => double.Parse(i)).ToArray();
			var x = new double[4];
			var y = new double[4];
			x[0] = array[0];
			y[0] = array[1];
			x[1] = array[2];
			y[1] = array[3];
			double[] vx1 = { x[1] - x[0], y[1] - y[0] };

			double[] vx2 = new double[2];
			double theta = 45.0 / 180.0 * Math.PI;
			vx2[0] = Math.Round((vx1[0] * Math.Cos(theta) - vx1[1] * Math.Sin(theta)) * Math.Sqrt(2));
			vx2[1] = Math.Round((vx1[0] * Math.Sin(theta) + vx1[1] * Math.Cos(theta)) * Math.Sqrt(2));
			x[2] = vx2[0] + x[0];
			y[2] = vx2[1] + y[0];

			theta = 90.0 / 180.0 * Math.PI;
			vx2[0] = Math.Round(vx1[0] * Math.Cos(theta) - vx1[1] * Math.Sin(theta));
			vx2[1] = Math.Round(vx1[0] * Math.Sin(theta) + vx1[1] * Math.Cos(theta));
			x[3] = vx2[0] + x[0];
			y[3] = vx2[1] + y[0];

			//string answer = "No";
			Console.WriteLine($"{x[2]:f0} {y[2]:f0} {x[3]:f0} {y[3]:f0}");
			Console.ReadLine();
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

