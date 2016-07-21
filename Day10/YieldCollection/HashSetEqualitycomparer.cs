using System;
using YieldCollection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldCollection
{
    class HashSetEqualitycomparer<HashSet> : IEqualityComparer<HashSet>
    {
        public bool Equals(HashSet x, HashSet y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(HashSet obj)
        {
            return obj.GetHashCode();
        }
    }
}
