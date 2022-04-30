﻿namespace LeetCodeCSharpSolution
{
    internal class RemoveElementsSolution
    {
        //203. Remove Linked List Elements
        //Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.
        //definition for singly-linked list.
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
            public listnode RemoveElements(listnode head, int val)
            {
                listnode pivot = head;
                if (head == null)
                {
                    return head;
                }
                while (head.val == val)
                {
                    if (head.next == null)
                        return null;
                    head = head.next;
                }
                while (pivot != null)
                {
                    while (pivot.next != null && pivot.next.val == val)
                    {
                        pivot.next = pivot.next.next;
                    }
                    pivot = pivot.next;
                }
                return head;
            }
        }
    }
}
