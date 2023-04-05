// 113. Path Sum II
// Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values
// in the path equals targetSum. Each path should be returned as a list of the node values, not node references.
// A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.
// Example 1:
// Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
// Output: [[5,4,11,2],[5,8,4,5]]
// Explanation: There are two paths whose sum equals targetSum:
// 5 + 4 + 11 + 2 = 22
// 5 + 8 + 4 + 5 = 22
// Example 2:
// Input: root = [1,2,3], targetSum = 5
// Output: []
// Example 3:
// Input: root = [1,2], targetSum = 0
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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
         IList<IList<int>> result = new List<IList<int>>();
        if (root != null)
            PathSum(root, targetSum, new List<int>(), result);
        return result;
    }
    public void PathSum(TreeNode root, int targetSum, 
                        List<int> list, IList<IList<int>> result) {
        
        if (root.left == null && root.right == null && targetSum != root.val)
            return;
        list.Add(root.val);
        if (root.left == null && root.right == null && targetSum == root.val)
            result.Add(new List<int>(list));
        if (root.left != null)
            PathSum(root.left, targetSum - root.val, list, result);
        if (root.right != null)
            PathSum(root.right, targetSum - root.val, list, result);
        list.RemoveAt(list.Count - 1);
    }
}