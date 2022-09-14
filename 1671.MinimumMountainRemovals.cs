//1671. Minimum Number of Removals to Make Mountain Array

// You may recall that an array arr is a mountain array if and only if:

// arr.length >= 3
// There exists some index i (0-indexed) with 0 < i < arr.length - 1 such that:
// arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
// arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
// Given an integer array nums​​​, return the minimum number of elements to remove to make nums​​​ a mountain array.

public class Solution {
     public int MinimumMountainRemovals(int[] nums) {
        return nums.Length - MaxBitonicSubseq(nums);
    }
    public int MaxBitonicSubseq(int[] a){
        int[] dpleft = new int[a.Length];
        int[] dpright = new int[a.Length];
        for(int i=0;i<a.Length;i++){
            int max = 0;
            for(int j=0;j<i;j++){
                if(a[j]<a[i] && dpleft[j]>max)
                    max = dpleft[j];
            }
            dpleft[i]= max + 1;
        }
        for(int i=a.Length-1;i>=0;i--){
            int max = 0;
            for(int j=a.Length-1;j>i;j--){
                if(a[j]<a[i] && dpright[j]>max)
                    max = dpright[j];
            }
            dpright[i]= max + 1;
        }
        int maxseq = 0;
        for(int i=1;i<a.Length-1;i++){
            int seqLen = dpleft[i] + dpright[i] - 1;
            if(seqLen > maxseq && dpleft[i]>1 && dpright[i]>1){
                maxseq = seqLen;
            }
        }
        return maxseq;
        
    }
}