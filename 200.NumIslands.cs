// 200. Number of Islands

// Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

 

// Example 1:

// Input: grid = [
//   ["1","1","1","1","0"],
//   ["1","1","0","1","0"],
//   ["1","1","0","0","0"],
//   ["0","0","0","0","0"]
// ]
// Output: 1
// Example 2:

// Input: grid = [
//   ["1","1","0","0","0"],
//   ["1","1","0","0","0"],
//   ["0","0","1","0","0"],
//   ["0","0","0","1","1"]
// ]
// Output: 3

public class Solution {
    bool[,] visited = new bool[300,300];
    public int NumIslands(char[][] grid)
    {
        
        int count=0;
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1' && !visited[i,j])
                {
                    FindConectedPath(grid, i, j);
                    count++;
                }
            }
        }
        return count;
    }
    public void FindConectedPath(char[][] grid, int i,int j)
    {
        if (i<0 ||j<0 || i>=grid.Length|| j >= grid[0].Length ||
            grid[i][j] == '0' || visited[i,j])
        {
            return;
        }
        
        visited[i,j] = true;
        FindConectedPath(grid, i + 1, j);
        FindConectedPath(grid, i -1, j);
        FindConectedPath(grid, i , j-1);
        FindConectedPath(grid, i, j+1);
    }
}