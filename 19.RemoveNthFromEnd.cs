// 19. Remove Nth Node From End of List
// Given the head of a linked list, remove the nth node from the end of the list and return its head.

// Example 1:
// Input: head = [1,2,3,4,5], n = 2
// Output: [1,2,3,5]
// Example 2:
// Input: head = [1], n = 1
// Output: []
// Example 3:
// Input: head = [1,2], n = 1
// Output: [1]

// Constraints:
// The number of nodes in the list is sz.
// 1 <= sz <= 30
// 0 <= Node.val <= 100
// 1 <= n <= sz

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
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode p, q, t;
        t = null;
        p = q = head;
        for (int i = 0; i < n; i++)
        {
            p = p.next;
        }
        while (p != null)
        {
            p = p.next;
            t = q;
            q = q.next;
        }
        if (t == null)
        {
            head = head.next;
        }
        else if (q == null)
        {
            t = null;
        }
        else if (q.next == null)
        {
            t.next = null;
        }
        else
        {
            t.next = t.next.next;
        }

        return head;
    }
}