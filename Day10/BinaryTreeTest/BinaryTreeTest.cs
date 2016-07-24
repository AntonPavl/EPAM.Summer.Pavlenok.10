using System;
using NUnit.Framework;
using Tree;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeTest
{
    [TestFixture]
    public class BinaryTreeTest
    {
        [Test]
        public void Max_Min_Value()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                bt.Add(i);
            }
            Assert.AreEqual(0, bt.MinValue);
            Assert.AreEqual(19, bt.MaxValue);
        }

        [Test]
        public void PreOrder()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                bt.Add(i);
            }
            int test = 0;
            foreach (var item in bt.Preorder())
            {
                Assert.AreEqual(test, item);
                test++;
            }
        }
        [Test]
        public void PostOrder()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                bt.Add(i);
            }
            int test = 4;
            foreach (var item in bt.Postorder())
            {
                Assert.AreEqual(test, item);
                test--;
            }
        }

        [Test]
        public void InOrder()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                bt.Add(i);
            }
            int test = 0;
            foreach (var item in bt.Inorder())
            {
                Assert.AreEqual(test, item);
                test++;
            }
        }



        private class LeftcomparatorInt : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
        [Test]
        public void AllLeftTreeInt()
        {
            BinaryTree<int> bt = new BinaryTree<int>(new LeftcomparatorInt());
            Random rand = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                int value = rand.Next(100);
                bt.Add(value);
                list.Add(value);
            }
            list.Sort(new LeftcomparatorInt());
            CollectionAssert.AreEqual(bt.Inorder(), list);
        }



        private class LeftcomparatorString : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return y.CompareTo(x);
            }
        }

        [Test]
        public void AllLeftTreeString()
        {
            BinaryTree<string> bt = new BinaryTree<string>(new LeftcomparatorString());
            Random rand = new Random();
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                string value = rand.Next(100).ToString();
                bt.Add(value);
                list.Add(value);
            }
            list.Sort(new LeftcomparatorString());
            CollectionAssert.AreEqual(bt.Inorder(), list);
        }


        public struct Point
        {
            public int x;
            public int y;
            public Point(int x,int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        private class LeftcomparatorPoint : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return (y.x + y.y).CompareTo(x.x + x.y);
            }
        }


        [Test]
        public void AllLeftTreePoint()
        {
            BinaryTree<Point> bt = new BinaryTree<Point>(new LeftcomparatorPoint());
            Random rand = new Random();
            List<Point> list = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                int value = rand.Next(100);
                int value2 = rand.Next(100);
                Point p = new Point(value, value2);
                bt.Add(p);
                list.Add(p);
            }
            list.Sort(new LeftcomparatorPoint());
            CollectionAssert.AreEqual(bt.Inorder(), list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TreePoint()
        {
            BinaryTree<Point> bt = new BinaryTree<Point>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int value = rand.Next(100);
                int value2 = rand.Next(100);
                Point p = new Point(value, value2);
                bt.Add(p);
            }
            foreach (var item in bt.Inorder())
            {
                Debug.WriteLine(item);
            }
        }
    }
}