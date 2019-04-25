using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._13.BinarySearchTreeTests
{
    [TestFixture]
    class BinaryTreeTest
    {
        [Test]
        public void BinaryTreeTestInt()
        {
            BinaryTree<int> binarytree = new BinaryTree<int>();
            binarytree.Insert(30);
            binarytree.Insert(2);
            binarytree.Insert(3);
            binarytree.Insert(24);
            binarytree.Insert(12);
            binarytree.Insert(9);
            Assert.AreEqual(6, binarytree.NumOfElements);
            CollectionAssert.AreEqual(new int[] { 2, 3, 9, 12, 24, 30 }, binarytree.InOrder());
            CollectionAssert.AreEqual(new int[] { 30, 2, 3, 24, 12, 9 }, binarytree.PreOrder());
            CollectionAssert.AreEqual(new int[] { 9, 12, 24, 3, 2, 30 }, binarytree.PostOrder());
        }

        [Test]
        public void BinaryTreeTestIntComp()
        {
            BinaryTree<int> binarytree = new BinaryTree<int>(new Ints());
            binarytree.Insert(30);
            binarytree.Insert(2);
            binarytree.Insert(3);
            binarytree.Insert(24);
            binarytree.Insert(12);
            binarytree.Insert(9);
            Assert.AreEqual(6, binarytree.NumOfElements);
            CollectionAssert.AreEqual(new int[] { 2, 3, 9, 12, 24, 30 }, binarytree.InOrder());
            CollectionAssert.AreEqual(new int[] { 30, 2, 3, 24, 12, 9 }, binarytree.PreOrder());
            CollectionAssert.AreEqual(new int[] { 9, 12, 24, 3, 2, 30 }, binarytree.PostOrder());
        }

        [Test]
        public void BinaryTreeTestString()
        {
            BinaryTree<string> binarytree = new BinaryTree<string>();
            binarytree.Insert("dd");
            binarytree.Insert("bbb");
            binarytree.Insert("aaaa");
            binarytree.Insert("ddd");
            binarytree.Insert("b");
            binarytree.Insert("aa");
            Assert.AreEqual(6, binarytree.NumOfElements);
            CollectionAssert.AreEqual(new string[] { "aa", "aaaa", "b", "bbb", "dd", "ddd" }, binarytree.InOrder());
            CollectionAssert.AreEqual(new string[] { "dd", "bbb", "aaaa", "aa", "b" , "ddd"}, binarytree.PreOrder());
            CollectionAssert.AreEqual(new string[] { "aa", "b", "aaaa", "bbb", "ddd", "dd" }, binarytree.PostOrder());
        }


        [Test]
        public void BinaryTreeTestStringComp()
        {
            BinaryTree<string> binarytree = new BinaryTree<string>(new Strings());
            binarytree.Insert("dd");
            binarytree.Insert("bbb");
            binarytree.Insert("aaaa");
            binarytree.Insert("ddd");
            Assert.AreEqual(4, binarytree.NumOfElements);
            CollectionAssert.AreEqual(new string[] { "dd", "bbb", "ddd", "aaaa" }, binarytree.InOrder());
            CollectionAssert.AreEqual(new string[] { "dd", "bbb", "aaaa", "ddd" }, binarytree.PreOrder());
            CollectionAssert.AreEqual(new string[] { "ddd", "aaaa", "bbb", "dd" }, binarytree.PostOrder());
        }

        [Test]
        public void BinaryTreeTestBook()
        {
            BinaryTree<Book> binarytree = new BinaryTree<Book>();
            binarytree.Insert(new Book("Stivin King", "It", 500));
            binarytree.Insert(new Book("Stivin King", "Dark Tower", 253));
            binarytree.Insert(new Book("Albahari Joseph", "C# 7.0", 340));
            binarytree.Insert(new Book("Campbell john wood", "Something", 45));

            Assert.AreEqual(4, binarytree.NumOfElements);

            CollectionAssert.AreEqual(new[] {
                new Book("Campbell john wood", "Something", 45),
                new Book("Stivin King", "Dark Tower", 253),
                new Book("Albahari Joseph", "C# 7.0", 340),
                new Book("Stivin King", "It", 500),
            }, binarytree.InOrder());
        }
    }
}
