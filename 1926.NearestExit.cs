// 1926. Nearest Exit from Entrance in Maze
// You are given an m x n matrix maze (0-indexed) with empty cells (represented as '.') and walls (represented as '+'). You are also given the entrance of the maze, where entrance = [entrancerow, entrancecol] denotes the row and column of the cell you are initially standing at.
// In one step, you can move one cell up, down, left, or right. You cannot step into a cell with a wall, and you cannot step outside the maze. Your goal is to find the nearest exit from the entrance. An exit is defined as an empty cell that is at the border of the maze. The entrance does not count as an exit.
// Return the number of steps in the shortest path from the entrance to the nearest exit, or -1 if no such path exists.
// Example 1:
// Input: maze = [["+","+",".","+"],[".",".",".","+"],["+","+","+","."]], entrance = [1,2]
// Output: 1
// Explanation: There are 3 exits in this maze at [1,0], [0,2], and [2,3].
// Initially, you are at the entrance cell [1,2].
// - You can reach [1,0] by moving 2 steps left.
// - You can reach [0,2] by moving 1 step up.
// It is impossible to reach [2,3] from the entrance.
// Thus, the nearest exit is [0,2], which is 1 step away.
// Example 2:
// Input: maze = [["+","+","+"],[".",".","."],["+","+","+"]], entrance = [1,0]
// Output: 2
// Explanation: There is 1 exit in this maze at [1,2].
// [1,0] does not count as an exit since it is the entrance cell.
// Initially, you are at the entrance cell [1,0].
// - You can reach [1,2] by moving 2 steps right.
// Thus, the nearest exit is [1,2], which is 2 steps away.
// Example 3:
// Input: maze = [[".","+"]], entrance = [0,0]
// Output: -1
// Explanation: There are no exits in this maze.

public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) {
        int[] dX = new int[]{1,-1,0,0};
        int[] dY = new int[]{0,0,-1,1};
        Queue<(int,int)> q = new Queue<(int,int)>();
        q.Enqueue((entrance[0],entrance[1]));
        maze[entrance[0]][entrance[1]] = '*';
        int level = 0;
        while(q.Count() > 0){
            int count = q.Count();
            for(int j = 0; j < count; j++){
                (int x, int y) = q.Dequeue();
                for(int i = 0; i < 4; i++){
                    if(!IsValid(maze,x+dX[i],y+dY[i]))
                        continue;
                    if(IsExit(maze,x+dX[i],y+dY[i]))
                        return level+1;
                    q.Enqueue((x+dX[i],y+dY[i]));
                    maze[x+dX[i]][y+dY[i]] = '*';
                }
            }
            level++;
        }
        return -1;
    }
    public bool IsExit(char[][] maze, int row, int col){
        if(row == 0 || col == 0 || row == maze.Length-1 || col == maze[0].Length-1)
            return true;
        return false;       
    }
    public bool IsValid(char[][] maze, int row, int col){
        if(row < 0 || col < 0 || row == maze.Length || col == maze[0].Length
          || maze[row][col] != '.')
            return false;
        return true;       
    }
}