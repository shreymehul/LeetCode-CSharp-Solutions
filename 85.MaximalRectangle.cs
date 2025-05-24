// 85. Maximal Rectangle

// Given a rows x cols binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

// Example 1:
// Input: matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
// Output: 6
// Explanation: The maximal rectangle is shown in the above picture.
// Example 2:
// Input: matrix = [["0"]]
// Output: 0
// Example 3:
// Input: matrix = [["1"]]
// Output: 1

// Constraints:
// rows == matrix.length
// cols == matrix[i].length
// 1 <= row, cols <= 200
// matrix[i][j] is '0' or '1'.


public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        // Edge case check
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            return 0;

        int m = matrix.Length, n = matrix[0].Length;
        
        // map[i, j] = [up, down, left, right] bounds for a rectangle starting at (i, j)
        int[,][] map = new int[m, n][];

        // Step 1: Initialize each map cell with default values (pointing to itself)
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                map[i, j] = new int[] { i, i, j, j };
            }
        }

        // Step 2: Fill in left and right bounds for each row
        for (int i = 0; i < m; i++) {
            int left = 0;
            while (left < n) {
                // Skip '0's
                while (left < n && matrix[i][left] == '0') left++;

                int right = left;
                // Find contiguous stretch of '1's
                while (right < n && matrix[i][right] == '1') right++;

                // Set left and right bounds for this block of '1's
                for (int k = left; k < right; k++) {
                    map[i, k][2] = left;      // left bound
                    map[i, k][3] = right - 1; // right bound (inclusive)
                }

                left = right; // move to next segment
            }
        }

        // Step 3: Fill in up and down bounds for each column
        for (int j = 0; j < n; j++) {
            int top = 0;
            while (top < m) {
                // Skip '0's
                while (top < m && matrix[top][j] == '0') top++;

                int bottom = top;
                // Find contiguous stretch of '1's
                while (bottom < m && matrix[bottom][j] == '1') bottom++;

                // Set up and down bounds for this block of '1's
                for (int k = top; k < bottom; k++) {
                    map[k, j][0] = top;       // up bound
                    map[k, j][1] = bottom - 1; // down bound (inclusive)
                }

                top = bottom; // move to next segment
            }
        }

        int maxArea = 0;

        // Step 4: For each cell that contains '1', try to expand upward and calculate max area
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == '1') {
                    int top = i;
                    int left = map[i, j][2];   // initial left bound
                    int right = map[i, j][3];  // initial right bound

                    // Try expanding upward row by row, tightening the left-right width
                    for (int k = i; k >= map[i, j][0]; k--) {
                        // Take the intersection of column bounds for consistent rectangle
                        left = Math.Max(left, map[k, j][2]);
                        right = Math.Min(right, map[k, j][3]);

                        // Calculate current area with height = i - k + 1
                        int area = (i - k + 1) * (right - left + 1);
                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }
        }

        return maxArea;
    }
}

//optimised:
public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0)
            return 0;

        int m = matrix.Length;
        int n = matrix[0].Length;
        int[] heights = new int[n]; // histogram heights
        int maxArea = 0;

        for (int i = 0; i < m; i++) {
            // Step 1: Build heights histogram for current row
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == '1')
                    heights[j] += 1;
                else
                    heights[j] = 0;
            }

            // Step 2: Calculate max rectangle in histogram
            maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
        }

        return maxArea;
    }

    // Helper function to compute largest rectangle in histogram
    private int LargestRectangleArea(int[] heights) {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        int[] extended = new int[heights.Length + 1]; // Append 0 to flush stack
        heights.CopyTo(extended, 0);

        for (int i = 0; i < extended.Length; i++) {
            while (stack.Count > 0 && extended[i] < extended[stack.Peek()]) {
                int height = extended[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }
            stack.Push(i);
        }

        return maxArea;
    }
}
// Time Complexity:
// O(m * n) where m = rows, n = columns.

// Core Idea:
// For each row, maintain a heights[] array — like in a histogram.
// If matrix[i][j] == '1': increase height by 1.
// Else: reset height to 0.
// At each row, compute largest rectangle in histogram using a monotonic stack.
// Keep track of the maximum area.