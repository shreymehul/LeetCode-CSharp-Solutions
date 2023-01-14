// 144. Binary Tree Preorder Traversal
// Given the root of a binary tree, return the preorder traversal of its nodes' values.
// Example 1:
// Input: root = [1,null,2,3]
// Output: [1,2,3]
// Example 2:
// Input: root = []
// Output: []
// Example 3:
// Input: root = [1]
// Output: [1]

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
    public IList<int> PreorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        if(root != null)
            Preorder(root, result);
        return result;
    }
    public void Preorder(TreeNode root, IList<int> result){
        result.Add(root.val);
        if(root.left != null)
            Preorder(root.left, result);
        if(root.right != null)
            Preorder(root.right, result);
    }
}


public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        IList<int> res = new List<int>();
        Preorder(root, res);
        return res;
    }
    public void Preorder(TreeNode root, IList<int> res){
        if(root == null)
            return;
        res.Add(root.val);
        Preorder(root.left, res);
        Preorder(root.right, res);
    }
}