// 61. Rotate List
// Given the head of a linked list, rotate the list to the right by k places.
// Example 1:
// Input: head = [1,2,3,4,5], k = 2
// Output: [4,5,1,2,3]
// Example 2:
// Input: head = [0,1,2], k = 4
// Output: [2,0,1]

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
    public ListNode RotateRight(ListNode head, int k) {
        if(head == null || head.next == null)
            return head;
        ListNode curr = head;
        ListNode prev = null;
        int length=0;
        while(curr!=null){
            length++;
            prev = curr;
            curr = curr.next;
        }
        prev.next = head;
        k = k%length;
        length = length - k;
        curr = head;
        while(length > 0){
            prev = curr;
            curr = curr.next;
            length--;
        }
        prev.next = null;
        return curr;
    }
}