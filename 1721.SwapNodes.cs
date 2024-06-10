// 1721. Swapping Nodes in a Linked List
// You are given the head of a linked list, and an integer k.
// Return the head of the linked list after swapping the values of the kth node from the beginning and the kth node from the end (the list is 1-indexed).

// Example 1:
// Input: head = [1,2,3,4,5], k = 2
// Output: [1,4,3,2,5]
// Example 2:
// Input: head = [7,9,6,6,7,8,3,0,9,5], k = 5
// Output: [7,9,6,6,8,7,3,0,9,5]
 

// Constraints:
// The number of nodes in the list is n.
// 1 <= k <= n <= 105
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
public class Solution {
    public ListNode SwapNodes(ListNode head, int k) {
        if (head == null) return null;

        ListNode first = head;
        ListNode second = head;
        ListNode temp = head;

        // Move `first` to the k-th node from the beginning
        for (int i = 1; i < k; i++) {
            first = first.next;
        }

        // Move `temp` to the end to find the k-th node from the end
        while (temp != null) {
            temp = temp.next;
            if (k-- <= 0) {
                second = second.next;
            }
        }

        // Swap the values of the k-th node from the start and the k-th node from the end
        (first.val, second.val)  = (second.val, first.val);

        return head;
    }
}

