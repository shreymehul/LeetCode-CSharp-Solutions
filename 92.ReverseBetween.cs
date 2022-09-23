// 92. Reverse Linked List II

// Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.

 

// Example 1:


// Input: head = [1,2,3,4,5], left = 2, right = 4
// Output: [1,4,3,2,5]
// Example 2:

// Input: head = [5], left = 1, right = 1
// Output: [5]

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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if (head == null || head.next == null || left == right)
            return head;
        
        ListNode reverseEnd, prevReverseHead;
        reverseEnd = head;
        prevReverseHead = null;
        int pos = 1;

        while (pos != left)
        {
            prevReverseHead = reverseEnd;
            reverseEnd = reverseEnd.next;
            pos++;
        }

        ListNode curr,prev;
        prev = null;
        curr = reverseEnd;
        while (pos <= right)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
            pos++;
        }
        if (prevReverseHead != null)
        {
            prevReverseHead.next = prev;
        }
        else
        {
            head = prev;
        }
        reverseEnd.next = curr;
        
        return head;
    }
}