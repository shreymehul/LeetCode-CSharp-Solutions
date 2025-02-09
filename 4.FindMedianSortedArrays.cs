// 4. Median of Two Sorted Arrays

// Given two sorted arrays nums1 and nums2 of size m and n respectively, 
// return the median of the two sorted arrays.
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
    //Intuition: We can solve this problem by merging the two arrays and finding the median.
    //We can create a new array and merge the two arrays.
    //We can find the median of the merged array and return it.
    //Time complexity: O(n)
    //Space complexity: O(n)
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

//Approch: Binary Search
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;

        // Ensure nums1 is the smaller array to minimize binary search operations
        if (m > n) return FindMedianSortedArrays(nums2, nums1);

        int left = 0, right = m;
        int totalLeft = (m + n + 1) / 2;  // Partition point to balance the two sides

        while (left <= right) {
            // Binary search partition for nums1
            int partition1 = (left + right) / 2;
            
            // Corresponding partition for nums2 to balance totalLeft
            int partition2 = totalLeft - partition1;

            // Handle edge cases where partition is out of bounds
            int maxLeft1 = (partition1 == 0) ? 
                            int.MinValue : nums1[partition1 - 1];
            int minRight1 = (partition1 == m) ? 
                            int.MaxValue : nums1[partition1];

            int maxLeft2 = (partition2 == 0) ? 
                            int.MinValue : nums2[partition2 - 1];
            int minRight2 = (partition2 == n) ? 
                            int.MaxValue : nums2[partition2];

            // Check if valid partition is found
            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1) {
                // If total length is even, take average of two middle elements
                if ((m + n) % 2 == 0) {
                    return (Math.Max(maxLeft1, maxLeft2) 
                            + Math.Min(minRight1, minRight2)) / 2.0;
                } else {
                    // If total length is odd, return the max of left partition
                    return Math.Max(maxLeft1, maxLeft2);
                }
            } 
            // Shift partition to the left if nums1's left part is too large
            else if (maxLeft1 > minRight2) {
                right = partition1 - 1;
            } 
            // Shift partition to the right if nums2's left part is too large
            else {
                left = partition1 + 1;
            }
        }

        // This case should never be reached if inputs are valid and sorted
        throw new ArgumentException("Input arrays are not sorted");
    }
}



public class Solution {
    //intuition: We can solve this problem by finding the kth element in the merged array.
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int len = nums1.Length + nums2.Length;
        //If the length of the merged array is odd, we can find the median by finding the (len/2)th element.
        if (len % 2 != 0)
            return FindMedianOdd(nums1, nums2, len);
        //If the length of the merged array is even, we can find the median by finding the (len/2)th and (len/2+1)th element.
        else
            return FindMedianEven(nums1, nums2, len);
    }

    public double FindMedianOdd(int[] nums1, int[] nums2, int len) {
        int x = 0, y = 0, i = 0;
        double res = 0;
        //We can find the (len/2)th element by iterating through the merged array.
        while (i <= len / 2) {
            //We can find the (len/2)th element by finding the minimum of the two arrays.
            if (x < nums1.Length && y < nums2.Length) {
                if (nums1[x] <= nums2[y]) {
                    res = nums1[x];
                    x++;
                } else {
                    res = nums2[y];
                    y++;
                }
            } else if (x < nums1.Length) {
                res = nums1[x];
                x++;
            } else if (y < nums2.Length) {
                res = nums2[y];
                y++;
            }
            i++;
        }
        return res;
    }

    public double FindMedianEven(int[] nums1, int[] nums2, int len) {
        //We can find the (len/2)th and (len/2+1)th element by finding the minimum of the two arrays.
        double median1 = FindKthElement(nums1, 0, nums2, 0, len / 2);
        double median2 = FindKthElement(nums1, 0, nums2, 0, len / 2 + 1);
        return (median1 + median2) / 2.0;
    }

    private double FindKthElement(int[] nums1, int start1, int[] nums2, int start2, int k) {
        //If the first array is empty, we can return the kth element of the second array.
        if (start1 >= nums1.Length) return nums2[start2 + k - 1];
        //If the second array is empty, we can return the kth element of the first array.
        if (start2 >= nums2.Length) return nums1[start1 + k - 1];
        //If k is 1, we can return the minimum of the two arrays.
        if (k == 1) return Math.Min(nums1[start1], nums2[start2]);

        //We can find the kth element by finding the minimum of the two arrays.
        //We can find the mid element of the two arrays.
        //We can compare the mid element of the two arrays.
        //We can find the k/2th element of the two arrays.
        //We can find the k-k/2th element of the two arrays.
        //We can find the minimum of the two elements.
        int mid1 = start1 + k / 2 - 1 < nums1.Length ? nums1[start1 + k / 2 - 1] : int.MaxValue;
        int mid2 = start2 + k / 2 - 1 < nums2.Length ? nums2[start2 + k / 2 - 1] : int.MaxValue;

        //We can compare the mid element of the two arrays.
        if (mid1 < mid2) {
            return FindKthElement(nums1, start1 + k / 2, nums2, start2, k - k / 2);
        } else {
            return FindKthElement(nums1, start1, nums2, start2 + k / 2, k - k / 2);
        }
    }
}
