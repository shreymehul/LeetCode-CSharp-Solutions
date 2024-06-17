// 2096. Step-By-Step Directions From a Binary Tree Node to Another
// You are given the root of a binary tree with n nodes. Each node is uniquely assigned a value from 1 to n. You are also given an integer startValue representing the value of the start node s, and a different integer destValue representing the value of the destination node t.
// Find the shortest path starting from node s and ending at node t. Generate step-by-step directions of such path as a string consisting of only the uppercase letters 'L', 'R', and 'U'. Each letter indicates a specific direction:
// 'L' means to go from a node to its left child node.
// 'R' means to go from a node to its right child node.
// 'U' means to go from a node to its parent node.
// Return the step-by-step directions of the shortest path from node s to node t.

// Example 1:
// Input: root = [5,1,2,3,null,6,4], startValue = 3, destValue = 6
// Output: "UURL"
// Explanation: The shortest path is: 3 → 1 → 5 → 2 → 6.
// Example 2:
// Input: root = [2,1], startValue = 2, destValue = 1
// Output: "L"
// Explanation: The shortest path is: 2 → 1.

// Constraints:
// The number of nodes in the tree is n.
// 2 <= n <= 105
// 1 <= Node.val <= n
// All the values in the tree are unique.
// 1 <= startValue, destValue <= n
// startValue != destValue

using System;
using System.Collections.Generic;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        var pathToStart = new List<string>();
        var pathToDest = new List<string>();

        if (FindPath(root, startValue, pathToStart) && FindPath(root, destValue, pathToDest)) {
            // Remove common common path
            int i = 0;
            while (i < pathToStart.Count && i < pathToDest.Count && pathToStart[i] == pathToDest[i]) {
                i++;
            }

            // Directions to move up to the common ancestor
            // Create a string of length pathToStart - 1 with "U" character
            string upMoves = new string('U', pathToStart.Count - i);

            // Directions from the common ancestor to the destination
            string downMoves = string.Join("", pathToDest.GetRange(i, pathToDest.Count - i));

            return upMoves + downMoves;
        }

        return "";
    }

    private bool FindPath(TreeNode root, int value, List<string> path) {
        if (root == null) return false;
        if (root.val == value) return true;

        //Find in Left Subtree
        path.Add("L");
        if (FindPath(root.left, value, path)) return true;
        path.RemoveAt(path.Count - 1); //Backtrack if not found

        //Find in Right Subtree
        path.Add("R");
        if (FindPath(root.right, value, path)) return true;
        path.RemoveAt(path.Count - 1); //Backtrack if not found

        return false;
    }
}


// TreeNode Class:
// Defines the structure of a tree node with a value (val), a left child (left), and a right child (right).

// GetDirections Method:
// Initializes two lists to store the path from the root to startValue and destValue.
// Uses a helper method FindPath to find paths to startValue and destValue.
// Identifies the common ancestor by comparing the paths.
// Constructs the final direction string by combining upward moves ("U") and downward moves ("L" or "R").

// FindPath Method:
// Recursively searches for the target value (value) in the tree.
// Records the path by appending "L" for left and "R" for right moves.
// Removes the last move if the path does not lead to the target, ensuring the path list is accurate.
// This implementation ensures the correct directions are returned to move from the node with startValue to the node with destValue.





