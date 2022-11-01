// 347. Top K Frequent Elements

// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

// Example 1:

// Input: nums = [1,1,1,2,2,3], k = 2
// Output: [1,2]
// Example 2:

// Input: nums = [1], k = 1
// Output: [1]

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        foreach(int num in nums){
            if(map.ContainsKey(num))
                map[num]++;
            else
                map[num] = 1;
        }
        PriorityQueue<int,int> minHeap = new PriorityQueue<int,int>();
        foreach(var item in map){
            minHeap.Enqueue(item.Key,item.Value);
            if(minHeap.Count > k)
                minHeap.Dequeue();
        }
        int[] res = new int[k];
        int i = 0;
        while(minHeap.Count > 0)
            res[i++] = minHeap.Dequeue();
        return res;
    }
}