// 114. Flatten Binary Tree to Linked List
// Given the root of a binary tree, flatten the tree into a "linked list":
// The "linked list" should use the same TreeNode class where the right child pointer points to the next node in the list and the left child pointer is always null.
// The "linked list" should be in the same order as a pre-order traversal of the binary tree.

// Example 1:
// Input: root = [1,2,5,3,4,null,6]
// Output: [1,null,2,null,3,null,4,null,5,null,6]
// Example 2:
// Input: root = []
// Output: []
// Example 3:
// Input: root = [0]
// Output: [0]

// Constraints:
// The number of nodes in the tree is in the range [0, 2000].
// -100 <= Node.val <= 100

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
    public void Flatten(TreeNode root) {
        if(root == null)
            return;
        FlattenAndGetEndNode(root);
    }
    public TreeNode FlattenAndGetEndNode(TreeNode root) {
        var leftEnd = root.left == null ?
                        root : FlattenAndGetEndNode(root.left);
        var rightEnd = root.right == null ?
                        leftEnd : FlattenAndGetEndNode(root.right);
        leftEnd.right = root.right;
        if(root.left != null)
            root.right = root.left;
        root.left = null;
        return rightEnd;
    }

}