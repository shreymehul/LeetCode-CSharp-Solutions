// 2. Add Two Numbers
// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, 
// and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
// You may assume the two numbers do not contain any leading zero, except the number 0 itself.

// Example 1:

// Input: l1 = [2,4,3], l2 = [5,6,4]
// Output: [7,0,8]
// Explanation: 342 + 465 = 807.
// Example 2:

// Input: l1 = [0], l2 = [0]
// Output: [0]
// Example 3:

// Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
// Output: [8,9,9,9,0,0,0,1]
 
// Constraints:

// The number of nodes in each linked list is in the range [1, 100].
// 0 <= Node.val <= 9
// It is guaranteed that the list represents a number that does not have leading zeros.

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
    //Intuition: We can solve this problem using two pointers.
    //We can iterate through both the lists and add the values of the nodes.
    //We can keep track of the carry and add it to the next node.
    //If the sum is greater than 9, we can take the remainder and set the carry to 1.
    //If the sum is less than 9, we can set the carry to 0.
    //If we reach the end of the list and there is still a carry, we can add a new node with the value 1.
    //Finally, we can return the head of the list.
    //Time complexity: O(n)
    //Space complexity: O(1)
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

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return AddTwoNumbers(l1, l2, 0);
    }

    private ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry){
        if(l1 == null && l2 == null && carry == 0)
            return null;
        int sum = (l1 == null ? 0 : l1.val)
                   + (l2 == null ? 0 : l2.val)
                   + carry;
        return new ListNode(sum%10, AddTwoNumbers(l1?.next, l2?.next, sum/10));
    }
}