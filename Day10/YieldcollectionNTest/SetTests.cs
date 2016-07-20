using System;
using NUnit.Framework;
using YieldCollection;
using System.Diagnostics;

namespace YieldcollectionNTest
{
    [TestFixture]
    public class SetTests
    {

        [Test]
        public void SetTest_foreach_test()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" }; 
            Set<string> set = new Set<string>(s1);
            Set<string> set2 = new Set<string>(s2);
            set.ExceptWith(set2);
            set.UnionWith(set2);
            set = new Set<string>(s1);
            set.SymmetricExceptWith(set2);
            set = new Set<string>(s1);
            set.IntersectWith(set2);
            set.IntersectWith(set);
        }

    }
}