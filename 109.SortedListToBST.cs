// 109. Convert Sorted List to Binary Search Tree

// Given the head of a singly linked list where elements are sorted in ascending order, convert it to a height-balanced binary search tree.
// Example 1:
// Input: head = [-10,-3,0,5,9]
// Output: [0,-3,9,-10,null,5]
// Explanation: One possible answer is [0,-3,9,-10,null,5], which represents the shown height balanced BST.
// Example 2:
// Input: head = []
// Output: []

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    public TreeNode SortedListToBST(ListNode head) {
        if(head == null)
            return null;
        if(head.next == null)
            return new TreeNode(head.val);
        ListNode mid = FindMid(head);
        TreeNode root = new TreeNode(mid.val);
        root.left = SortedListToBST(head);
        root.right = SortedListToBST(mid.next);
        return root;
    }
    public ListNode FindMid(ListNode head){
        ListNode slow = head,
                fast = head,
                prev = null;
        while(fast != null && fast.next != null){
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        prev.next = null;
        return slow;
    }
}