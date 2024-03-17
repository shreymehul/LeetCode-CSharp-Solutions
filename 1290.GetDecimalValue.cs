// 1290. Convert Binary Number in a Linked List to Integer

// Given head which is a reference node to a singly-linked list. 
// The value of each node in the linked list is either 0 or 1. 
// The linked list holds the binary representation of a number.

// Return the decimal value of the number in the linked list.

// The most significant bit is at the head of the linked list.
// Example 1:
// Input: head = [1,0,1]
// Output: 5
// Explanation: (101) in base 2 = (5) in base 10
// Example 2:
// Input: head = [0]
// Output: 0
 
// Constraints:
// The Linked List is not empty.
// Number of nodes will not exceed 30.
// Each node's value is either 0 or 1.

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
    //Intution: 
    public int GetDecimalValue(ListNode head) {
        int result = 0;
        int pow = -1;
        ListNode curr = head;
        //First we need to find the length of the linked list
        while(curr != null){
            pow++;
            curr = curr.next;
        }
        curr = head;
        while(curr != null){
            //We can calculate the decimal value of the linked list by multiplying the value of 
            //the current node by 2^pow where pow is the length of the linked list - 1
            result += curr.val * (int)Math.Pow(2,pow);
            pow--;
            curr = curr.next;
        }
        return result;
    }
}

//Another solution using StringBuilder and Convert.ToInt32
public class Solution {
    public int GetDecimalValue(ListNode head) {
        StringBuilder sb = new();
        while(head != null){
            //We can use StringBuilder to append the value of each node in the linked list
            sb.Append(head.val);
            head= head.next;
        }
        //We can then use Convert.ToInt32 to convert the binary string to an integer
        return Convert.ToInt32(sb.ToString(), 2);
    }
}