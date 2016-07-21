using System;
using NUnit.Framework;
using YieldCollection;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.Timers;

namespace YieldcollectionNTest
{
    [TestFixture]
    public class HashSetTests
    {
        [Test]
        public void HashSetTest_Except()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "1" };
            HashSet<string> HashSet = new HashSet<string>(s1);
            HashSet<string> HashSet2 = new HashSet<string>(s2);
            HashSet<string> HashSet3 = new HashSet<string>(s3);
            HashSet.ExceptWith(HashSet2);
            Assert.IsTrue(Enumerable.SequenceEqual(HashSet, HashSet3));
        }


        [Test]
        public void HashSetTest_Union()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "1", "2", "3", "4", "5" };
            HashSet<string> HashSet = new HashSet<string>(s1);
            HashSet<string> HashSet2 = new HashSet<string>(s2);
            HashSet<string> HashSet3 = new HashSet<string>(s3);
            HashSet.UnionWith(HashSet2);
            Assert.IsTrue(Enumerable.SequenceEqual(HashSet, HashSet3));
        }

        [Test]
        public void HashSetTest_Intersect()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "2", "3", "4" };
            HashSet<string> HashSet = new HashSet<string>(s1);
            HashSet<string> HashSet2 = new HashSet<string>(s2);
            HashSet<string> HashSet3 = new HashSet<string>(s3);
            HashSet.IntersectWith(HashSet2);
            Assert.IsTrue(Enumerable.SequenceEqual(HashSet, HashSet3));
        }
        [Test]
        public void HashSetTest_SymmetricExcept()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "1", "5" };
            HashSet<string> HashSet = new HashSet<string>(s1);
            HashSet<string> HashSet2 = new HashSet<string>(s2);
            HashSet<string> HashSet3 = new HashSet<string>(s3);
            HashSet.SymmetricExceptWith(HashSet2);
            Assert.IsTrue(Enumerable.SequenceEqual(HashSet, HashSet3));
        }

        [Test]
        public void HashSetTest_Add()
        {
            var HashSet = new HashSet<object>();
            HashSet.Add(1);
            HashSet.Add("2");
            var temp = new HashSet<object>();
            temp.Add(1);
            temp.Add("2");
            Assert.IsTrue(Enumerable.SequenceEqual(HashSet, temp));
        }
        [Test]
        public void HashSetTest_clear()
        {
            var HashSet = new HashSet<object>();
            HashSet.Add(1);
            HashSet.Add("2");
            HashSet.Clear();
            object[] temp3 = { };
            Assert.IsTrue(Enumerable.SequenceEqual(HashSet, new HashSet<object>(temp3)));
        }
        [Test]
        public void HashSetTest_remove()
        {
            var HashSet = new HashSet<object>();
            HashSet.Add(1);
            HashSet.Add("2");
            HashSet.Remove(1);
            var temp2 = new HashSet<object>();
            temp2.Add("2");
            Assert.IsTrue(Enumerable.SequenceEqual(HashSet, temp2));
        }
        [Test]
        public void HashSetTest_contains()
        {
            var HashSet = new HashSet<object>();
            HashSet.Add(1);
            HashSet.Add("2");
            Assert.IsTrue(HashSet.Contains(1));
        }

        [Test]
        public void HashSetTest_Equals()
        {
            var HashSet = new HashSet<string>();
            HashSet.Add("1");
            HashSet.Add("2");
            var HashSet2 = HashSet;

            Assert.IsTrue(HashSet.Equals(HashSet2));
        }

    }
}