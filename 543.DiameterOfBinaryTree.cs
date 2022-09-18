// 543. Diameter of Binary Tree

// Given the root of a binary tree, return the length of the diameter of the tree.

// The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

// The length of a path between two nodes is represented by the number of edges between them.

 

// Example 1:


// Input: root = [1,2,3,4,5]
// Output: 3
// Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].
// Example 2:

// Input: root = [1,2]
// Output: 1

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
    int max;
    public int DiameterOfBinaryTree(TreeNode root) {
        max = 0;
        MaxDepth(root);
        return max;
    }
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;
        int leftHeight = MaxDepth(root.left);
        int rightHeight = MaxDepth(root.right);
        max = Math.Max(max,leftHeight+rightHeight );
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}