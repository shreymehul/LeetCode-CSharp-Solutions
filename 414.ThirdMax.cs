// 414. Third Maximum Number

// Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

// Example 1:

// Input: nums = [3,2,1]
// Output: 1
// Explanation:
// The first distinct maximum is 3.
// The second distinct maximum is 2.
// The third distinct maximum is 1.
// Example 2:

// Input: nums = [1,2]
// Output: 2
// Explanation:
// The first distinct maximum is 2.
// The second distinct maximum is 1.
// The third distinct maximum does not exist, so the maximum (2) is returned instead.
// Example 3:

// Input: nums = [2,2,3,1]
// Output: 1
// Explanation:
// The first distinct maximum is 3.
// The second distinct maximum is 2 (both 2's are counted together since they have the same value).
// The third distinct maximum is 1.

//MinHeap HashSet
public class Solution {
    public int ThirdMax(int[] nums) {
        PriorityQueue<int,int> minHeap = new PriorityQueue<int,int>();
        HashSet<int> hSet = new HashSet<int>();
        foreach(int num in nums){
            if(!hSet.Contains(num)){
                hSet.Add(num);
                minHeap.Enqueue(num,num);
                if(minHeap.Count > 3)
                    minHeap.Dequeue();
            }
        }
        
        if(minHeap.Count == 3)
            return minHeap.Peek();
        while(minHeap.Count > 1)
            minHeap.Dequeue();
        return minHeap.Peek();
    }
}
//List
public class Solution {
    public int ThirdMax(int[] nums) {
        List<int> list = new List<int>();
        foreach(int num in nums){
            if(!list.Contains(num))
                list.Add(num);
        }
        list.Sort();
        if(list.Count >= 3)
            return list[list.Count-3];
        return list[list.Count-1];
    }
}