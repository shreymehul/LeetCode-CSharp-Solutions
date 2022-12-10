// 1207. Unique Number of Occurrences
// Given an array of integers arr, return true if the number of occurrences of each value in the array is unique or false otherwise.
// Example 1:
// Input: arr = [1,2,2,1,1,3]
// Output: true
// Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.
// Example 2:
// Input: arr = [1,2]
// Output: false
// Example 3:
// Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
// Output: true

public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        foreach(var item in arr){
            if(map.ContainsKey(item))
                map[item]++;
            else
                map[item] = 1;
        }
        HashSet<int> hs = new HashSet<int>();
        foreach(var item in map){
            if(hs.Contains(item.Value))
                return false;
            hs.Add(item.Value);
        }
        return true;
    }
}