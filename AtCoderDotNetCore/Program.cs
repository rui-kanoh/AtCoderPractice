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
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

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

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void A()
		{

		}

		public static void B()
		{
			int n = int.Parse(Console.ReadLine());
			var words = new string[n];
			for (var i = 0; i < n; ++i) {
				words[i] = Console.ReadLine();
			}

			bool wins = false;
			bool isfinished = true;
			if (n > 1) {
				var hash = new HashSet<string>();
				hash.Add(words[0]);

				for (var i = 1; i < words.Length; ++i) {
					if (hash.Contains(words[i])) {
						wins = IsOdd(i) ? true : false;
						isfinished = false;
						break;
					}

					string old = words[i - 1];
					if (old[old.Length - 1] != words[i][0]) {
						wins = IsOdd(i) ? true : false;
						isfinished = false;
						break;
					}

					hash.Add(words[i]);
				}
			}

			var answer = isfinished
				? "DRAW"
				: wins ? "WIN" : "LOSE";
			Console.WriteLine($"{answer}");
		}

		public static void C()
		{
			string s = Console.ReadLine();
			var deq = new Deque.Deque<char>(s.Length);
			int reverseCount = 0;

			for (var i = 0; i < s.Length; ++i) {
				if (s[i] == 'R') {
					if (deq.Length > 0) {
						++reverseCount;
					}
				} else {
					if (IsOdd(reverseCount)) {
						if (deq.Length > 0 && deq[0] == s[i]) {
							deq.PopFront();
						} else {
							deq.PushFront(s[i]);
						}
					} else {
						if (deq.Length > 0 && deq[deq.Length - 1] == s[i]) {
							deq.PopBack();
						} else {
							deq.PushBack(s[i]);
						}
					}
				}
			}

			string t = "";
			if (deq.Length > 0) {
				var builder = new StringBuilder();
				for (var i = 0; i < deq.Length; ++i) {
					int index = IsOdd(reverseCount)
						? deq.Length - 1 - i
						: i;
					builder.Append(deq[index]);
				}

				t = builder.ToString();
			}

			Console.WriteLine(t);
		}

		public static void D()
		{
		}

		public static void E()
		{
		}

		public static void F()
		{
		}

		public static void G()
		{

		}

		public static void H()
		{

		}
	}
}

