// 1339. Maximum Product of Splitted Binary Tree\
// Given the root of a binary tree, split the binary tree into two subtrees by removing one edge such that the product of the sums of the subtrees is maximized.
// Return the maximum product of the sums of the two subtrees. Since the answer may be too large, return it modulo 109 + 7.
// Note that you need to maximize the answer before taking the mod and not after taking it.
// Example 1:
// Input: root = [1,2,3,4,5,6]
// Output: 110
// Explanation: Remove the red edge and get 2 binary trees with sum 11 and 10. Their product is 110 (11*10)
// Example 2:
// Input: root = [1,null,2,3,4,null,null,5,6]
// Output: 90
// Explanation: Remove the red edge and get 2 binary trees with sum 15 and 6.Their product is 90 (15*6)

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
    long max = Int64.MinValue;
    long tSum;
    public int MaxProduct(TreeNode root) {
        if(root == null)
            return 0;
        tSum = TotalSum(root);
        SplitTree(root);
        int res = (int)(max % 1000000007);
        return res;
    }
    public long TotalSum(TreeNode root){
        long lSum = 0, rSum = 0;
        if(root.left != null)
            lSum = TotalSum(root.left);
        if(root.right != null)
            rSum = TotalSum(root.right);
        return lSum + rSum + root.val;
    }
    public long SplitTree(TreeNode root){
        long lSum = 0, rSum = 0;
        if(root.left != null)
            lSum = SplitTree(root.left);
        if(root.right != null)
            rSum = SplitTree(root.right);
        long sum = lSum + rSum + root.val;
        max = Math.Max(max,
                        sum*(tSum-sum));
        return sum;
    }
}