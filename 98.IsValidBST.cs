// 98. Validate Binary Search Tree
// Given the root of a binary tree, determine if it is a valid binary search tree (BST).

// A valid BST is defined as follows:

// The left subtree of a node contains only nodes with keys less than the node's key.
// The right subtree of a node contains only nodes with keys greater than the node's key.
// Both the left and right subtrees must also be binary search trees.
 
// Example 1:
// Input: root = [2,1,3]
// Output: true
// Example 2:
// Input: root = [5,1,4,null,null,3,6]
// Output: false
// Explanation: The root node's value is 5 but its right child's value is 4.

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
    public bool IsValidBST(TreeNode root) {
        return CheckBST(root, Int64.MinValue, Int64.MaxValue);
    }
    public  bool CheckBST(TreeNode root, long min, long max)
    {
        if (root == null)
            return true;
        if (root.val >= max)
            return false;
        if (root.val <= min)
            return false;
        return CheckBST(root.left, min, root.val) 
            && CheckBST(root.right, root.val, max);
    }
}

public class Solution {
    
    public bool IsValidBST(TreeNode root) {
        return IsValidBST(root, Int64.MinValue, Int64.MaxValue);
    }
    //Current node should be in the range of min and max. 
    //Where current root will be the max for left subtree and min for right subtree
    public bool IsValidBST(TreeNode root, long min, long max){
        if(root == null)
            return true;
        if(root.val >= max || root.val <= min)
            return false;
        return IsValidBST(root.left, min, root.val) &&
            IsValidBST(root.right, root.val, max);
    }
}