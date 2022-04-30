// 19. Remove Nth Node From End of List
// Given the head of a linked list, remove the nth node from the end of the list and return its head.
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode p,q,t;
        t= null;
        p = q = head;
        for(int i= 0; i<n ; i++){
            p = p.next;
        }
        while(p!=null){
            p=p.next;
            t=q;
            q=q.next;
        }
        if (t==null){
            head = head.next;
        }
        else if(q==null){
            t = null;
        }
        else if(q.next == null){
            t.next = null;
        } 
        else{
             t.next= t.next.next;
        }
       
        return head;
    }
}