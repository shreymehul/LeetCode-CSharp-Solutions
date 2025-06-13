// 695. Max Area of Island

// You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally 
// (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.
// The area of an island is the number of cells with a value 1 in the island.
// Return the maximum area of an island in grid. If there is no island, return 0.

// Example 1:
// Input: grid = [[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],
// [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],
// [0,0,0,0,0,0,0,1,1,0,0,0,0]]
// Output: 6
// Explanation: The answer is not 11, because the island must be connected 4-directionally.
// Example 2:
// Input: grid = [[0,0,0,0,0,0,0,0]]
// Output: 0


public class Solution {
    bool[,] visited = new bool[300, 300];
    public int MaxAreaOfIsland(int[][] grid) {
        int max = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1 && !visited[i, j])
                {
                    max = Math.Max(FindConectedPath(grid, i, j),max);
                }
            }
        }
        return max;
    }
    public int FindConectedPath(int[][] grid, int i, int j)
    {
        if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length ||
            grid[i][j] == 0 || visited[i, j])
        {
            return 0;
        }

        visited[i, j] = true;
        return 1 +
        FindConectedPath(grid, i + 1, j) +
        FindConectedPath(grid, i - 1, j) +
        FindConectedPath(grid, i, j - 1) +
        FindConectedPath(grid, i, j + 1);
    }
}