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

	public class Node<T>
	{
		public bool IsVisited { get; set; } = false;
		public int Length { get; set; } = 0;
		public int Id { get; set; }
		public int ParentId { get; set; }
		public T Value { get; set; }
		public List<Node<T>> Children { get; } = new List<Node<T>>();

		public void AddChild(Node<T> child)
		{
			child.ParentId = Id;
			Children.Add(child);
		}
	}

	public static class Question
	{
		public static int id = 2;
		public static char[] chars = { 'a', 'b', 'c' };

		public static void MakeTree(int max, Node<char> tree)
		{
			if (tree)

			foreach (var c in chars) {
				var node = new Node<char>() {
					Id = id,
					Value = c,
				};
				tree.AddChild(node);
				++id;
			}
		}

		public static void Exec()
		{
			int n = int.Parse(Console.ReadLine());

			var tree = new Node<char>() {
				Id = 1,
				ParentId = -1,
				Value = ' ',
			};

			

			for (var i = 0; i < n; ++i) {
				
			}

			var pass = new List<char>();
			pass.Add(' ');

			while (pass.Count != 0) {
				foreach (var c in chars) {
					pass.Add(c);
					foreach (var c1 in chars) {
						pass.Add(c1);
					}
				}
			}


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

			long n = long.Parse(Console.ReadLine());

			string[] inputStrArray = Console.ReadLine().Split(' ');

			var inputLongArray = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();

			string result = "";

			Console.WriteLine(result);

			Console.Out.Flush();

			Console.ReadKey();
		}
	}
}

