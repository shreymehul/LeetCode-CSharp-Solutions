// 23. Merge k Sorted Lists

// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
// Merge all the linked-lists into one sorted linked-list and return it.

// Example 1:
// Input: lists = [[1,4,5],[1,3,4],[2,6]]
// Output: [1,1,2,3,4,4,5,6]
// Explanation: The linked-lists are:
// [
//   1->4->5,
//   1->3->4,
//   2->6
// ]
// merging them into one sorted list:
// 1->1->2->3->4->4->5->6
// Example 2:
// Input: lists = []
// Output: []
// Example 3:
// Input: lists = [[]]
// Output: []
//Approch Divide & Conqure -> Merge Sort
public class Solution {
    //intution: Use Merge Sort to merge the lists.
    //Time complexity: O(NLogK) where N is the total number of elements in all the lists and K is the number of lists.
    //Space complexity: O(1)
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists == null || lists.Length == 0)
            return null;
        return MergeSort(lists, 0, lists.Length-1);
    }
    public ListNode MergeSort(ListNode[] lists, int low, int high){
        if(low == high)
            return lists[low];
        int mid = (high-low)/2 + low;
        ListNode left = MergeSort(lists, low, mid),
            right = MergeSort(lists, mid+1, high);
        return Merge(left, right);
    }
    public ListNode Merge(ListNode l1, ListNode l2){
        ListNode head = new ListNode();
        ListNode curr = head;
        
        while(l1 != null && l2 != null){
            if(l1.val <= l2.val){
                curr.next = l1;
                l1 = l1.next;
            }
            else{
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }
        if(l1 != null){
            curr.next = l1;
        }
        if(l2 != null){
            curr.next = l2;
        }
        return head.next;
    }
}

//Approch MinHeap Time O(KLogN) Space O(1)
public class Solution {
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public ListNode MergeKLists(ListNode[] lists)
    {
        PriorityQueue<ListNode> minHeap = new PriorityQueue<ListNode>();
        ListNode head = null;
        ListNode current = null;
        foreach(var item in lists)
        {
            minHeap.Add(item);
        }
        while (minHeap.Count > 0)
        {
            var min = minHeap.Dequeue();
            var node = new ListNode(min.val);
            if (head == null)
            {
                current = node;
                head = current;
            }
            else
            {
                current.next = node;
            }
            min = min.next;
            if (node == null)
                minHeap.Dequeue(node);
        }
        return head;
    }
}