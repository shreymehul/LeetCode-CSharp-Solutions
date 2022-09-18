// 107. Binary Tree Level Order Traversal II

// Given the root of a binary tree, return the bottom-up level order traversal of its nodes' values. (i.e., from left to right, level by level from leaf to root).

 

// Example 1:


// Input: root = [3,9,20,null,null,15,7]
// Output: [[15,7],[9,20],[3]]
// Example 2:

// Input: root = [1]
// Output: [[1]]
// Example 3:

// Input: root = []
// Output: []

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null)
        {
        return res;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) 
        {
            IList<int> level = new List<int>();
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode currNode = queue.Dequeue();
                level.Add(currNode.val);
                if (currNode.left != null)
                    queue.Enqueue(currNode.left);
                if (currNode.right != null)
                    queue.Enqueue(currNode.right);
            }
            res.Add(level);
        }
        IList<IList<int>> finalres = new List<IList<int>>();
        for(int i = res.Count-1; i >=0; i--)
        {
            finalres.Add(res[i]);
        }
        return finalres;
    }
}