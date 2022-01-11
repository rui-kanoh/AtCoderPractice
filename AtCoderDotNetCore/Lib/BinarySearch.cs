using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderDotNetCore.Lib
{
	public static class BinarySearchFunctions
	{
		public static (bool isFound, int left, int right) BinarySearch(int value, List<int> list)
		{
			int left = -1;
			int right = list.Count;
			while (right - left > 1) {
				int mid = (right + left) / 2;
				if (list[mid] == value) {
					return (true, mid, mid);
				} else if (list[mid] > value) {
					right = mid;
				} else {
					left = mid;
				}
			}

			if (left == -1 && right == list.Count) {
				return (false, 0, list.Count - 1);
			} else if (left == -1) {
				return (false, 0, 0);
			} else if (right == list.Count) {
				return (false, list.Count - 1, list.Count - 1);
			}

			return (false, left, right);
		}

		public static bool Check(long value, List<long> list, int count)
		{
			long position = 0;
			for (var i = 0; i < list.Count; ++i) {
				long length = list[i] - position;
				if (length >= value) {
					--count;
					position = list[i];
				}
			}

			return count > 0 ? false : true;
		}

		public static (long ok, long ng) BinarySearch(List<long> list, int count, long l)
		{
			long ok = 1;
			long ng = l;
			while (ng - ok > 1) {
				long mid = (ng + ok) / 2;
				if (Check(mid, list, count)) {
					ok = mid;
				} else {
					ng = mid;
				}
			}

			return (ok, ng);
		}
	}
}
