// 143. Reorder List
// You are given the head of a singly linked-list. The list can be represented as:
// L0 → L1 → … → Ln - 1 → Ln
// Reorder the list to be on the following form:
// L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
// You may not modify the values in the list's nodes. Only nodes themselves may be changed.
// Example 1:
// Input: head = [1,2,3,4]
// Output: [1,4,2,3]
// Example 2:
// Input: head = [1,2,3,4,5]
// Output: [1,5,2,4,3]

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
    public void ReorderList(ListNode head)
    {
        ListNode mid = FindMiddle(head);
        mid.next = Reverse(mid.next);
        Merge(head, mid);
    }
    public ListNode FindMiddle(ListNode head)
    {
        ListNode slow, fast,pMid;
        slow = fast = pMid = head;
        while (fast != null && fast.next != null)
        {
            pMid = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        return pMid;
    }
    public ListNode Reverse(ListNode head)
    {
        ListNode pre, cur, nex;
        pre = nex = null;
        cur = head;
        while (cur != null)
        {
            nex = cur.next;
            cur.next = pre;
            pre = cur;
            cur = nex;
        }
        return pre;
    }
    public void Merge(ListNode head1, ListNode head2)
    {
        ListNode p1 = head1, p2 = head2.next;
        while(p1!= head2)
        {
            head2.next = p2.next;
            p2.next = p1.next;
            p1.next = p2;
            p1 = p2.next;
            p2 = head2.next;
        }
    }
}