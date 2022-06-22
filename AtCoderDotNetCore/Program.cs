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
		public static void ExecTemp()
		{
			long num = long.Parse(Console.ReadLine());

			// indexエラー対応で周り5マス余裕を取る
			var map = new bool[num + 10, num + 10];
			var mapOrigin = new bool[num + 10, num + 10];

			for (int i = 0; i < num; ++i) {
				string s = Console.ReadLine();
				for (int j = 0; j < num; ++j) {
					if (s[j] == '#') {
						map[i + 5, j + 5] = mapOrigin[i + 5, j + 5] = true;
					}
				}
			}

			// mapの初期化
			void InitializeMap()
			{
				for (int k = 0; k < num + 10; ++k) {
					for (int l = 0; l < num + 10; ++l) {
						map[k, l] = mapOrigin[k, l];
					}
				}
			}

			// 最初から連結成分が1つの場合

			bool isOK = false;

			// 任意のマスを黒にして（もともと黒の場合は何もせず）、そこを基点に6つの連続要素があるかを探す
			// 探索範囲は指定したマスを基点に10x10のマスで探索する
			int changeNum = 2;
			for (int i = 5; i < num + 5 && isOK == false; ++i) {
				for (int j = 5; j < num + 5 && isOK == false; ++j) {
					//InitializeMap();

					changeNum = map[i, j] == false ? 1 : 2;

					// 上下左右ナナメの4パターンみればOK

					// upper
					int blackCount = 1;
					for (int k = i + 1; k <= i + 5; ++k) {
						if (map[k, j]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}

					// lower
					changeNum = map[i, j] == false ? 1 : 2;

					blackCount = 1;
					for (int k = i - 1; k > i - 5; --k) {
						if (map[k, j]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}

					// left
					changeNum = map[i, j] == false ? 1 : 2;
					blackCount = 1;
					for (int l = j + 1; l <= i + 5; ++l) {
						if (map[i, l]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}

					// right
					changeNum = map[i, j] == false ? 1 : 2;
					blackCount = 1;
					for (int l = j - 1; l > i + 5; --l) {
						if (map[i, l]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}

					// topleft
					changeNum = map[i, j] == false ? 1 : 2;
					blackCount = 1;
					for (int k = i + 1, l = j + 1; k <= j + 5 && l <= i + 5; ++k, ++l) {
						if (map[k, l]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}

					// topleft
					changeNum = map[i, j] == false ? 1 : 2;
					blackCount = 1;
					for (int k = i + 1, l = j - 1; k <= i + 5 && l > l - 5 ; ++k, --l) {
						if (map[k, l]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}

					// bottomleft
					changeNum = map[i, j] == false ? 1 : 2;
					blackCount = 1;
					for (int k = i - 1, l = j + 1; k > j - 5 && l <= l + 5; --k, ++l) {
						if (map[k, l]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}

					// bottomright
					changeNum = map[i, j] == false ? 1 : 2;
					blackCount = 1;
					for (int k = i - 1, l = j - 1; k > j - 5 && l > l - 5; --k, --l) {
						if (map[k, l]) {
							++blackCount;
						} else {
							if (changeNum > 0) {
								++blackCount;
								--changeNum;
							} else {
								break;
							}
						}
					}

					if (blackCount == 6) {
						Console.WriteLine("Yes");
						return;
					}
				}
			}

			Console.WriteLine("No");
		}

		public static void Exec()
		{
			ExecTemp();
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

		public static void Poker()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
			var a = ab[0] == 1 ? 14 : ab[0];
			var b = ab[1] == 1 ? 14 : ab[1];

			var answer = "Draw";
			if (a > b) {
				answer = "Alice";
			} else if (a < b) {
				answer = "Bob";
			}

			Console.WriteLine($"{answer}");
		}

		public static void Snow()
		{
			var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var a = ab[0];
			var b = ab[1];
			var diff = b - a;

			long index = 0;
			for (var i = 1; i <= 999; ++i) {
				if (i + 1 == diff) {
					index = i;
					break;
				}
			}

			var answer = index * (index + 1) / 2 - a;

			Console.WriteLine($"{answer}");
		}

		public static void Index()
		{
			string s = Console.ReadLine();
			int i = int.Parse(Console.ReadLine());
			var answer = s[i - 1];

			Console.WriteLine($"{answer}");
		}

		public static void Takahashi()
		{
			string X = Console.ReadLine();
			string s = Console.ReadLine();
			var answer = s.Replace(X, "");
			Console.WriteLine($"{answer}");
		}


		public static void A()
		{
			long n = long.Parse(Console.ReadLine());

			var answer = 0;

			Console.WriteLine($"{answer}");
		}

		public static void Nankisei()
		{
			string s = Console.ReadLine();

			int count = 0;
			for (var i = 0; i < s.Length; ++i)
			{
				if (Char.IsNumber(s[i]))
				{
					if (i < s.Length - 1)
					{
						if (Char.IsNumber(s[i + 1]))
						{
							count = int.Parse(s[i].ToString()) * 10 + int.Parse(s[i + 1].ToString());
						}
						else
						{
							count = int.Parse(s[i].ToString());
						}

						break;
					}
					else
					{
						count = int.Parse(s[i].ToString());
						break;
					}
				}
			}

			var answer = count;
			Console.WriteLine($"{answer}");
		}

		public static void JumpingTakahashi()
		{
			var nx = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
			var n = nx[0];
			var x = nx[1];

			var dp = new bool[n + 1, x + 1];
			dp[0, 0] = true;

			for (var i = 1; i <= n; ++i)
			{
				var ab = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
				var a = ab[0];
				var b = ab[1];

				for (int j = 0; j <= x; ++j)
				{
					if (dp[i - 1, j])
					{
						if (j <= x - a)
						{
							dp[i, j + a] = true;
						}

						if (j <= x - b)
						{
							dp[i, j + b] = true;
						}
					}
				}
			}

			/*
			for (int j = 0; j <= x; ++j)
			{
				for (var i = 0; i <= n; ++i)
                {
					Console.Write(dp[i, j] ? "1 " : "0 ");
				}

				Console.WriteLine("");
			}
			*/

			var answer = dp[n, x] ? "Yes" : "No";
			Console.WriteLine($"{answer}");
		}
	}
}

