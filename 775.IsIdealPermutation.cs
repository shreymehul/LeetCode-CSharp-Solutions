// 775. Global and Local Inversions

// You are given an integer array nums of length n which represents a permutation of all the integers in the range [0, n - 1].

// The number of global inversions is the number of the different pairs (i, j) where:

// 0 <= i < j < n
// nums[i] > nums[j]
// The number of local inversions is the number of indices i where:

// 0 <= i < n - 1
// nums[i] > nums[i + 1]
// Return true if the number of global inversions is equal to the number of local inversions.

// Example 1:

// Input: nums = [1,0,2]
// Output: true
// Explanation: There is 1 global inversion and 1 local inversion.
// Example 2:

// Input: nums = [1,2,0]
// Output: false
// Explanation: There are 2 global inversions and 1 local inversion.

public class Solution {
    public bool IsIdealPermutation(int[] nums) {
        int[] temp = (int[])nums.Clone();
        int globalCount = MergeSort(temp, 0 , nums.Length-1);
        int localCount = 0;
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] < nums[i - 1])
                localCount++;
        }
        return localCount == globalCount;
    }
    //find countof inverse pair
    public int MergeSort(int[] nums, int left, int right){
        if(left >= right)
            return 0;
        int mid = (right-left)/2 + left;
        int count = MergeSort(nums, left, mid);
        count+= MergeSort(nums, mid+1, right);
        count += Merge(nums, left, mid, right);
        return count;
    }
    public int Merge(int[] nums, int left, int mid, int right){
        List<int> list = new List<int>();
        int l = left, r = mid+1;
        int count = 0;
        while(l <= mid && r <= right){
            if(nums[l] <= nums[r])
                list.Add(nums[l++]);
            else{
                list.Add(nums[r++]);
                count += (mid + 1 - l);
            }
        }
        while(l <= mid ){
            list.Add(nums[l++]);
        }
        while(r <= right){
            list.Add(nums[r++]);
        }
        for(int i = left; i <= right; i++)
            nums[i] = list[i-left];
        return count;
    }
}