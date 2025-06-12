// 128. Longest Consecutive Sequence
// Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

// You must write an algorithm that runs in O(n) time.
// Example 1:
// Input: nums = [100,4,200,1,3,2]
// Output: 4
// Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
// Example 2:
// Input: nums = [0,3,7,2,5,8,4,6,0,1]
// Output: 9

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> nSet = new HashSet<int>();
        foreach (int num in nums)
            nSet.Add(num);
        int max = 0;
        foreach (int num in nums)
        {
            int count = 1;
            if (!nSet.Contains(num - 1))
            {
                int curr = num;
                while (nSet.Contains(curr + 1))
                {
                    count++;
                    curr++;
                }
            }
            max = Math.Max(count, max);
        }
        return max;
    }
}

public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums == null || nums.Length == 0)
            return 0;

        HashSet<int> numSet = new HashSet<int>(nums);
        int maxLength = 0;

        foreach (int num in numSet) {
            // Only start from the beginning of a sequence
            if (!numSet.Contains(num - 1)) {
                int currentNum = num;
                int currentStreak = 1;

                while (numSet.Contains(currentNum + 1)) {
                    currentNum++;
                    currentStreak++;
                }

                maxLength = Math.Max(maxLength, currentStreak);
            }
        }

        return maxLength;
    }
}
