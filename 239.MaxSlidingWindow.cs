// 239. Sliding Window Maximum

// You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the
// array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one
// position.
// Return the max sliding window.

//Optimised
using System.Collections.Generic;

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (nums == null || nums.Length == 0) return new int[0];
        
        int n = nums.Length;
        int[] res = new int[n - k + 1];
        LinkedList<int> deque = new LinkedList<int>(); // Stores indices of elements

        for (int i = 0; i < nums.Length; i++) {
            // Remove elements out of the current window
            if (deque.Count > 0 && deque.First.Value <= i - k)
                deque.RemoveFirst();

            // Remove all elements smaller than the current element from the back
            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
                deque.RemoveLast();

            // Add the current element at the back of the deque
            deque.AddLast(i);

            // Set the result for the current window
            if (i >= k - 1)
                res[i - k + 1] = nums[deque.First.Value];
        }

        return res;
    }
}


//Deque implementation via List
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int[] res = new int[nums.Length - k + 1];
        List<int> max = new List<int>(); //use as Deque
        for (int i = 0; i < k; i++)
        {
            while (max.Count > 0 && max.First() < nums[i])
                max.RemoveAt(0); //popFirst
            while (max.Count > 0 && max.Last() < nums[i])
                    max.RemoveAt(max.Count - 1); //popLast
            max.Add(nums[i]); //push
        }
        res[0] = max.First();
        for (int i = k; i < nums.Length; i++)
        {
            if (max.Count > 0 && max.First() == nums[i - k]) //peekFirst
                max.RemoveAt(0); //popFirst
            while (max.Count > 0 && max.First() < nums[i]) //peekFirst
                max.RemoveAt(0); //popFirst
            while (max.Count > 0 && max.Last() < nums[i]) //peekLast
                max.RemoveAt(max.Count-1); //popLast
            max.Add(nums[i]); //push
            res[i - k + 1] = max.First();
        }
        return res;
    }
}
//c# incomplete solution.
//need deque implementation
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int[] res = new int[nums.Length-k+1];
        Deque<int> max = new Deque<int>();
        for (int i = 0; i < k; i++)
        {
            while (max.Count > 0 && max.PeekFirst() < nums[i])
            {
                max.PopFirst();
            }
            max.AddFirst(nums[i]);
        }
        res[0] = max.PeekFirst();
        for (int i = k; i < nums.Length; i++)
        {
            if (max.Count > 0 && max.PeekFirst() == nums[i-k])
                max.PopFirst();
            while(max.Count > 0 && max.Peek() < nums[i])
            {
                max.PopFirst();
            }
            while(max.Count > 0 && max.PeekLast > nums[i])
                max.PopLast();
            max.AddFirst(nums[i]);
            res[i-k+1] = max.PeekFirst();
        }
        return res;
    }
}