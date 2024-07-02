// 350. Intersection of Two Arrays II
// Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear
// as many times as it shows in both arrays and you may return the result in any order.

// Example 1:

// Input: nums1 = [1,2,2,1], nums2 = [2,2]
// Output: [2,2]
// Example 2:

// Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
// Output: [4,9]
// Explanation: [9,4] is also accepted.

public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        Array.Sort(nums1);
        Array.Sort(nums2);
        List<int> res = new List<int>();
        int p1 = 0, p2 = 0;
        while(p1 < nums1.Length && p2 < nums2.Length){
            if(nums1[p1] == nums2[p2]){
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
    public int[] Intersect(int[] nums1, int[] nums2) {
        Dictionary<int,int> map1 = new();
        Dictionary<int,int> map2 = new();
        foreach(int num in nums1){
            if(map1.ContainsKey(num))
                map1[num]++;
            else
                map1[num] = 1;
        }
        foreach(int num in nums2){
            if(map2.ContainsKey(num))
                map2[num]++;
            else
                map2[num] = 1;
        }
        List<int> result = new();
        foreach(var item in map1){
            if(map2.ContainsKey(item.Key)){
                int min = Math.Min(item.Value, map2[item.Key]);
                while(min>0){
                    result.Add(item.Key);
                    min--;
                }
            }
        }
        return result.ToArray();
    }
}