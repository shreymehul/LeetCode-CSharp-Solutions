// 59. Spiral Matrix II
// Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.
// Example 1:
// Input: n = 3
// Output: [[1,2,3],[8,9,4],[7,6,5]]
// Example 2:
// Input: n = 1
// Output: [[1]]

public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] matrix = new int[n][];
        for(int i = 0;i < n; i++){
            matrix[i] = new int[n];
        }
        int rBegin = 0,
            rEnd = matrix.Length-1,
            cBegin = 0,
            cEnd = matrix[0].Length-1;
        int num = 1;
        while(rBegin <= rEnd && cBegin <= cEnd){
            //Right
            for(int i = cBegin; i <= cEnd; i++)
                matrix[rBegin][i] = num++;
            rBegin++;
            //Down
            for(int i = rBegin; i <= rEnd; i++)
                matrix[i][cEnd] = num++;
            cEnd--;
            //Left
            if(rBegin <= rEnd){
                for(int i = cEnd; i >= cBegin; i--)
                    matrix[rEnd][i] = num++;
                rEnd--;
            }
            //Up
            if(cBegin <= cEnd){
                for(int i = rEnd; i >= rBegin; i--)
                    matrix[i][cBegin] = num++;
                cBegin++;
            }
        }
        return matrix;
    }
}