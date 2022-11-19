// 54. Spiral Matrix
// Given an m x n matrix, return all elements of the matrix in spiral order.
// Example 1:
// Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
// Output: [1,2,3,6,9,8,7,4,5]
// Example 2:
// Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
// Output: [1,2,3,4,8,12,11,10,9,5,6,7]

public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        IList<int> res =new List<int>();
        int rBegin = 0,
            rEnd = matrix.Length-1,
            cBegin = 0,
            cEnd = matrix[0].Length-1;
        while(rBegin <= rEnd && cBegin <= cEnd){
            //Travese Right
            for(int i = cBegin; i <= cEnd; i++)
                res.Add(matrix[rBegin][i]);
            rBegin++;
            //Travese Down
            for(int i = rBegin; i <= rEnd; i++)
                res.Add(matrix[i][cEnd]);
            cEnd--;
            //Travese Left
            if(rBegin <= rEnd){
                for(int i = cEnd; i >= cBegin; i--)
                    res.Add(matrix[rEnd][i]);
                rEnd--;
            }
            //Travese Up
            if(cBegin <= cEnd){
                for(int i = rEnd; i >= rBegin; i--)
                    res.Add(matrix[i][cBegin]);
                cBegin++;
            }
        }
        return res;
    }
}