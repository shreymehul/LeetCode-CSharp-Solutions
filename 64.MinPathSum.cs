// 64. Minimum Path Sum

// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

// Note: You can only move either down or right at any point in time.

 

// Example 1:


// Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
// Output: 7
// Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
// Example 2:

// Input: grid = [[1,2,3],[4,5,6]]
// Output: 12

public class Solution {
    int[,] visited = new int[200, 200];
    public int MinPathSum(int[][] grid)
    {
        for(int i=0;i< grid.Length; i++)
        {
            for(int j = 0;j< grid[0].Length; j++)
            {
                visited[i,j] = -1;
            }
        }
        return PathSum(grid, 0, 0);
    }
    public int PathSum(int[][] grid, int i, int j)
    {
        if (visited[i, j] > -1)
            return visited[i, j];
        int result;
        if (i == grid.Length - 1 && j == grid[0].Length - 1)
            result = grid[i][j];
        else if (i == grid.Length - 1)
            result =  grid[i][j] + PathSum(grid, i, j + 1);
        else if (j == grid[0].Length - 1)
            result = grid[i][j] + PathSum(grid, i + 1, j);
        else
            result =  grid[i][j] + Math.Min(PathSum(grid, i+1, j), PathSum(grid, i, j + 1));
        visited[i,j] = result;
        return result;
    }
}