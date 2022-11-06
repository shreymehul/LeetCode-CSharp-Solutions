// 234. Palindrome Linked List

// Given the head of a singly linked list, return true if it is a palindrome or false otherwise.
// Example 1:
// Input: head = [1,2,2,1]
// Output: true
// Example 2:
// Input: head = [1,2]
// Output: false

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
public class Solution {
    public bool IsPalindrome(ListNode head) {
        Stack<int> stack = new Stack<int>();
        ListNode curr = head;
        while(curr != null){
            stack.Push(curr.val);
            curr = curr.next;
        }
        curr = head;
        int mid = stack.Count/2;
        while(mid < stack.Count){
            if(stack.Pop() != curr.val)
                return false;
            curr = curr.next;
        }
        return true;
    }
}