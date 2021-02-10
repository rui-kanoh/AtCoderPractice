using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;


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
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			int ans = int.MaxValue;

			void Dfs(List<int> items, int last)
			{
				if (items.Count == k) {
					int count = 0;

					// 計算ロジック

					if (ans > count) {
						ans = count;
					}

					return;
				}

				// 重複を防ぐために自分のindexより大きいものだけを選ぶ
				int start = last + 1;

				for (int i = start; i < n; i++) {
					items.Add(i);
					Dfs(items, i);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), -1);

			Console.WriteLine($"{ans}");
		}

		public class DFS
		{
			public static long Total { get; set; } = 0;

			public static void Search(Node root)
			{
				if (root == null) {
					return;
				}

				Visit(root);
				if (root.Children != null) {
					foreach (var node in root.Children) {
						if (!node.Visited) {
							Search(node);
						}
					}
				}
			}

			private static void Visit(Node node)
			{
				node.Visited = true;
				Total += node.Value;
			}
		}

		public class BFS
		{
			public static void Search(Node root)
			{
				var queue = new Queue<Node>();
				Visit(root);
				queue.Enqueue(root);

				while (queue.Count != 0) {
					var current_node = queue.Dequeue();
					if (current_node.Children != null) {
						foreach (var node in current_node.Children) {
							if (!node.Visited) {
								Visit(node);
								queue.Enqueue(node);
							}
						}
					}
				}
			}

			private static void Visit(Node root)
			{
				root.Visited = true;
			}
		}

		public class Node
		{
			public bool Visited { get; set; }

			public List<Node> Children { get; set; } = new List<Node>();

			public long Value { get; set; } = 0;

			public int Index { get; set; } = -1;
		}

		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
			return isOdd;
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

			string result = "";

			Console.WriteLine(result);
		}

		public static void A()
		{
			string str = Console.ReadLine();
			bool isOK = true;

			int length = IsOdd(str.Length) ? str.Length / 2 : str.Length / 2 + 1;
			for (var i = 0; i < length; ++i) {
				if (str[i] != str[str.Length - i - 1]
					&& str[i] != '*'
					&& str[str.Length - i - 1] != '*') {
					isOK = false;
					break;
				}
			}

			Console.WriteLine(isOK ? "YES" : "NO");
		}

		public static void B()
		{
			string str = Console.ReadLine();
			str = str.Replace("Left", "<")
				.Replace("Right", ">")
				.Replace("AtCoder", "A");
			Console.WriteLine($"{str}");
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

		public static bool IsOdd(long n)
		{
			bool isOdd = n % 2 == 1;
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

		public static void SaitoDfs()
		{
			var nk = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var n = nk[0];
			var k = nk[1];
			var a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();

			int ans = int.MaxValue;

			void Dfs(List<int> items, int last)
			{
				if (items.Count == k) {
					int count = 0;

					// 計算ロジック

					if (ans > count) {
						ans = count;
					}

					return;
				}

				// 重複を防ぐために自分のindexより大きいものだけを選ぶ
				int start = last + 1;

				for (int i = start; i < n; i++) {
					items.Add(i);
					Dfs(items, i);
					items.RemoveAt(items.Count - 1);
				}
			}

			Dfs(new List<int>(), -1);

			Console.WriteLine($"{ans}");
		}
	}
}

