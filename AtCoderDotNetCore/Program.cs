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

	public static class Question
	{
		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void Exec()
		{
			string s = Console.ReadLine();
			var deq = new Deque<char>(s.Length);
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

