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
			var hw = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var h = hw[0];
			var w = hw[1];
			var mat = new int[h, w];
			for (var i = 0; i < h; ++i) {
				var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				for (var j = 0; j < a.Length; ++j) {
					mat[i, j] = a[j];
				}
			}

			var rList = new List<int>();
			for (var i = 0; i < h; ++i) {
				int sum = 0;
				for (var j = 0; j < w; ++j) {
					sum += mat[i, j];
				}

				rList.Add(sum);
			}

			var cList = new List<int>();
			for (var i = 0; i < w; ++i) {
				int sum = 0;
				for (var j = 0; j < h; ++j) {
					sum += mat[j, i];
				}

				cList.Add(sum);
			}

			var matB = new int[h, w];
			for (var i = 0; i < h; ++i) {
				for (var j = 0; j < w; ++j) {
					matB[i, j] = rList[i] + cList[j] - mat[i, j];
					if (j < w - 1) {
						Console.Write($"{matB[i, j]} ");
					} else {
						Console.WriteLine($"{matB[i, j]}");
					}
				}
			}
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
			string s = Console.ReadLine();
			var list = s.ToCharArray().ToList();
			int sindex = list.IndexOf('A');
			list.Reverse();
			int eindex = list.Count - list.IndexOf('Z');

			int answer = eindex - sindex;
			Console.WriteLine($"{answer}");
		}

		public static void B()
		{

		}

		public static void C()
		{

		}

		public static void D()
		{

		}

		public static void E()
		{

		}
	}
}

