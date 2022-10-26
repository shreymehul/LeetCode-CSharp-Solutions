// 974. Subarray Sums Divisible by K

// Given an integer array nums and an integer k, return the number of non-empty subarrays that have a sum divisible by k.

// A subarray is a contiguous part of an array.

// Example 1:

// Input: nums = [4,5,0,-2,-3,1], k = 5
// Output: 7
// Explanation: There are 7 subarrays with a sum divisible by k = 5:
// [4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]
// Example 2:

// Input: nums = [5], k = 9
// Output: 0

//TLE
public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        int[] preSum = new int[nums.Length];
        int count = 0;
        for(int i = 0; i < nums.Length; i++){
            preSum[i] = nums[i];
            if(i>0)
                preSum[i] += preSum[i-1];
            if (preSum[i] % k == 0)
                count++;
        }
        for(int i = 0; i < preSum.Length - 1; i++){
            for(int j = i + 1; j < preSum.Length; j++){
                if((preSum[j] - preSum[i]) % k == 0)
                    count++;
            }
        }
        return count;
    }
}
//Approch 2 (refer soln 523)
public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int prefixSum = 0;
        int count = 0;
        //insert an extra 0 because if a sum is divisible by k so we have to add it in the answer
        map[0] = 1;
        for(int i = 0; i < nums.Length; i++){
            // Prefix sum which will have sum of all previous elements.
            prefixSum += nums[i];
            
            // Mod by k
            int rem = prefixSum % k;
            //if the remainder is negative then its positve complementary will be (rem+k) 
            if(rem < 0)
                rem += k;
           
            if(map.ContainsKey(rem)){
			//diff = prefix[b] - prefix[a] = 0 => prefix[b] = prefix[a] 
                count += map[rem];
                map[rem] += 1;
            }      
            else{
                map[rem] = 1;
            }
            
        }
        
        return count;
    }
}