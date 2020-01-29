namespace LeetCodeSolution
{
    /*
     *Given a binary tree, return the sum of values of nodes with even-valued grandparent. 
     * (A grandparent of a node is the parent of its parent, if it exists.)

        If there are no nodes with an even-valued grandparent, return 0.

         

        Example 1:



        Input: root = [6,7,8,2,7,1,3,9,null,1,4,null,null,null,5]
        Output: 18
        Explanation: The red nodes are the nodes with even-value grandparent while the blue nodes are the even-value grandparents.
         

        Constraints:

        The number of nodes in the tree is between 1 and 10^4.
        The value of nodes is between 1 and 100.

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/sum-of-nodes-with-even-valued-grandparent
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
     *
     *
     */
    public class Solution1315
    {
        private int _sum = 0;

        public int SumEvenGrandparent(TreeNode root)
        { 
            dfs(root, null);

            return _sum;
        }

        private void dfs(TreeNode node, TreeNode parent)
        {
            if (node == null)
            {
                return ;
            }

            if (parent != null && parent.val % 2 == 0)
            {
                if (node.left!=null)
                {
                    _sum += node.left.val;
                }

                if (node.right!=null)
                {
                    _sum += node.right.val;
                }
            }

            dfs(node.left, node);

            dfs(node.right, node);

        }
    }
}