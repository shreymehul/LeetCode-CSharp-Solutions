// 980. Unique Paths III

// You are given an m x n integer array grid where grid[i][j] could be:
// 1 representing the starting square. There is exactly one starting square.
// 2 representing the ending square. There is exactly one ending square.
// 0 representing empty squares we can walk over.
// -1 representing obstacles that we cannot walk over.
// Return the number of 4-directional walks from the starting square to the ending square, that walk over every non-obstacle square exactly once.
// Example 1:
// Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,2,-1]]
// Output: 2
// Explanation: We have the following two paths: 
// 1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2)
// 2. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2)
// Example 2:
// Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,0,2]]
// Output: 4
// Explanation: We have the following four paths: 
// 1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2),(2,3)
// 2. (0,0),(0,1),(1,1),(1,0),(2,0),(2,1),(2,2),(1,2),(0,2),(0,3),(1,3),(2,3)
// 3. (0,0),(1,0),(2,0),(2,1),(2,2),(1,2),(1,1),(0,1),(0,2),(0,3),(1,3),(2,3)
// 4. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2),(2,3)
// Example 3:
// Input: grid = [[0,1],[2,0]]
// Output: 0
// Explanation: There is no path that walks over every empty square exactly once.
// Note that the starting and ending square can be anywhere in the grid.
// Constraints:
// m == grid.length
// n == grid[i].length
// 1 <= m, n <= 20
// 1 <= m * n <= 20
// -1 <= grid[i][j] <= 2
// There is exactly one starting cell and one ending cell.

public class Solution {
    bool[][] visited;
    int count;
    public int UniquePathsIII(int[][] grid) {
        visited = new bool[grid.Length][];
        count = 0;
        for(int i = 0; i < grid.Length; i++)
            visited[i] = new bool[grid[i].Length];

        for(int i = 0; i< grid.Length; i++){
            for(int j = 0 ;j < grid[i].Length; j++){
                if(grid[i][j] == 1){
                    Traverse(grid,i,j);
                    return count;
                }
            }
        }
        return count;
    }
    public void Traverse(int[][] grid, int row, int col){
        if(row < 0 || col < 0 || row == grid.Length || col == grid[0].Length
            || visited[row][col] || grid[row][col] == -1 )
            return;
        if(grid[row][col] == 2){
            if(IsValidPath(grid))
                count++;
            return;
        }
        visited[row][col] = true;
        Traverse(grid,row+1,col);
        Traverse(grid,row-1,col);
        Traverse(grid,row,col+1);
        Traverse(grid,row,col-1);
        visited[row][col] = false;
    }
    public bool IsValidPath(int[][] grid){
        for(int i = 0; i< grid.Length; i++){
            for(int j = 0 ;j < grid[i].Length; j++){
                if(grid[i][j] == 0 && !visited[i][j]){
                    return false;
                }
            }
        }
        return true;
    }
}