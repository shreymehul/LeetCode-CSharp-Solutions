// 239. Sliding Window Maximum

// You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the
// array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one
// position.
// Return the max sliding window.

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