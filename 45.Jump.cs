// 45. Jump Game II

// You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].

// Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], 
// you can jump to any nums[i + j] where:

// 0 <= j <= nums[i] and
// i + j < n
// Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

// Example 1:
// Input: nums = [2,3,1,1,4]
// Output: 2
// Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
// Example 2:
// Input: nums = [2,3,0,1,4]
// Output: 2

public class Solution {
    public int Jump(int[] nums) {
        if(nums.Length == 1)
            return 0;
        if(nums[0] == 0)
            return -1;
        int maxReach = nums[0];//max indx we can reach.
        int step = nums[0];
        int jump = 1;
        
        for(int i = 1; i < nums.Length - 1; i++){
            maxReach = Math.Max(maxReach, i + nums[i]);
            step--;
            if(step == 0){
                jump++; //As 0 steps are left so min 1 jump is required to move frwd
                if(i >= maxReach )  //In case it is same as i, it means we cant move frwd. Also if i is greater than current indx it means we are beyond reachable indx.
                    return -1;
                step = maxReach -i; //Max Reachable indx - current indx = no of steps available.
            }
        }
        if(maxReach >= nums.Length - 1)
                return jump;
        return -1;
    }
}