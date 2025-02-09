// 329. Longest Increasing Path in a Matrix
// Given an m x n integers matrix, return the length of the longest increasing path in matrix.
// From each cell, you can either move in four directions: left, right, up, or down. You may not move diagonally or move 
// outside the boundary (i.e., wrap-around is not allowed).

// Example 1:
// Input: matrix = [[9,9,4],[6,6,8],[2,1,1]]
// Output: 4
// Explanation: The longest increasing path is [1, 2, 6, 9].

// Example 2:
// Input: matrix = [[3,4,5],[3,2,6],[2,2,1]]
// Output: 4
// Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.

// Example 3:
// Input: matrix = [[1]]
// Output: 1

// Constraints:

// m == matrix.length
// n == matrix[i].length
// 1 <= m, n <= 200
// 0 <= matrix[i][j] <= 231 - 1


//Time Complexity: O(m×n) due to memoization.
//Space Complexity: O(m×n) for memoization and recursion stack.
public class Solution
{
    public int LongestIncreasingPath(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[,] visited = new int[rows, cols]; // Memoization for caching results
        int result = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result = Math.Max(result, FindPath(matrix, i, j, visited));
            }
        }

        return result;
    }

    private int FindPath(int[][] matrix, int i, int j, int[,] visited)
    {
        if (visited[i, j] != 0) return visited[i, j]; // Return cached value if already computed

        int[,] dir = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
        int max = 0;

        for (int k = 0; k < 4; k++)
        {
            int r = i + dir[k, 0], c = j + dir[k, 1];

            if (IsValid(r, c, matrix) && matrix[r][c] > matrix[i][j])
            {
                max = Math.Max(max, FindPath(matrix, r, c, visited));
            }
        }

        visited[i, j] = 1 + max;
        return visited[i, j];
    }

    private bool IsValid(int i, int j, int[][] matrix)
    {
        return i >= 0 && j >= 0 && i < matrix.Length && j < matrix[0].Length;
    }
}
