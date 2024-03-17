// 88. Merge Sorted Array
// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, 
// representing the number of elements in nums1 and nums2 respectively.
// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
// The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

//Time O(nlogn)
public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = 0; i < n; i++)
        {
            nums1[m + i] = nums2[i];
        }
        Array.Sort(nums1);
    }
}

//Space O(n+m) Time O(n+m)
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int[] res = new int[m+n];
        int i = 0, j = 0, k = 0;
        while( i < m && j < n){
            if(nums1[i] <= nums2[j])
                res[k++] = nums1[i++];
            else
                res[k++] = nums2[j++]; 
        }
        while( i < m){
            res[k++] = nums1[i++];
        }
        while(j < n){
            res[k++] = nums2[j++]; 
        }
        res.CopyTo(nums1,0);
    }
}
//Time O(n,m) Space O(1)

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        if(n == 0)
            return;
        //Start from the end of the arrays
        int i = m-1, j = n -1, pos = m+n-1;
        while(i >= 0 && j >= 0){
            //if the element in nums1 is greater than the element in nums2, put it in the last position
            if(nums1[i] > nums2[j])
                nums1[pos] = nums1[i--];
            //else put the element from nums2 in the last position
            else
                nums1[pos] = nums2[j--];
            pos--;
        }
        //If there are still elements in nums2, put them in the array
        while(j >= 0){
            nums1[pos--] = nums2[j--];
        }
    }
}
