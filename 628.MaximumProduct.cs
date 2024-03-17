// 628. Maximum Product of Three Numbers
// Given an integer array nums, find three numbers whose product is maximum and return the maximum product.

// Example 1:
// Input: nums = [1,2,3]
// Output: 6
// Example 2:
// Input: nums = [1,2,3,4]
// Output: 24
// Example 3:
// Input: nums = [-1,-2,-3]
// Output: -6

// Constraints:
// 3 <= nums.length <= 104
// -1000 <= nums[i] <= 1000

public class Solution {
    public int MaximumProduct(int[] nums) {
        int max1, max2, max3, min1, min2;
        max1 = max2 = max3 = int.MinValue;
        min1 = min2 = int.MaxValue;
        foreach(int num in nums){
            if(num > max1){
                (max1, max2, max3) = (num, max1, max2);
            }
            else if(num > max2){
                (max2, max3) = (num, max2);
            }
            else if(num > max3){
                max3 = num;
            }
            if(num < min1){
                (min1, min2) = (num, min1);
            }
            else if(num < min2){
                min2 = num;
            }
        }
        return Math.Max(max1*max2*max3, max1*min1*min2);
    }
}

// Using PriorityQueue

public class Solution {
    public int MaximumProduct(int[] nums) {
        PriorityQueue<int, int> max = new PriorityQueue<int, int>();
        PriorityQueue<int, int> min = new PriorityQueue<int, int>();

        for(int i = 0; i < nums.Length; i++){
            max.Enqueue(nums[i],nums[i]);
            min.Enqueue(nums[i],(-1)*nums[i]);
            if(max.Count > 3)
                max.Dequeue();
            if(min.Count > 2)
                min.Dequeue();
        }
        int m1 = max.Dequeue()*max.Dequeue();
        int m2 = min.Dequeue()*min.Dequeue();
        int m3= max.Dequeue();

        int result = Math.Max(m1*m3, m2*m3);
        return result;
    }
}