// 287. Find the Duplicate Number

// Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.

// There is only one repeated number in nums, return this repeated number.

// You must solve the problem without modifying the array nums and uses only constant extra space.

// Example 1:
// Input: nums = [1,3,4,2,2]
// Output: 2

public class Solution {
    public int FindDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            //If the number is already in the set, return it
            if(!set.Add(nums[i]))
                return nums[i];
        }
        return -1;
    }
}


public class Solution {
    public int FindDuplicate(int[] nums) {
        int[] freq = new int[nums.Length];
        for(int i = 0;i<nums.Length;i++){
            freq[nums[i]]++;
        }
        for(int i = 0;i<freq.Length;i++){
            if(freq[i] >1)
                return i;
        }
        return 0;
    }
}

public class Solution {
    public int FindDuplicate(int[] nums) {
        //Move the elements to their respective indices
        while(nums[nums[0]]!=nums[0])
            (nums[0], nums[nums[0]]) = (nums[nums[0]], nums[0]);
        //Return the element at the first index as it is the duplicate
        return nums[0];
    }
}


public class Solution {
    public int FindDuplicate(int[] nums) {
        //Floyd's Tortoise and Hare (Cycle Detection)
        int fast = nums[0], slow = nums[0];
        //Find the intersection point of the two pointers
        do{
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while(slow != fast);
        //Find the entrance to the cycle
        fast = nums[0];
        //Move the two pointers at the same speed until they meet
        while(slow != fast){
            slow = nums[slow];
            fast = nums[fast];
        }
        //Return the duplicate element. It is the entrance to the cycle.
        return slow;
    }
}