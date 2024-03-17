// 73. Set Matrix Zeroes

// Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.
// You must do it in place.

// Example 1:
// Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
// Output: [[1,0,1],[0,0,0],[1,0,1]]
// Example 2:
// Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
// Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]

public class Solution {
    public void SetZeroes(int[][] matrix) {
        int[] row = new int[matrix.Length];
        int[] col = new int[matrix[0].Length];
        for(int i = 0; i < matrix.Length; i++){
           for(int j = 0; j < matrix[0].Length; j++){
                if(matrix[i][j] == 0){
                    row[i] = 1;
                    col[j] = 1;
                }
            } 
        }
        for(int i = 0; i < matrix.Length; i++){
           for(int j = 0; j < matrix[0].Length; j++){
                if(row[i] == 1 || col[j] == 1)
                    matrix[i][j] = 0;
           }
        }
    }
}



public class Solution {
    public void SetZeroes(int[][] matrix) {
        bool[] row = new bool[matrix.Length];
        bool[] col = new bool[matrix[0].Length];
        for(int i = 0; i < matrix.Length; i++){
            for(int j = 0; j < matrix[i].Length; j++){
                if(matrix[i][j] == 0){
                    row[i] = true;
                    col[j] = true;
                }
            }
        }
        for(int i = 0; i < matrix.Length; i++){
            if(row[i]){
                for(int j = 0; j < matrix[i].Length; j++){
                    matrix[i][j] = 0;
                }
            }
        }
        for(int j = 0; j < matrix[0].Length; j++){
            if(col[j]){
                for(int i = 0; i < matrix.Length; i++){
                    matrix[i][j] = 0;
                }
            }
        }
    }
}