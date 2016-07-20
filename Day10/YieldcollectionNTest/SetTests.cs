using System;
using NUnit.Framework;
using YieldCollection;
using System.Diagnostics;
using System.Linq;

namespace YieldcollectionNTest
{
    [TestFixture]
    public class SetTests
    {

        [Test]
        public void SetTest_Except()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "1" };
            Set<string> set = new Set<string>(s1);
            Set<string> set2 = new Set<string>(s2);
            Set<string> set3 = new Set<string>(s3);
            set.ExceptWith(set2);
            Assert.IsTrue(Enumerable.SequenceEqual(set,set3));
        }


        [Test]
        public void SetTest_Union()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "1", "2", "3", "4", "5" };
            Set<string> set = new Set<string>(s1);
            Set<string> set2 = new Set<string>(s2);
            Set<string> set3 = new Set<string>(s3);
            set.UnionWith(set2);
            Assert.IsTrue(Enumerable.SequenceEqual(set, set3));
        }
        [Test]
        public void SetTest_Intersect()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "2","3","4" };
            Set<string> set = new Set<string>(s1);
            Set<string> set2 = new Set<string>(s2);
            Set<string> set3 = new Set<string>(s3);
            set.IntersectWith(set2);
            Assert.IsTrue(Enumerable.SequenceEqual(set, set3));
        }
        [Test]
        public void SetTest_SymmetricExcept()
        {
            string[] s1 = { "1", "2", "3", "4" };
            string[] s2 = { "2", "3", "4", "5" };
            string[] s3 = { "1","5" };
            Set<string> set = new Set<string>(s1);
            Set<string> set2 = new Set<string>(s2);
            Set<string> set3 = new Set<string>(s3);
            set.SymmetricExceptWith(set2);
            Assert.IsTrue(Enumerable.SequenceEqual(set, set3));
        }
        [Test]
        public void SetTest_Add()
        {
            var set = new Set<object>();
            set.Add(1);
            set.Add("2");
            object[] temp = { 1, "2" };
            Assert.IsTrue(Enumerable.SequenceEqual(set, new Set<object>(temp)));
        }
        [Test]
        public void SetTest_clear()
        {
            var set = new Set<object>();
            set.Add(1);
            set.Add("2");
            set.Clear();
            object[] temp3 = { };
            Assert.IsTrue(Enumerable.SequenceEqual(set, new Set<object>(temp3)));
        }
        [Test]
        public void SetTest_remove()
        {
            var set = new Set<object>();
            set.Add(1);
            set.Add("2");
            set.Remove(1);
            object[] temp2 = { "2" };
            Assert.IsTrue(Enumerable.SequenceEqual(set, new Set<object>(temp2)));
        }
        [Test]
        public void SetTest_contains()
        {
            var set = new Set<object>();
            set.Add(1);
            set.Add("2");
            Assert.IsTrue(set.Contains(1));
        }

    }
}