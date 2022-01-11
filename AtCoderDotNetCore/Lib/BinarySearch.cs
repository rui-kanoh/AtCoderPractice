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
	}
}
