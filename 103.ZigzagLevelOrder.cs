// 103. Binary Tree Zigzag Level Order Traversal
// Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).

 

// Example 1:


// Input: root = [3,9,20,null,null,15,7]
// Output: [[3],[20,9],[15,7]]
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null)
            return result;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int level = 0;
        while (q.Count > 0)
        {
            int size = q.Count;
            List<int> valLevel = new List<int>();
            for(int i=0; i< size; i++)
            {
                TreeNode top = q.Dequeue();
                valLevel.Add(top.val);
                if(top.left!=null)
                    q.Enqueue(top.left);
                if(top.right!=null)
                    q.Enqueue(top.right);
            }
            if (level % 2 == 0)
            {
                result.Add(valLevel);
            }
            else
            {
                List<int> reverseLevelValue = new List<int>();
                for(int i = valLevel.Count -1; i >= 0; i--)
                {
                    reverseLevelValue.Add(valLevel[i]);
                }
                result.Add(reverseLevelValue);
            }
            level++;
        }
        return result;
    }
}