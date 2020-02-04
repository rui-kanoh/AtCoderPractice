using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder.Lib
{
    public static class Calc
    {
        /// <summary>
        /// x / a以上の最大の整数を求める
        /// </summary>
        public static long Ceiling(long x, long a)
        {
            return Convert.ToInt32(Math.Ceiling((double)x / a));
        }
    }
}
