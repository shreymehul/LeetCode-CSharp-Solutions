// 25. Reverse Nodes in k-Group
// Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.
// k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.
// You may not alter the values in the list's nodes, only nodes themselves may be changed.

// Example 1:
// Input: head = [1,2,3,4,5], k = 2
// Output: [2,1,4,3,5]
// Example 2:
// Input: head = [1,2,3,4,5], k = 3
// Output: [3,2,1,4,5]

// Constraints:
// The number of nodes in the list is n.
// 1 <= k <= n <= 5000
// 0 <= Node.val <= 1000

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
// Approch 1
public class Solution {
    // Function to reverse every k nodes in a linked list
    public ListNode ReverseKGroup(ListNode head, int k) {
        // If the head is null or k is 1, no reversal is required
        if (head == null || k == 1) {
            return head;
        }
        
        // Create a dummy node to handle edge cases more easily
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prevGroupEnd = dummy;
        
        while (true) {
            // Check if there are at least k nodes left to reverse
            ListNode kthNode = GetKthNode(prevGroupEnd, k);
            if (kthNode == null) {
                break;
            }
            
            // Reverse k nodes
            ListNode nextGroupStart = kthNode.next;
            ListNode[] reversedNodes = Reverse(prevGroupEnd.next, kthNode);
            
            // Connect the previous group's end to the newly reversed group
            ListNode temp = prevGroupEnd.next;
            prevGroupEnd.next = reversedNodes[0];
            reversedNodes[1].next = nextGroupStart;
            
            // Move prevGroupEnd to the end of the reversed segment
            prevGroupEnd = temp;
        }
        
        // Return the next of the dummy node, which will be the head of the reversed list
        return dummy.next;
    }
    
    // Helper function to get the k-th node from the given node
    private ListNode GetKthNode(ListNode start, int k) {
        ListNode current = start;
        for (int i = 0; i < k; i++) {
            if (current == null) {
                return null;
            }
            current = current.next;
        }
        return current;
    }
    
    // Helper function to reverse the nodes between start and end (inclusive)
    private ListNode[] Reverse(ListNode start, ListNode end) {
        ListNode prev = end.next;
        ListNode curr = start;
        while (prev != end) {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return new ListNode[] { end, start };
    }
}



 //Approch 2
public class Solution {
    // Function to reverse every k nodes in a linked list
    public ListNode ReverseKGroup(ListNode head, int k) {
        // If the head is null or k is 1, no reversal is required
        if (head == null || k == 1)
            return head;
        
        // Create a dummy node to handle edge cases more easily
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;
        
        // Loop until prev becomes null, which means we have traversed the whole list
        while (prev != null) {
            // Reverse the next k nodes and update prev to the new tail of the reversed group
            prev = ReverseNextK(prev, k);
        }
        
        // Return the next of the dummy node, which will be the head of the reversed list
        return dummy.next;
    }
    
    // Function to reverse the next k nodes starting from prev
    private ListNode ReverseNextK(ListNode prev, int k) {
        // Initialize a pointer to find the end of the next k nodes
        ListNode last = prev;
        // Move last pointer k steps forward
        for (int i = 0; i <= k; i++) {
            last = last.next;
            // If the remaining nodes are less than k, do not reverse
            if (last == null && i != k)
                return null;
        }
        
        // Initialize pointers for the reverse operation
        ListNode tail = prev.next;
        ListNode curr = prev.next.next;
        
        // Reverse the next k nodes
        while (curr != last) {
            ListNode next = curr.next;
            curr.next = prev.next;
            prev.next = curr;
            curr = next;
        }
        tail.next = next;
        // Return the tail of the reversed group for the next iteration
        return tail;
    }
}
