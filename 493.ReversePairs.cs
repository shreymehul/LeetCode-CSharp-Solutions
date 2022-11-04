// 493. Reverse Pairs

// Given an integer array nums, return the number of reverse pairs in the array.

// A reverse pair is a pair (i, j) where:

// 0 <= i < j < nums.length and
// nums[i] > 2 * nums[j].

// Example 1:

// Input: nums = [1,3,2,3,1]
// Output: 2
// Explanation: The reverse pairs are:
// (1, 4) --> nums[1] = 3, nums[4] = 1, 3 > 2 * 1
// (3, 4) --> nums[3] = 3, nums[4] = 1, 3 > 2 * 1
// Example 2:

// Input: nums = [2,4,3,5,1]
// Output: 3
// Explanation: The reverse pairs are:
// (1, 4) --> nums[1] = 4, nums[4] = 1, 4 > 2 * 1
// (2, 4) --> nums[2] = 3, nums[4] = 1, 3 > 2 * 1
// (3, 4) --> nums[3] = 5, nums[4] = 1, 5 > 2 * 1


//O(nlogn) + O(n)
public class Solution {
    public int ReversePairs(int[] nums) {
        return MergeSort(nums, 0, nums.Length-1);
    }
    public int MergeSort(int[] nums, int left, int right){
        if(left >= right)
            return 0;
        int mid = (right-left)/2 + left;
        int count = MergeSort(nums,left, mid);
        count += MergeSort(nums,mid+1,right);
        count += Merge(nums, left, mid, right);
        return count;
    }
    public int Merge(int[] nums, int left, int mid, int right){
        int count = 0;
        int j = mid + 1;
        
        for(int i = left ; i <= mid; i++){
            while(j <= right && nums[i] > (2*(long)nums[j]))
                j++;
            count += j-(mid+1);
        }
        int l = left, r = mid+1;
        List<int> list = new List<int>();
        while(l <= mid && r <= right){
            if(nums[l] <= nums[r])
                list.Add(nums[l++]);
            else
                list.Add(nums[r++]);
        }
        while(r <= right){
            list.Add(nums[r++]);
        }
        while(l <= mid){
            list.Add(nums[l++]);
        }
        for(int i = left; i <= right; i++){
            nums[i] = list[i-left];
        }
        return count;
    }
}