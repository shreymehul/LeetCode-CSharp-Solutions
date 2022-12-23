// 687. Longest Univalue Path
// Given the root of a binary tree, return the length of the longest path, where each node in the path has the same value. This path may or may not pass through the root.
// The length of the path between two nodes is represented by the number of edges between them.
// Example 1:
// Input: root = [5,4,5,1,1,null,5]
// Output: 2
// Explanation: The shown image shows that the longest path of the same value (i.e. 5).
// Example 2:
// Input: root = [1,4,5,4,4,null,5]
// Output: 2
// Explanation: The shown image shows that the longest path of the same value (i.e. 4).
// Constraints:
// The number of nodes in the tree is in the range [0, 104].
// -1000 <= Node.val <= 1000
// The depth of the tree will not exceed 1000.

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
    public int LongestUnivaluePath(TreeNode root) {
        if(root == null)
            return 0;
        max = 0;
        Traverse(root);
        return max - 1;
    }
    public int Traverse(TreeNode root){
        if(root == null)
            return 0;
        int left = Traverse(root.left);
        int right = Traverse(root.right);

        int count = 1;
        if(root.left != null && root.left.val == root.val)
            count += left; 
        if(root.right != null && root.right.val == root.val)
            count += right; 
            max = Math.Max(max, count);

        if(root.left != null && root.left.val == root.val &&
            root.right != null && root.right.val == root.val)
                return Math.Max(left + 1, right + 1);
        else if(root.left != null && root.left.val == root.val)
                return left + 1; 
        else if(root.right != null && root.right.val == root.val)
                return right + 1; 
        else
            return 1;
    }
}