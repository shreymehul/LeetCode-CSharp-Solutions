// 120. Triangle
// Given a triangle array, return the minimum path sum from top to bottom.
// For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
// Example 1:
// Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
// Output: 11
// Explanation: The triangle looks like:
//    2
//   3 4
//  6 5 7
// 4 1 8 3
// The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).
// Example 2:
// Input: triangle = [[-10]]
// Output: -10

//Approch1 TLE
public class Solution {
    int[,] PathSum;
    public int MinimumTotal(IList<IList<int>> triangle) {
        PathSum = new int[triangle.Count,triangle.Count];
        //Array.Fill(PathSum,Int32.MinValue);
        return pathSum(triangle, 0, 0);
    }
    public int pathSum(IList<IList<int>> triangle, int idx, int n){
        if(n >= triangle.Count)
            return 0;
        if(PathSum[n,idx] == 0){
            int sum1 = pathSum(triangle, idx, n+1);
            int sum2 = pathSum(triangle, idx+1, n+1);
            PathSum[n,idx] = triangle[n][idx] + Math.Min(sum1,sum2);
        }
        return PathSum[n,idx];
    }
}

//Approch2
public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int[][] PathSum = triangle.Select(a => a.ToArray()).ToArray();
        for(int i = PathSum.Length-2; i >= 0; i--){
            for(int j = 0; j <= i; j++)
                PathSum[i][j] += Math.Min(PathSum[i+1][j],PathSum[i+1][j+1]);
        }
        return PathSum[0][0];
    }
}