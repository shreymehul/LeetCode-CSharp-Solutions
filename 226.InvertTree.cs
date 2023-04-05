// 226. Invert Binary Tree

// Given the root of a binary tree, invert the tree, and return its root.

// Example 1:
// Input: root = [4,2,7,1,3,6,9]
// Output: [4,7,2,9,6,3,1]
// Example 2:
// Input: root = [2,1,3]
// Output: [2,3,1]
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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null)
            return root;
        
        InvertTree(root.left);
        InvertTree(root.right);
        TreeNode Tempnode = root.left;
        root.left = root.right;
        root.right = Tempnode;
        return root;
    }
}