// 532. K-diff Pairs in an Array

// Given an array of integers nums and an integer k, return the number of unique k-diff pairs in the array.

// A k-diff pair is an integer pair (nums[i], nums[j]), where the following are true:

// 0 <= i, j < nums.length
// i != j
// nums[i] - nums[j] == k
// Notice that |val| denotes the absolute value of val.

// Example 1:

// Input: nums = [3,1,4,1,5], k = 2
// Output: 2
// Explanation: There are two 2-diff pairs in the array, (1, 3) and (3, 5).
// Although we have two 1s in the input, we should only return the number of unique pairs.
// Example 2:

// Input: nums = [1,2,3,4,5], k = 1
// Output: 4
// Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and (4, 5).
// Example 3:

// Input: nums = [1,3,1,5,4], k = 0
// Output: 1
// Explanation: There is one 0-diff pair in the array, (1, 1).

//Approch 1 -> Works only for positive nums.
public class Solution {
    public int FindPairs(int[] nums, int k) {
        int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
            }
            int[] freq = new int[max + 1];
            foreach (int num in nums)
                freq[num]++;
            int count = 0;
            for (int i = 0; i < freq.Length - k; i++)
            {
                if (k == 0 && freq[i] > 1)
                {
                    count++;
                }
                else if (k !=0 && freq[i] > 0 && freq[i + k] > 0)
                    count++;
            }
            return count;
    }
}
//Approch 2 -> With HashMap
public class Solution {
    public int FindPairs(int[] nums, int k) {
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
            }
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq[num] = 1;
            }
            int count = 0;
            foreach (var item in freq)
            {
                if (k == 0 && item.Value > 1)
                {
                    count++;
                }
                else if (k !=0 && item.Value > 0 && freq.ContainsKey(item.Key + k))
                    count++;
            }
            return count;
    }
}