// 198. House Robber

// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed,
// the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and
// it will automatically contact the police if two adjacent houses were broken into on the same night.

// Given an integer array nums representing the amount of money of each house, return the maximum amount of money you
// can rob tonight without alerting the police.

// Example 1:

// Input: nums = [1,2,3,1]
// Output: 4
// Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
// Total amount you can rob = 1 + 3 = 4.
// Example 2:

// Input: nums = [2,7,9,3,1]
// Output: 12
// Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
// Total amount you can rob = 2 + 9 + 1 = 12.

//Approch 1 -> DP (TLE)
public class Solution {
    int[] maxProfit = new int[100];
    public int Rob(int[] nums) {
        findMaxProfit(nums, 0);
        return maxProfit.Max();
    }
    public int findMaxProfit(int[] nums, int idx){
        if(idx >= nums.Length)
            return 0;
        //As we have Binary Option i.e. either to include curr or exclude. If included cant choose next;
        int inCurr = nums[idx] + findMaxProfit(nums, idx + 2);
        int exCurr = findMaxProfit(nums, idx+1);
        maxProfit[idx] = Math.Max(inCurr, exCurr);
        return maxProfit[idx];
    }
}

//Approch 2 -> DP O(n) Time, O(1) Space
public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1)
            return nums[0];
        if(nums.Length == 2)
            return Math.Max(nums[0], nums[1]);
        int max = 0;
        nums[nums.Length - 3] += nums[nums.Length -1];
        for(int i = nums.Length - 4 ; i >= 0 ; i-- ){
            nums[i] += Math.Max(nums[i+2],nums[i+3]); 
        }
        return Math.Max(nums[0],nums[1]);
    }
}

public class Solution {
    public int Rob(int[] nums) {
        int[] dp = new int[nums.Length];
        if(nums.Length == 1)
            return nums[0];
        if(nums.Length == 2)
            return Math.Max(nums[1],nums[0]);
        if(nums.Length == 3)
            return Math.Max(nums[1],nums[0]+nums[2]);
        dp[0] = nums[0];
        dp[1] = nums[1];
        dp[2] = nums[0]+nums[2];
        for(int i = 3; i<nums.Length;i++){
            dp[i] = nums[i] + Math.Max(dp[i-2],dp[i-3]);
        }
        return Math.Max(dp[nums.Length-1],dp[nums.Length-2]);
    }
}