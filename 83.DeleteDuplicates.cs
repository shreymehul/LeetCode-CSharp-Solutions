// 83. Remove Duplicates from Sorted List
// Given the head of a sorted linked list, delete all duplicates such that each element appears only once. 
// Return the linked list sorted as well.

// Example 1:
// Input: head = [1,1,2]
// Output: [1,2]
// Example 2:
// Input: head = [1,1,2,3,3]
// Output: [1,2,3]

// Constraints:
// The number of nodes in the list is in the range [0, 300].
// -100 <= Node.val <= 100
// The list is guaranteed to be sorted in ascending order.

public class listnode
{
    public int val;
    public listnode next;
    public listnode(int val = 0, listnode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class Solution
{
    public listnode DeleteDuplicates(listnode head)
    {
        listnode pivot = head;
        while (pivot != null)
        {
            while (pivot.next != null && pivot.val == pivot.next.val)
            {
                pivot.next = pivot.next.next;
            }
            pivot = pivot.next;
        }
        return head;
    }
}

public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode cur = head;
            while (cur != null && cur.next !=null)
            {
                if(cur.val == cur.next.val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }
            return head;
    }
}
