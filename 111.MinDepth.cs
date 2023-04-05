// 111. Minimum Depth of Binary Tree
// Given a binary tree, find its minimum depth.
// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
// Note: A leaf is a node with no children.
// Example 1:
// Input: root = [3,9,20,null,null,15,7]
// Output: 2
// Example 2:
// Input: root = [2,null,3,null,4,null,5,null,6]
// Output: 5

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
    public int MinDepth(TreeNode root) {
        if (root == null)
            return 0;
        int leftHeight, rightHeight;
        leftHeight = rightHeight = 0;
        if (root.left != null)
        {
            leftHeight = MinDepth(root.left);
        }
        if (root.right != null)
        {
            rightHeight = MinDepth(root.right);
        }
        if(leftHeight == 0)
            return 1+rightHeight;
        else if(rightHeight == 0)
            return 1+ leftHeight;
        return 1 + Math.Min(leftHeight, rightHeight);
    }
}