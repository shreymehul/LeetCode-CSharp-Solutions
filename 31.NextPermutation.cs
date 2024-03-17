// 31. Next Permutation
// A permutation of an array of integers is an arrangement of its members into a sequence or linear order.

// For example, for arr = [1,2,3], the following are all the permutations of arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1].
// The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, then the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).

// For example, the next permutation of arr = [1,2,3] is [1,3,2].
// Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
// While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.
// Given an array of integers nums, find the next permutation of nums.

// The replacement must be in place and use only constant extra memory.
// Example 1:

// Input: nums = [1,2,3]
// Output: [1,3,2]
// Example 2:

// Input: nums = [3,2,1]
// Output: [1,2,3]
// Example 3:

// Input: nums = [1,1,5]
// Output: [1,5,1]


public class Solution {
    public void NextPermutation(int[] nums) {
        int idx1, idx2 = -1;

        //Find first index from the right that is less than the next index
        for (idx1 = nums.Length - 2; idx1 >= 0; idx1--) {
            if (nums[idx1] < nums[idx1 + 1]) {
                break;
            }
        }

        //If no such index is found, reverse the array and return
        if (idx1 < 0) {
            Array.Reverse(nums);
            return;
        }
        //Find the next index from the right that is greater than the first index
        for (int i = nums.Length - 1; i >= 0; i--) {
            if (nums[i] > nums[idx1]) {
                idx2 = i;
                break;
            }
        }

        //Swap the two indices
        (nums[idx1], nums[idx2]) = (nums[idx2], nums[idx1]);

        //Reverse the array from the first index
        Array.Reverse(nums, idx1 + 1, nums.Length - idx1 - 1);
    }
}

public class Solution {
    public void NextPermutation(int[] nums) {
        int idx1 = -1;
            int n = nums.Length;
            for (int i = n - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    idx1 = i;
                    break;
                }
            }
            if (idx1 != -1)
            {
                int idx2 = idx1;
                for (int i = idx1 + 1; i < n; i++)
                {
                    if (nums[i] > nums[idx1-1] && nums[i] <= nums[idx2])
                    {
                        idx2 = i;
                    }
                }
                int t = nums[idx1-1];
                nums[idx1-1] = nums[idx2];
                nums[idx2] = t;
                Array.Reverse(nums, idx1, n - idx1);
            }
            else
            {
                Array.Reverse(nums);
            }
    }
}