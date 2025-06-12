// 24. Swap Nodes in Pairs
// Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

// Example 1:
// Input: head = [1,2,3,4]
// Output: [2,1,4,3]
// Explanation:

// Example 2:
// Input: head = []
// Output: []

// Example 3:
// Input: head = [1]
// Output: [1]

// Example 4:
// Input: head = [1,2,3]
// Output: [2,1,3]

// Constraints:
// The number of nodes in the list is in the range [0, 100].
// 0 <= Node.val <= 100

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
public class Solution
{
    //intuio
    public ListNode SwapPairs(ListNode head)
    {
        ListNode prev, curr;
        prev = curr = head;
        if (head == null)
            return null;
        if (head.next == null)
            return head;
        head = head.next;
        while (curr != null && curr.next != null)
        {
            //swap
            prev.next = curr.next;
            prev = curr;
            curr = curr.next;
            prev.next = curr.next;
            curr.next = prev;
            curr = curr.next.next;
        }
        return head;
    }
}