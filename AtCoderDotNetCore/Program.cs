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
			int n = int.Parse(Console.ReadLine());

			var list1 = new List<(long point, int number)>();

			var list2 = new List<(long point, int number)>();

			for (var i = 0; i < n; ++i) {
				var cp = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				if (cp[0] == 1) {
					list1.Add((cp[1], i));
					list2.Add((0, i));
				} else {
					list2.Add((cp[1], i));
					list1.Add((0, i));
				}
			}

			var listRui1 = new List<long>();
			listRui1.Add(list1[0].point);
			for (var i = 1; i < n; ++i) {
				if (list1[i].number != i) {
					listRui1.Add(listRui1[i - 1]);
				} else {
					listRui1.Add((list1[i].point + listRui1[i - 1]));
				}
			}

			/*
			var index = 0;
			foreach (var item in listRui1) {
				Console.WriteLine($"{index} {item}");
				++index;
			}
			*/

			var listRui2 = new List<long>();
			listRui2.Add(list2[0].point);
			for (var i = 1; i < list2.Count; ++i) {
				if (list2[i].number < i) {
					listRui2.Add(listRui2[i - 1]);
				} else {
					listRui2.Add((list2[i].point + listRui2[i - 1]));
				}
			}

			/*
			index = 0;
			foreach (var item in listRui2) {
				Console.WriteLine($"{index} {item}");
				++index;
			}
			*/

			/*
			var listRui2 = new List<(long point, int number)>();
			listRui2.Add(list2[0]);
			for (var i = 1; i < list2.Count; ++i) {
				listRui2.Add((list2[i].point + listRui2[i - 1].point, list2[i].number));
			}
			*/

			var lrList = new List<(int l, int r)>();
			int q = int.Parse(Console.ReadLine());
			for (var i = 0; i < q; ++i) {
				var lr = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				lrList.Add((lr[0] - 1, lr[1] - 1));
			}

			for (var i = 0; i < q; ++i) {
				//long a = listRui1[dict1[lrList[i].r]].point - listRui1[dict1[lrList[i].l] > 0 ? dict1[lrList[i].l] - 1 : 0].point;
				//long b = listRui2[dict2[lrList[i].r]].point - listRui2[dict2[lrList[i].l] > 0 ? dict2[lrList[i].l] - 1 : 0].point;
				int indexAr = lrList[i].r >= listRui1.Count ? listRui1.Count - 1 : lrList[i].r;
				long al = lrList[i].l > 0 ? listRui1[lrList[i].l - 1] : 0;
				long a = listRui1[indexAr] - al;
				int indexBr = lrList[i].r >= listRui2.Count ? listRui2.Count - 1 : lrList[i].r;
				long bl = lrList[i].l > 0 ? listRui2[lrList[i].l - 1] : 0;
				long b = listRui2[indexBr] - bl;
				Console.WriteLine($"{a} {b}");
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
			int n = int.Parse(Console.ReadLine());
			var answer = n >= 1200 ? "ARC" : "ABC";
			Console.WriteLine(answer);
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

