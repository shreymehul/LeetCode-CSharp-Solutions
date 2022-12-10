// 1026. Maximum Difference Between Node and Ancestor
// Given the root of a binary tree, find the maximum value v for which there exist different nodes a and b where v = |a.val - b.val| and a is an ancestor of b.
// A node a is an ancestor of b if either: any child of a is equal to b or any child of a is an ancestor of b.

// Example 1:
// Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
// Output: 7
// Explanation: We have various ancestor-node differences, some of which are given below :
// |8 - 3| = 5
// |3 - 7| = 4
// |8 - 1| = 7
// |10 - 13| = 3
// Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.
// Example 2:
// Input: root = [1,null,2,null,0,3]
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
    public int MaxAncestorDiff(TreeNode root) {
        return MaxDiff(root, root.val, root.val);
    }
    public int MaxDiff(TreeNode root, int max, int min){
        if(root == null)
            return 0;
        int res = Math.Max(
            Math.Abs(max-root.val),
            Math.Abs(min-root.val));
        max = Math.Max(max, root.val);
        min = Math.Min(min, root.val);
        return Math.Max( res,
                Math.Max(MaxDiff(root.left, max, min),
                    MaxDiff(root.right, max, min)));
    }

}   