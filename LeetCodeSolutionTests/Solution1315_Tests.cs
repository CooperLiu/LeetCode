using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution1315_Tests
    {
        private readonly TreeNode BsTree;

        public Solution1315_Tests()
        {
            //构造二叉树
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
        public void SumEvenGrandparent_Test()
        {
            var solution= new Solution1315();

            var result = solution.SumEvenGrandparent(BsTree);

            Assert.Equal(25,result);
        }
    }
}