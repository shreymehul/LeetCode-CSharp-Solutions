// 108. Convert Sorted Array to Binary Search Tree
// Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced
// binary search tree.

// Example 1:
// Input: nums = [-10,-3,0,5,9]
// Output: [0,-3,9,-10,null,5]
// Explanation: [0,-10,5,null,-3,null,9] is also accepted:
// Example 2:
// Input: nums = [1,3]
// Output: [3,1]
// Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.

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
    public TreeNode SortedArrayToBST(int[] nums) {
        if(nums.Length == 0)
            return null;
        if(nums.Length == 1)
            return new TreeNode(nums[0]);
        return ArrayToBST(nums, 0, nums.Length-1);
    }
    public TreeNode ArrayToBST(int[] nums, int left, int right){
        if(right < left || left < 0 || right >= nums.Length)
            return null;
        if(left == right)
            return new TreeNode(nums[left]);
        int mid = (right-left)/2 + left;
        TreeNode root = new TreeNode(nums[mid]);
        root.left = ArrayToBST(nums , left , mid-1);
        root.right = ArrayToBST(nums , mid+1 , right);
        return root;
    }
}