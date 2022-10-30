// 56. Merge Intervals

// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

// Example 1:

// Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
// Output: [[1,6],[8,10],[15,18]]
// Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
// Example 2:

// Input: intervals = [[1,4],[4,5]]
// Output: [[1,5]]
// Explanation: Intervals [1,4] and [4,5] are considered overlapping.

public class Solution {
    public int[][] Merge(int[][] intervals) {
        if(intervals == null || intervals.Length == 0 || intervals.Length == 1)
            return intervals;
        intervals = intervals.OrderBy( x => x[0]).ToArray();
        List<int[]> result = new List<int[]>();
        
        int start = intervals[0][0],
            end = intervals[0][1];
        for(int i = 1; i < intervals.Length; i++){
            if(intervals[i][0] > end){
                result.Add(new int[]{start,end});
                start = intervals[i][0];
                end = intervals[i][1];
            }
            else{
                end = Math.Max(end,intervals[i][1]);
            }
        }
        result.Add(new int[]{start,end});
        
        return result.ToArray();
    }
}