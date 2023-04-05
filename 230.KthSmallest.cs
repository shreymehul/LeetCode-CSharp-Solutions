// 230. Kth Smallest Element in a BST
// Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the
// values of the nodes in the tree.
// Example 1:
// Input: root = [3,1,4,null,2], k = 1
// Output: 1
// Example 2:
// Input: root = [5,3,6,2,4,null,null,1], k = 3
// Output: 3
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
    Stack<int> st;
    public int KthSmallest(TreeNode root, int k) {
        st = new Stack<int>();
        findsmallest(root,k);
        return st.Pop();
    }
    public void findsmallest(TreeNode root, int k){
        if(root == null)
            return;
        if(st.Count < k)
            findsmallest(root.left,k);
        if(st.Count < k)
            st.Push(root.val);
        if(st.Count < k)
            findsmallest(root.right,k);
    }
}