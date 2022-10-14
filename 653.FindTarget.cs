// 653. Two Sum IV - Input is a BST

// Given the root of a Binary Search Tree and a target number k, return true if there exist two elements in the BST such that their sum is equal to the given target.

 

// Example 1:


// Input: root = [5,3,6,2,4,null,7], k = 9
// Output: true
// Example 2:


// Input: root = [5,3,6,2,4,null,7], k = 28
// Output: false

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
    public bool FindTarget(TreeNode root, int k) {
        return TravelAndFindTarget(root,root,k);
    }
    public bool TravelAndFindTarget(TreeNode root,TreeNode node, int k) {
        if(node==null)
            return false;
        bool result = false;
        if(TravelAndFindTarget(root,node.left,k))
            return true;
        int comp = k - node.val;
        if(comp>node.val && Find(root,node,comp))
            return true;
        if(TravelAndFindTarget(root,node.right,k))
            return true;
        return false;
    }
    public bool Find(TreeNode root,TreeNode node, int k) {
        if(root == null)
            return false;
        if(root != node && root.val == k)
            return true;
        if(root.val > k)
            return Find(root.left,node,k);
        return Find(root.right,node,k);
    }
}