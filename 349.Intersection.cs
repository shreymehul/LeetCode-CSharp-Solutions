// 349. Intersection of Two Arrays
// Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must be unique
// and you may return the result in any order.

// Example 1:
// Input: nums1 = [1,2,2,1], nums2 = [2,2]
// Output: [2]
// Example 2:
// Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
// Output: [9,4]
// Explanation: [4,9] is also accepted.
 
 public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        Array.Sort(nums1);
        Array.Sort(nums2);
        List<int> res = new List<int>();
        int p1 = 0, p2 = 0;
        while(p1 < nums1.Length && p2 < nums2.Length){
            if(nums1[p1] == nums2[p2]){
                if(res.Count == 0 || res[res.Count-1] != nums1[p1])
                    res.Add(nums1[p1]);
                p1++;
                p2++;
            }
            else{
                if(nums1[p1] < nums2[p2])
                    p1++;
                else
                    p2++;
            }
        } 
        return res.ToArray();
    }
}

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> set = new HashSet<int>();
        foreach(int num in nums1)
            set.Add(num);
        
        HashSet<int> res = new HashSet<int>();
        foreach(int num in nums2){
            if(set.Contains(num))
                res.Add(num);
        }
        return res.ToArray();
    }
}