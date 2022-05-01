// 2. Add Two Numbers
// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
// You may assume the two numbers do not contain any leading zero, except the number 0 itself.

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
    public ListNode AddTwoNumbers(ListNode list1, ListNode list2)
    {
        ListNode head, curr, prev;
        if (list1 == null && list2 == null)
            return null;
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;
        head = curr = prev = list1;
        int carry = 0;
        while (list1 != null && list2 != null)
        {
            curr.val = list1.val + list2.val + carry;
            carry = 0;
            if (curr.val > 9)
            {
                carry = 1;
                curr.val = (curr.val) % 10;
            }
            list1 = list1.next;
            list2 = list2.next;
            prev = curr;
            curr = curr.next;
        }

        if (list2 != null)
        {
            prev.next = list2;
            curr = prev.next;
        }
        while (curr != null)
        {
            if (carry == 1)
                curr.val = curr.val + carry;
            carry = 0;
            if (curr.val > 9)
            {
                curr.val = curr.val % 10;
                carry = 1;
            }
            prev = curr;
            curr = curr.next;
        }
        if (carry == 1)
        {
            prev.next = new ListNode(1, null);
        }
        return head;
    }
}