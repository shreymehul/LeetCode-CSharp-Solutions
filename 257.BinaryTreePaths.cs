// 257. Binary Tree Paths
// Given the root of a binary tree, return all root-to-leaf paths in any order.
// A leaf is a node with no children.
// Example 1:
// Input: root = [1,2,3,null,5]
// Output: ["1->2->5","1->3"]
// Example 2:
// Input: root = [1]
// Output: ["1"]

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
    public IList<string> BinaryTreePaths(TreeNode root) {
        IList<string> paths = new List<string>();
        if(root != null)
            Traverse(root,root.val.ToString(),paths);
        return paths;
    }
    public void Traverse(TreeNode root, string path, IList<string> paths){
        if(root.left == null && root.right == null){
            paths.Add(new string(path));
            return;
        }
        if(root.left != null)
            Traverse(root.left,path + "->" + root.left.val,paths);
        if(root.right != null)
            Traverse(root.right,path + "->" + root.right.val,paths);
    }
}