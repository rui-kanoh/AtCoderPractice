namespace AtCoderDotNetCore.Lib
{
	class UnionFind
    {
        // 親要素のインデックスを保持する
        // 親要素が存在しない(自身がルートである)とき、マイナスでグループの要素数を持つ
        public int[] Parents { get; set; }
        public UnionFind(int n)
        {
            Parents = new int[n];
            for (int i = 0; i < n; i++) {
                // 初期状態ではそれぞれが別のグループ(ルートは自分自身)
                // ルートなのでマイナスで要素数(1個)を保持する
                Parents[i] = -1;
            }
        }

        // 要素xのルート要素はどれか
        public int Find(int x)
        {
            // 親がマイナスの場合は自分自身がルート
            if (Parents[x] < 0) return x;
            // ルートが見つかるまで再帰的に探す
            // 見つかったルートにつなぎかえる
            Parents[x] = Find(Parents[x]);
            return Parents[x];
        }

        // 要素xの属するグループの要素数を取得する
        public int Size(int x)
        {
            // ルート要素を取得して、サイズを取得して返す
            return -Parents[Find(x)];
        }

        // 要素x, yが同じグループかどうか判定する
        public bool Same(int x, int y)
        {
            return Find(x) == Find(y);
        }

        // 要素x, yが属するグループを同じグループにまとめる
        public bool Union(int x, int y)
        {
            // x, y のルート
            x = Find(x);
            y = Find(y);
            // すでに同じグループの場合処理しない
            if (x == y) return false;

            // 要素数が少ないグループを多いほうに書き換えたい
            if (Size(x) < Size(y)) {
                var tmp = x;
                x = y;
                y = tmp;
            }
            // まとめる先のグループの要素数を更新
            Parents[x] += Parents[y];
            // まとめられるグループのルートの親を書き換え
            Parents[y] = x;
            return true;
        }
    }
}
