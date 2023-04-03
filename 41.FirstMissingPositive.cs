// 41. First Missing Positive

// Given an unsorted integer array nums, return the smallest missing positive integer.

// You must implement an algorithm that runs in O(n) time and uses constant extra space.
// Example 1:
// Input: nums = [1,2,0]
// Output: 3
// Explanation: The numbers in the range [1,2] are all in the array.
// Example 2:
// Input: nums = [3,4,-1,1]
// Output: 2
// Explanation: 1 is in the array but 2 is missing.
// Example 3:
// Input: nums = [7,8,9,11,12]
// Output: 1
// Explanation: The smallest positive integer 1 is missing.

// Approch 1 | Sorting
//O(nlogn) time
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        Array.Sort(nums);
        int result = 1;
        for(int i =0; i < nums.Length; i++){
            if(nums[i] == result)
                result++;
        }
        return result;
    }
}

// Approch 2 | Mapping
//O(n) time and O(n) Space
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        bool[] present = new bool[nums.Length + 1];
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] > 0 && nums[i] <= nums.Length)
                present[nums[i]] = true;
        }
        for(int i = 1; i <= nums.Length; i++){
            if(!present[i])
                return i;
        }
        return nums.Length + 1;
    }
}

//Approch3 | Swapping
//O(n) time and O(1) Space
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        for(int i = 0; i < nums.Length; i++){
            while(nums[i] > 0 && nums[i] <= nums.Length 
                  && nums[nums[i]-1] != nums[i]){
                    int t = nums[i];
                    nums[i] = nums[t - 1];
                    nums[t - 1] = t;
                }
        }
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] != i+1)
                return i+1;
        }
        return nums.Length + 1;
    }
}