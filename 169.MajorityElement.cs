//169. Majority Element
// Given an array nums of size n, return the majority element.

// The majority element is the element that appears more than ⌊n / 2⌋ times.
// You may assume that the majority element always exists in the array.

public class Solution {
    public int MajorityElement(int[] nums) {
        int majority = nums[0];
        int majCount = 1;
        
        for(int i=1; i< nums.Length; i++){
            if(nums[i]==majority)
                majCount++;
            else
                majCount--;
            if(majCount ==0 ){
                majority = nums[i];
                majCount = 1;
            }
        }
        return majority;
    }
}