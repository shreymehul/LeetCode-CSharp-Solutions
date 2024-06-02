// 52. N-Queens II
// The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
// Given an integer n, return the number of distinct solutions to the n-queens puzzle.
// Example 1:
// Input: n = 4
// Output: 2
// Explanation: There are two distinct solutions to the 4-queens puzzle as shown.
// Example 2:
// Input: n = 1
// Output: 1

// Constraints:
// 1 <= n <= 9

public class Solution {
    public int TotalNQueens(int n) {
       List<IList<String>> result = new List<IList<String>>();
        List<String> board = new List<String>();
        for(int i = 0; i<n; i++){
            StringBuilder row = new StringBuilder("");
            for(int j = 0; j < n; j++)
                row.Append(".");
            board.Add(row.ToString());
        }
        PlaceQueen(result, board,0);
        return result.Count;
    }
    private void PlaceQueen(List<IList<String>> result, List<String> board,
        int rowIdx)
        {
            if(rowIdx == board.Count){
                result.Add(new List<String>(board));
                return;
            }
            for(int i = 0; i < board.Count; i++){
                if(IsSafe(board, rowIdx, i)){
                    StringBuilder newRow = new StringBuilder(board[rowIdx]);
                    newRow[i] = 'Q';
                    board[rowIdx] = newRow.ToString();
                    PlaceQueen(result, board, rowIdx+1);
                    newRow[i] = '.';
                    board[rowIdx] = newRow.ToString();
                }
            }
        }
    private bool IsSafe(List<String> board, int row, int col){
        for(int i = row; i >= 0; i--){
            if(board[i][col] == 'Q')
                return false;
        }
        for(int i = row, j = col; i >= 0 && j >= 0; i--, j--){
            if(board[i][j] == 'Q')
                return false;
        }
        for(int i = row, j = col; i >= 0 && j < board.Count; i--, j++){
            if(board[i][j] == 'Q')
                return false;
        }
        return true;
    }
}