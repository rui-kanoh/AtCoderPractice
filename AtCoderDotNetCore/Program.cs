using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AtCoderDotNetCore
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
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static void Exec()
		{
			string s = Console.ReadLine();

			long ln = long.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(" ");

			var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static void A()
		{
			var abc = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = abc[0];
			var b = abc[1];
			var c = abc[2];

			for (var i = 1; i <= 127; ++i) {
				if (i % 3 == a && i % 5 == b && i % 7 == c) {
					Console.WriteLine($"{i}");
				}
			}
		}

		public static void B()
		{
			long n = long.Parse(Console.ReadLine());

			var dict = new Dictionary<long, long>();
			for (var i = 0; i < n; ++i) {
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				dict.Add(ab[0], ab[1]);
			}

			long max = dict.Keys.Max();
			long remain = dict[max];

			var answer = max + remain;
			Console.WriteLine($"{answer}");
		}

		public class Train
		{
			public long Front { get; set; }
			public long Back { get; set; }
			public long Value { get; set; }
		}

		public static void C()
		{
			var nq = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nq[0];
			var q = nq[1];

			var trains = new Train[n];
			for (var i = 0; i < n; ++i) {
				trains[i] = new Train() {
					Front = -1,
					Back = -1,
					Value = i,
				};
			}

			var results = new List<string>();

			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var index = query[0];
				if (index == 1) {
					var x = query[1] - 1;
					var y = query[2] - 1;
					trains[x].Back = y;
					trains[y].Front = x;
				} else if (index == 2) {
					var x = query[1] - 1;
					var y = query[2] - 1;
					trains[x].Back = -1;
					trains[y].Front = -1;
				} else {
					var x = query[1] - 1;

					var list = new List<long>();
					var top = trains[x];

					if (top.Front != -1) {
						while (top.Front != -1) {
							top = trains[top.Front];
						}
					}

					var end = trains[top.Value];
					while (end.Value != -1) {
						list.Add(end.Value + 1);
						if (end.Back != -1) {
							end = trains[end.Back];
						} else {
							break;
						}
					}

					string str = $"{list.Count} {string.Join(" ", list)}";
					results.Add(str);
				}
			}

			foreach (var result in results) {
				Console.WriteLine($"{result}");
			}
		}

		public static void D()
		{

		}

		public static void E()
		{

		}
	}
}

