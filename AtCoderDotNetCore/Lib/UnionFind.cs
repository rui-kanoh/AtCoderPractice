using System.Collections.Generic;
using System.Linq;

namespace AtCoderDotNetCore.Lib
{
    public class UnionFind
    {
        List<int> parents;

        public int GroupCount { get; private set; }

        public UnionFind(int x)
        {
            parents = Enumerable.Repeat(-1, x).ToList();
            GroupCount = x;
        }

        public int Find(int x)
        {
            if (parents[x] < 0) return x;
            else
            {
                parents[x] = Find(parents[x]);
                return parents[x];
            }
        }

        public void Union(int x, int y)
        {
            (x, y) = (Find(x), Find(y));

            if (x != y)
            {
                if (Count(x) < Count(y)) (x, y) = (y, x);
                parents[x] += parents[y];
                parents[y] = x;
                GroupCount--;
            }
        }

        public int Count(int x) => -parents[Find(x)];

        public bool IsSame(int x, int y) => Find(x) == Find(y);
    }
}
