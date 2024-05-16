// 1219. Path with Maximum Gold 
// In a gold mine grid of size m x n, each cell in this mine has an integer representing the amount of gold in that cell, 0 if it is empty.

// Return the maximum amount of gold you can collect under the conditions:

// Every time you are located in a cell you will collect all the gold in that cell.
// From your position, you can walk one step to the left, right, up, or down.
// You can't visit the same cell more than once.
// Never visit a cell with 0 gold.
// You can start and stop collecting gold from any position in the grid that has some gold.

// Example 1:
// Input: grid = [[0,6,0],[5,8,7],[0,9,0]]
// Output: 24
// Explanation:
// [[0,6,0],
//  [5,8,7],
//  [0,9,0]]
// Path to get the maximum gold, 9 -> 8 -> 7.
// Example 2:
// Input: grid = [[1,0,7],[2,0,6],[3,4,5],[0,3,0],[9,0,20]]
// Output: 28
// Explanation:
// [[1,0,7],
//  [2,0,6],
//  [3,4,5],
//  [0,3,0],
//  [9,0,20]]
// Path to get the maximum gold, 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7.

// Constraints:
// m == grid.length
// n == grid[i].length
// 1 <= m, n <= 15
// 0 <= grid[i][j] <= 100
// There are at most 25 cells containing gold.

public class Solution {
    bool[,] visited;
    public int GetMaximumGold(int[][] grid) {
        visited = new bool[grid.Length,grid[0].Length];
        int max = 0;
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                    if(grid[i][j] != 0){
                        int points = Iterate(grid, i, j);
                        max = Math.Max(max,points);
                    }
            }
        }
        return max;
    }
    private bool ValidPath(int[][] grid, int i, int j){
        if(i < 0 || i >= grid.Length || 
            j < 0 || j >= grid[i].Length || grid[i][j] == 0
            || visited[i,j] )
            return false;
        return true;
    }
    private int Iterate(int[][] grid, int i, int j){
        if(!ValidPath(grid, i, j))
            return 0;
        visited[i,j] = true;
        int max =0;
        max = Math.Max(max, Iterate(grid, i-1, j));
        max = Math.Max(max, Iterate(grid, i+1, j));
        max = Math.Max(max, Iterate(grid, i, j-1));
        max = Math.Max(max, Iterate(grid, i, j+1));
        max += grid[i][j];
        visited[i,j] = false;
        return max;
    }
}