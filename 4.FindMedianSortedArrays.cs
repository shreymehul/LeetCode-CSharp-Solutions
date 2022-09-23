// 4. Median of Two Sorted Arrays

// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

// The overall run time complexity should be O(log (m+n)).

 

// Example 1:

// Input: nums1 = [1,3], nums2 = [2]
// Output: 2.00000
// Explanation: merged array = [1,2,3] and median is 2.
// Example 2:

// Input: nums1 = [1,2], nums2 = [3,4]
// Output: 2.50000
// Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] merge = new int[nums1.Length + nums2.Length];
        int p1=0, p2=0;
        for(int i = 0; i < merge.Length; i++)
        {
            if((p1<nums1.Length && p2<nums2.Length && nums1[p1] <= nums2[p2])
                || (p1 < nums1.Length && p2 >= nums2.Length))
            {
                merge[i] = nums1[p1++];
            }
            else
            {
                merge[i] = nums2[p2++];
            }
        }
        double result = 0;
        if(merge.Length %2 !=0)
            result = (double)merge[merge.Length/2];
        else
            result = ((double)merge[merge.Length / 2]+ 
                      (double)merge[(merge.Length / 2)-1])/2;
        return result;
    }
}