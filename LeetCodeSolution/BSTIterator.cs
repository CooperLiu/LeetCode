using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolution
{
    /*
     *           6
     *         /  \
     *        4    8
     *       / \   / \
     *      2  5  7  11
     *  设计思路
     *  - 使用根节点6初始化迭代器，中序遍历，依次压入到栈内。
     *  - hasNext() = Stack.Count>1
     *  - next() = Stack.Pop()，输入搜索树中的最小值。
     *
     *  二叉树特性
     *  1. 左侧节点一定小于父节点
     *  2. 右侧节点一定大于父节点
     *
     *  实现思路：利用二叉树的中序遍历
     *  - 使用Stack保存遍历路径的先后顺序节点。
     *  - hasNext() ，即Stack.Count >1 
     *  - next() 首先从根节点开始，向左侧节点遍历，直到叶子节点，即Stack弹出当前整个树的最小值。
     *   [2] -> 树的最小值
     *   [4]
     *   [6]
     *  - next()，最小节点有没有兄弟节点，有则将兄弟节点作为根节点循环遍历左侧节点，输出最小值
     */


    /// <summary>
    /// 173.二叉搜索树迭代器
    /// </summary>
    public class BSTIterator
    {
        private Stack<TreeNode> _stack;

        /// <summary>
        /// Initial iterator using root tree root.
        /// </summary>
        /// <param name="root"></param>
        public BSTIterator(TreeNode root)
        {
            _stack = new Stack<TreeNode>();
            this.InOrderLeftTreeNodes(root);
        }

        private void InOrderLeftTreeNodes(TreeNode root)
        {
            while (root != null)
            {
                _stack.Push(root);
                root = root.left;
            }
        }

        public int next()
        {
            var topSmallNode = _stack.Pop();
            if (topSmallNode.right != null)
            {
                InOrderLeftTreeNodes(topSmallNode.right);
            }

            return topSmallNode.val;
        }


        public bool hasNext()
        {
            return _stack.Count > 0;
        }


    }

    public class TreeNode
    {
        public int val;

        public TreeNode left;

        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }

    }

    public class TreeGoThrough
    {
        /// <summary>
        /// 前序遍历：左-根-右
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int[] Pre(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            var list = new List<int>();

            if (node.left != null)
            {
                var left = Pre(node.left);

                list.AddRange(left);
            }

            list.Add(node.val);

            if (node.right != null)
            {
                var right = Pre(node.right);

                list.AddRange(right);
            }

            return list.ToArray();
        }

        /// <summary>
        /// 中序遍历： 根-左-右
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int[] Mid(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            var list = new List<int>();

            list.Add(node.val);

            if (node.left != null)
            {
                var left = Mid(node.left);

                list.AddRange(left);
            }


            if (node.right != null)
            {
                var right = Mid(node.right);

                list.AddRange(right);
            }

            return list.ToArray();
        }

        /// <summary>
        /// 后续遍历：右-根-左
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int[] End(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            var list = new List<int>();


            if (node.right != null)
            {
                var right = End(node.right);

                list.AddRange(right);
            }


            list.Add(node.val);

            if (node.left != null)
            {
                var left = End(node.left);

                list.AddRange(left);
            }


            return list.ToArray();
        }

        /// <summary>
        /// 层次遍历（广度遍历）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int[] Level(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(node);

            var list = new List<int>();

            while (queue.Count > 0)
            {
                var t = queue.Dequeue();
                list.Add(t.val);

                if (t.left != null)
                {
                    queue.Enqueue(t.left);
                }

                if (t.right != null)
                {
                    queue.Enqueue(t.right);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 二叉树高度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = GetHeight(node.left);

            int right = GetHeight(node.right);

            return left > right ? left + 1 : right + 1;
        }

        /// <summary>
        /// 二叉树节点个数
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetNodeCount(TreeNode node)
        {
            if (node == null) return 0;

            return GetNodeCount(node.left) + GetNodeCount(node.right) + 1;
        }

        /// <summary>
        /// 二叉树节点是否存在val值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool ValExists(TreeNode node, int val)
        {
            if (node==null)
            {
                return false;
            }

            if (node.val == val)
            {
                return true;
            }

            return ValExists(node.left, val) && ValExists(node.right, val);
        }

        /// <summary>
        /// 比较二叉树是否相同
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public bool IsSame(TreeNode node1, TreeNode node2)
        {
            if (node1==null && node2 == null)
            {
                return true;
            }

            return node1.left != null && node2.left != null && IsSame(node1.left, node2.left)
                && node1.right != null && node2.right != null && IsSame(node1.right, node2.right);
        }

        /// <summary>
        /// 交换左右树
        /// </summary>
        /// <param name="node"></param>
        public void Exchange(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            if (node.right != null && node.left != null)
            {
                var temp = node.left;

                node.left = node.right;

                node.right = temp;
            }

            Exchange(node.right);
            Exchange(node.left);

        }


    }
}
