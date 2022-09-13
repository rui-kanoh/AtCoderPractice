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
using System.Reflection;

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
			StringFormation();
		}

		public static bool IsOdd(long n)
		{
			bool isOdd = (n & 0x1) == 0x1;
			return isOdd;
		}

		public static void StringFormation()
		{
			string s = Console.ReadLine();
			var q = int.Parse(Console.ReadLine());
			var deq = new Deque<char>(s.Length + q);
			for (var i = 0; i < s.Length; ++i) {
				deq.PushBack(s[i]);
			}

			int rotationCount = 0;
			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ");
				if (query[0] == "1") {
					++rotationCount;
				} else {
					var f = query[1];
					var c = query[2];
					if (f == "1") {
						if (IsOdd(rotationCount) == false) {
							deq.PushFront(c[0]);
						} else {
							deq.PushBack(c[0]);
						}
					} else {
						if (IsOdd(rotationCount) == false) {
							deq.PushBack(c[0]);
						} else {
							deq.PushFront(c[0]);
						}
					}
				}
			}

			var builder = new StringBuilder();
			for (var i = 0; i < deq.Length; ++i) {
				if (IsOdd(rotationCount) == false) {
					builder.Append(deq[i]);
				} else {
					builder.Append(deq[deq.Length - 1 - i]);
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

		public static void Rotation()
		{
			var nq = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nq[0];
			var q = nq[1];
			string s = Console.ReadLine();

			var builder = new StringBuilder();

			int count = 0;
			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
				var command = query[0];
				var x = query[1];
				if (command == 1) {
					count += x;
				} else {
					int index = (x - 1) - (count % n);
					if (index < 0) {
						index = s.Length + index;
					}

					builder.AppendLine($"{s[index]}");
				}
			}

			var answer = builder.ToString();
			Console.WriteLine($"{answer}");
		}

		public static void Cylinder()
		{
			int q = int.Parse(Console.ReadLine());

			var builder = new StringBuilder();

			Deque<long> deq = null;
			for (var i = 0; i < q; ++i) {
				var query = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				if (query[0] == 1) {
					var x = query[1];
					var c = query[2];
					var list = Enumerable.Repeat(x, (int)c).ToArray();
					if (deq != null) {
						var length = deq.Length + list.Length;
						deq = new Deque<long>(length);
					} else {
						deq = new Deque<long>(list.Length);
					}

					for (var j = 0; j < c; ++j) {
						deq.PushBack(x);
					}
				} else {
					if (deq != null) {
						var c = query[1];
						long count = 0;
						for (var j = 0; j < c; ++j) {
							count += deq.PopFront();
						}

						builder.AppendLine($"{count}");
					}
				}
			}

			var answer = builder.ToString();
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

