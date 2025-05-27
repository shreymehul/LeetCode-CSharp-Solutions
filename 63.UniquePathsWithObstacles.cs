// 63. Unique Paths II

// You are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). 
// The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right
//  at any point in time.
// An obstacle and space are marked as 1 or 0 respectively in grid. A path that the robot takes cannot include any square 
// that is an obstacle.
// Return the number of possible unique paths that the robot can take to reach the bottom-right corner.
// The testcases are generated so that the answer will be less than or equal to 2 * 109.

// Example 1:
// Input: obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
// Output: 2
// Explanation: There is one obstacle in the middle of the 3x3 grid above.
// There are two ways to reach the bottom-right corner:
// 1. Right -> Right -> Down -> Down
// 2. Down -> Down -> Right -> Right
// Example 2:
// Input: obstacleGrid = [[0,1],[0,0]]
// Output: 1

// Constraints:
// m == obstacleGrid.length
// n == obstacleGrid[i].length
// 1 <= m, n <= 100
// obstacleGrid[i][j] is 0 or 1.

//TLE
public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        return Traverse(obstacleGrid, 0, 0);
    }
    public int Traverse(int[][] obstacleGrid, int r, int c)
    {
        if (r >= obstacleGrid.Length || c >= obstacleGrid[0].Length
            || obstacleGrid[r][c] == 1)
            return 0;
        if (r == obstacleGrid.Length - 1 && c == obstacleGrid[0].Length - 1)
            return 1;
        return Traverse(obstacleGrid, r + 1, c) + Traverse(obstacleGrid, r, c + 1);
    }
}

//dp
public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        int[,] dp = new int[m, n];

        // Initialize dp with -1 to indicate unvisited
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                dp[i, j] = -1;

        return Traverse(obstacleGrid, 0, 0, dp);
    }

    private int Traverse(int[][] grid, int r, int c, int[,] dp)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Out of bounds or obstacle
        if (r >= m || c >= n || grid[r][c] == 1) return 0;

        // Reached bottom-right
        if (r == m - 1 && c == n - 1) return 1;

        // Already computed
        if (dp[r, c] != -1) return dp[r, c];

        // Memoize paths from down and right
        dp[r, c] = Traverse(grid, r + 1, c, dp) + Traverse(grid, r, c + 1, dp);
        return dp[r, c];
    }
}
