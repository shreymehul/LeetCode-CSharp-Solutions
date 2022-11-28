// 148. Sort List
// Given the head of a linked list, return the list after sorting it in ascending order.
// Example 1:
// Input: head = [4,2,1,3]
// Output: [1,2,3,4]
// Example 2:
// Input: head = [-1,5,3,4,0]
// Output: [-1,0,3,4,5]
// Example 3:
// Input: head = []
// Output: []

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
    public ListNode SortList(ListNode head) {
        List<int> list = new List<int>();
        ListNode temp = head;
        while(temp!=null){
            list.Add(temp.val);
            temp = temp.next;
        }
        list.Sort();
        temp = head;
        foreach(var item in list){
            temp.val = item;
            temp = temp.next;
        }
        return head;
    }
}