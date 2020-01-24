using System;
using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class BSTIterator_Tests
    {
        private TreeNode BsTree;

        public BSTIterator_Tests()
        {
            //¹¹Ôì¶þ²æÊ÷
            var root = new TreeNode(6);
            var node1 = new TreeNode(4);
            var node2 = new TreeNode(5);
            var node3 = new TreeNode(2);

            var node4 = new TreeNode(7);
            var node5 = new TreeNode(8);
            var node6 = new TreeNode(11);

            /*
             *          6
             *        /  \
             *      4     8
             *     / \   / \
             *    2   5  7  11
             */

            root.Left = node1;
            node1.Left = node3;
            node1.Right = node2;

            root.Right = node5;
            node5.Left = node4;
            node5.Right = node6;


            BsTree = root;

        }

        [Fact]
        public void BSTIterator_Test()
        {
            var iterator = new BSTIterator(BsTree);

            if (iterator.hasNext())
            {
               var a= iterator.next();

               Assert.Equal(2,a);

               var b = iterator.next();

               Assert.Equal(4,b);

               var c = iterator.next();

               Assert.Equal(5,c);

               var hasNext = iterator.hasNext();

               Assert.True(hasNext);
            }
        }
    }
}
