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
                root = root.Left;
            }
        }

        public int next()
        {
            var topSmallNode = _stack.Pop();
            if (topSmallNode.Right!=null)
            {
                InOrderLeftTreeNodes(topSmallNode.Right);
            }

            return topSmallNode.Val;
        }


        public bool hasNext()
        {
            return _stack.Count > 0;
        }


    }

    public class TreeNode
    {
        public int Val;

        public TreeNode Left;

        public TreeNode Right;

        public TreeNode(int x)
        {
            Val = x;
        }

    }
}
