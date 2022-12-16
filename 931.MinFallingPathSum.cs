// 931. Minimum Falling Path Sum
// Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.
// A falling path starts at any element in the first row and chooses the element in the next row that is either directly below or diagonally left/right. Specifically, the next element from position (row, col) will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).
// Example 1:
// Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
// Output: 13
// Explanation: There are two falling paths with a minimum sum as shown.
// Example 2:
// Input: matrix = [[-19,57],[-40,-5]]
// Output: -59
// Explanation: The falling path with a minimum sum is shown.

public class Solution {
    int[][] dp;
    public  int MinFallingPathSum(int[][] matrix)
        {
            dp = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i] = new int[matrix[i].Length];
                Array.Fill(dp[i], Int32.MaxValue);
            }
            
            int res = Int32.MaxValue;
            for (int j = 0; j < matrix[0].Length; j++)
            {
                res = Math.Min(res, MinPath(matrix, 0, j));
            }
            return res;
        }
    public int MinPath(int[][] matrix, int r, int c)
        {
            if (dp[r][c] == Int32.MaxValue)
            {
                dp[r][c] = matrix[r][c];
                
                if (r < matrix.Length - 1) {
                    int sum = Int32.MaxValue;
                    if (c > 0)
                        sum = Math.Min(MinPath(matrix, r + 1, c - 1), sum);

                    if (c < matrix[0].Length - 1)
                        sum = Math.Min(MinPath(matrix, r + 1, c + 1), sum);
                
                    sum = Math.Min(MinPath(matrix, r + 1, c), sum);
                    dp[r][c] += sum;
                }
            }
            return dp[r][c];
        }
}