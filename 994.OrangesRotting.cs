// 994. Rotting Oranges
// You are given an m x n grid where each cell can have one of three values:
// 0 representing an empty cell,
// 1 representing a fresh orange, or
// 2 representing a rotten orange.
// Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.
// Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.
// Example 1:
// Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
// Output: 4
// Example 2:
// Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
// Output: -1
// Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.
// Example 3:
// Input: grid = [[0,2]]
// Output: 0
// Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.

public class Solution {
    public int OrangesRotting(int[][] grid) {
        int time = 0;
        int countFresh = 0;
        int[] X = new int[]{1,-1,0,0};
        int[] Y = new int[]{0,0,1,-1};
        Queue<(int,int)> queue = new Queue<(int,int)>();
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 2)
                    queue.Enqueue((i,j));
                else if(grid[i][j] == 1)
                    countFresh++;
            }
        }
        if(countFresh == 0) return 0;
        while(queue.Count > 0){
            ++time;
            int size = queue.Count();
            while(size > 0){
                (int x, int y) = queue.Dequeue();
                for(int i = 0; i < 4; i++){
                    if(!IsValid(grid,X[i]+x,Y[i]+y))
                        continue;
                    grid[X[i]+x][Y[i]+y] = 2;
                    queue.Enqueue((X[i]+x,Y[i]+y));
                    countFresh--;
                }
                size--;
            }
        }
        
        return countFresh == 0 ? time-1 : -1;
    }
    public bool IsValid(int[][]grid, int row, int col){
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length
          || grid[row][col] == 0 || grid[row][col] == 2)
            return false;
        return true;
    }
}