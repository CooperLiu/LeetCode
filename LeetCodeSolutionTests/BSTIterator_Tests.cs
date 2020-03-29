using System;
using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class BSTIterator_Tests
    {
        private readonly TreeNode BsTree;

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

            root.left = node1;
            node1.left = node3;
            node1.right = node2;

            root.right = node5;
            node5.left = node4;
            node5.right = node6;


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

        [Fact]
        public void Level_Test()
        {
            var path = new TreeGoThrough();


            var levelResult = path.Level(BsTree);

            Assert.Equal(11, levelResult[levelResult.Length - 1]);

        }


        [Fact]
        public void Pre_Test()
        {
            var path = new TreeGoThrough();


            var levelResult = path.Pre(BsTree);

            Assert.Equal(2, levelResult[0]);

        }


        [Fact]
        public void Mid_Test()
        {
            var path = new TreeGoThrough();


            var levelResult = path.Mid(BsTree);

            Assert.Equal(6, levelResult[0]);

        }

        [Fact]
        public void End_Test()
        {
            var path = new TreeGoThrough();


            var levelResult = path.End(BsTree);

            Assert.Equal(11, levelResult[0]);

        }

        [Fact]
        public void Exchange_Test()
        {
            var path = new TreeGoThrough();

            path.Exchange(BsTree);

            var result = path.Pre(BsTree);


            Assert.Equal(11, result[0]);
        }
    }
}
