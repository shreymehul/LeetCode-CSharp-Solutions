// 110. Balanced Binary Tree

// Given a binary tree, determine if it is height-balanced.
// For this problem, a height-balanced binary tree is defined as:
// a binary tree in which the left and right subtrees of every node differ in height by no more than 1.
// Example 1:
// Input: root = [3,9,20,null,null,15,7]
// Output: true
// Example 2:
// Input: root = [1,2,2,3,3,null,null,4,4]
// Output: false
// Example 3:
// Input: root = []
// Output: true

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
    bool isBalanced = true;
    public int Height(TreeNode root)
    {
        if (root == null)
            return 0;
        int leftHeight = Height(root.left);
        int rightHeight = Height(root.right);

        if (Math.Abs(leftHeight - rightHeight) > 1)
            isBalanced = false;
        return Math.Max(leftHeight, rightHeight) + 1;
    }
    public bool IsBalanced(TreeNode root) {
       if (root == null)
            return true;
        Height(root);
        return isBalanced; 
    }
}