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
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

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
			ExecTemp();
		}

		public static void ExecTemp()
		{
			var nq = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nq[0];
			var q = nq[1];
			string s = Console.ReadLine();
			var deq = new Deque<char>(s.Length);
			for (var i = 0; i < s.Length; ++i) {
				deq.PushBack(s[i]);
			}

			var builder = new StringBuilder();

			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var command = query[0];
				var x = query[1];
				if (command == 1) {
					for (var j = 0; j < x; ++j) {
						char c = deq.PopBack();
						deq.PushFront(c);
					}
				} else {
					builder.AppendLine($"{deq[x - 1]}");
				}
			}


			var answer = builder.ToString();
			Console.WriteLine($"{answer}");
		}
	}

	public class Deque<T> : IEnumerable<T>
	{
		public T this[int i]
		{
			get { return Buffer[(FirstIndex + i) % Capacity]; }
			set
			{
				if (i < 0) throw new ArgumentOutOfRangeException();
				Buffer[(FirstIndex + i) % Capacity] = value;
			}
		}

		private T[] Buffer;
		private int Capacity;
		private int FirstIndex;
		private int LastIndex
		{
			get { return (FirstIndex + Length) % Capacity; }
		}

		public int Length;

		public Deque(int capacity = 16)
		{
			Capacity = capacity;
			Buffer = new T[Capacity];
			FirstIndex = 0;
		}

		public void PushBack(T data)
		{
			if (Length == Capacity) Resize();
			Buffer[LastIndex] = data;
			Length++;
		}

		public void PushFront(T data)
		{
			if (Length == Capacity) {
				Resize();
			}

			var index = FirstIndex - 1;
			if (index < 0) {
				index = Capacity - 1;
			}

			Buffer[index] = data;
			Length++;
			FirstIndex = index;
		}

		public T PopBack()
		{
			if (Length == 0) throw new InvalidOperationException("データが空です。");
			var data = this[Length - 1];
			Length--;
			return data;
		}

		public T PopFront()
		{
			if (Length == 0) throw new InvalidOperationException("データが空です。");
			var data = this[0];
			FirstIndex++;
			FirstIndex %= Capacity;
			Length--;
			return data;
		}

		private void Resize()
		{
			var newArray = new T[Capacity * 2];
			for (int i = 0; i < Length; i++) {
				newArray[i] = this[i];
			}
			FirstIndex = 0;
			Capacity *= 2;
			Buffer = newArray;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < Length; i++) {
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < Length; i++) {
				yield return this[i];
			}
		}
	}
}

namespace AtCoderDotNetCore
{
	public class Template
	{
		public static void ExecTemp()
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

		public static long Gcd(long a, long b)
		{
			if (b == 0) {
				return a;
			}

			return Gcd(b, a % b);
		}

		public static long Lcm(long a, long b)
		{
			long g = Gcd(a, b);
			return a / g * b;
		}
	}
}

