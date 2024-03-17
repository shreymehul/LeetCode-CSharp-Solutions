// 56. Merge Intervals

// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an 
// array of the non-overlapping intervals that cover all the intervals in the input.

// Example 1:

// Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
// Output: [[1,6],[8,10],[15,18]]
// Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
// Example 2:

// Input: intervals = [[1,4],[4,5]]
// Output: [[1,5]]
// Explanation: Intervals [1,4] and [4,5] are considered overlapping.

//Approch 1
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

//Approch 2
public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int[]> result = new();
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));
        result.Add(intervals[0]);
        for(int i = 1; i < intervals.Length; i++){
            if(result[result.Count-1][1] >= intervals[i][0]){
                if(result[result.Count-1][1] < intervals[i][1])
                    result[result.Count-1][1] = intervals[i][1];
            }
            else{
                result.Add(intervals[i]);
            }
        }
        return result.ToArray();
    }
}

//Approch 3
public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int[][] result = new int[intervals.Length][];
        int j = 0;
        for(int i = 0; i < intervals.Length; i++){
            int k = i + 1;
            int end = intervals[i][1];
            while(k < intervals.Length &&
                    intervals[k][0] <= end){
                end = Math.Max(end, intervals[k][1]);
                k++;
            }
            result[j++] = new int[2]{intervals[i][0], end};
            i = k - 1;
        }
        Array.Resize(ref result, j);
        return result;
    }
}