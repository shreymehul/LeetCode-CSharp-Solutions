// 559. Maximum Depth of N-ary Tree
// Given a n-ary tree, find its maximum depth.
// The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
// Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).

// Example 1:
// Input: root = [1,null,3,2,4,null,5,6]
// Output: 3
// Example 2:
// Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
// Output: 5
 
// Constraints:
// The total number of nodes is in the range [0, 104].
// The depth of the n-ary tree is less than or equal to 1000.

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    //INTUITION: We can use DFS to solve this problem. We can keep track of the maximum depth of the tree by keeping track of the maximum depth of the children of the current node. We can then return the maximum depth of the children + 1 to get the maximum depth of the current node.
    //Time Complexity: O(n) where n is the number of nodes in the tree
    //Space Complexity: O(n) where n is the number of nodes in the tree
    public int MaxDepth(Node root) {
        return DFS(root);
    }
    public int DFS(Node root){
        if(root == null)
            return 0;
        int max = 0;
        foreach(var node in root.children){
            //We can keep track of the maximum depth of the children of the current node by using the DFS function recursively.
            max = Math.Max(max, DFS(node));
        }
        return max + 1;
    }
}