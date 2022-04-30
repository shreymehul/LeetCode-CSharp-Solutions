//83. Remove Duplicates from Sorted List
//Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
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

