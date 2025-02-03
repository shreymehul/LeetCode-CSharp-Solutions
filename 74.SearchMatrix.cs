// 74. Search a 2D Matrix
// Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. 
// This matrix has the following properties:

// Integers in each row are sorted from left to right.
// The first integer of each row is greater than the last integer of the previous row.
 

 public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        return Search(matrix,target,0,matrix[0].Length-1);
    }
    
    public bool Search(int[][] ar, int target, int row, int col){
        if(target == ar[row][col])
            return true;
        if(target > ar[row][col]){
            if(row + 1 < ar.Length)
                return Search(ar,target,row+1,col);
            else
                return false;
        }
        else{
            if(col-1 > -1)
                return Search(ar,target,row,col-1);
            else
                return false;
        }
    }
}