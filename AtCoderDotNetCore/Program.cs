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
using System.Drawing;
using System.Net;
using System.Xml.Schema;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using System.Security.Cryptography;

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
            string s = Console.ReadLine();

            long ln = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string[] inputStrArray = Console.ReadLine().Split(" ");

            var array = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
            var larray = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();

            var answer = 0;

            Console.WriteLine($"{answer}");
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



        public static void Binominal()
        {
            int n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split(" ").Select(i => (int.Parse(i))).ToList();

            if (a.Count == 2) {
                string str = a[0] > a[1] ? $"{a[0]} {a[1]}" : $"{a[1]} {a[0]}";
                Console.WriteLine(str);
                return;
            }

            int max = a.Max();
            var answer = 0;
            int min = int.MaxValue;
            foreach (var item in a) {
                if (min > Math.Abs(item * 2 - max)) {
                    min = Math.Abs(item * 2 - max);
                    answer = item;
                }
            }

            Console.WriteLine($"{max} {answer}");
        }

        public static void KenkenRace()
        {
            var nabcd = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
            var n = nabcd[0];
            var a = nabcd[1] - 1;
            var b = nabcd[2] - 1;
            var c = nabcd[3] - 1;
            var d = nabcd[4] - 1;
            string s = Console.ReadLine();
            var mass = new bool[s.Length];

            bool isOK = true;
            for (var i = 0; i < s.Length; ++i) {
                mass[i] = s[i] == '.';

                if ((i == c || i == d) && mass[i] == false) {
                    isOK = false;
                    break;
                }

                if (i > 0 && i >= a && i <= d) {
                    if (mass[i - 1] == false && mass[i] == false) {
                        isOK = false;
                        break;
                    }
                }
            }

            if (isOK) {
                if (c < d) {
                    isOK = true;
                } else {
                    bool exists3blank = false;
                    for (var i = b; i <= d; ++i) {
                        if (i > 1
                            && i < s.Length - 1
                            && exists3blank == false) {
                            if (mass[i - 1] && mass[i] && mass[i + 1]) {
                                exists3blank = true;
                                break;
                            }
                        }
                    }

                    isOK = exists3blank;
                }
            }

            var answer = isOK ? "Yes" : "No";
            Console.WriteLine($"{answer}");
        }

        public static void Bitaro()
        {
            var hw = Console.ReadLine().Split(" ").Select(i => long.Parse(i)).ToArray();
            var h = hw[0];
            var w = hw[1];
            var mas = new char[h, w];


            var ruiO = new int[h, w];
            for (var i = 0; i < h; ++i) {
                string s = Console.ReadLine();
                for (var j = 0; j < s.Length; ++j) {
                    mas[i, j] = s[j];
                    if (j == 0) {
                        ruiO[i, j] = 0;
                    } else {
                        ruiO[i, j] = ruiO[i, j - 1];
                        if (s[j] == 'O') {
                            ++ruiO[i, j];
                        }
                    }
                }
            }

            var ruiI = new int[h, w];
            for (var j = 0; j < w; ++j) {
                for (var i = 0; i < h; ++i) {
                    if (i == 0) {
                        ruiI[i, j] = 0;
                    } else {
                        ruiI[i, j] = ruiI[i - 1, j];
                        if (mas[i, j] == 'I') {
                            ++ruiI[i, j];
                        }
                    }
                }
            }

            long count = 0;

            for (var i = 0; i < h; ++i) {
                for (var j = 0; j < w; ++j) {
                    if (mas[i, j] == 'J') {
                        long countI = ruiI[h - 1, j] - ruiI[i, j];
                        long countO = ruiO[i, w - 1] - ruiO[i, j];
                        count += countI * countO;
                    }
                }
            }

            Console.WriteLine($"{count}");
        }
        
        public class Vector
        {
            public int X;
            public int Y;
            public Vector(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public static void HentaiKamen()
        {
            var xy = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
            var x = xy[0];
            var y = xy[1];
            var ab = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
            var a = ab[0];
            var b = ab[1];
            var ss = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
            var sx = ss[0];
            var sy = ss[1];
            var tt = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray();
            var tx = tt[0];
            var ty = tt[1];
            var AS = new Vector(sx - 0, sy - a);
            var AB = new Vector(x, b - a);
            var AT = new Vector(tx - 0, ty - a);

            int CrossVector(Vector a, Vector b)
            {
                return a.X * b.Y - a.Y * b.X;
            }

            int CrossVector2(Vector a, Vector b)
            {
                int value = CrossVector(a, b);
                return value != 0 ? value / Math.Abs(value) : value;
            }

            bool isCross1 = CrossVector2(AS, AB) * CrossVector2(AT, AB) < 0;
            var TA = new Vector(0 - tx, a - ty);
            var TS = new Vector(sx - tx, sy - ty);
            var TB = new Vector(x - tx, b - ty);
            bool isCross2 = CrossVector2(TA, TS) * CrossVector2(TB, TS) < 0;
            bool isCross = isCross1 && isCross2;
            Console.WriteLine(isCross ? "Yes" : "No");
        }
    }
}

