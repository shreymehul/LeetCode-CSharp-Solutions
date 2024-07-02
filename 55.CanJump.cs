// 55. Jump Game
// You are given an integer array nums. You are initially positioned at the array's first index, and each element in the 
// array represents your maximum jump length at that position.
// Return true if you can reach the last index, or false otherwise.
// Example 1:

// Input: nums = [2,3,1,1,4]
// Output: true
// Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
// Example 2:

// Input: nums = [3,2,1,0,4]
// Output: false
// Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.


public class Solution {
    public bool CanJump(int[] nums) {
        int currPos = 0;
        for(int i = 0; i < nums.Length; i++){
            if(currPos < i) return false;
            currPos = Math.Max(currPos, i + nums[i]);
        }
        return true;
    }
}

public class Solution {
    public bool CanJump(int[] nums) {
        if(nums.Length == 1)
            return true;
        if(nums[0] == 0)
            return false;
        int maxReach = nums[0]; //max indx we can reach.
        int step = nums[0];
        
        for(int i = 1; i < nums.Length - 1; i++){
            maxReach = Math.Max(maxReach, i + nums[i]);
            step--;
            if(step == 0){
                if(i >= maxReach )  //In case it is same as i, it means we cant move frwd. Also if i is greater than current indx it means we are beyond reachable indx.
                    return false;
                step = maxReach -i; //Max Reachable indx - current indx = no of steps available.
            }
        }
        if(maxReach >= nums.Length - 1)
                return true;
        return false;
    }
}