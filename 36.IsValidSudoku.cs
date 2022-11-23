// Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

// Each row must contain the digits 1-9 without repetition.
// Each column must contain the digits 1-9 without repetition.
// Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
// Note:

// A Sudoku board (partially filled) could be valid but is not necessarily solvable.
// Only the filled cells need to be validated according to the mentioned rules.

public class Solution {
    public bool IsValidSudoku(char[][] board)
    {
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] >= '0' && board[i][j] <= '9')
                {
                    bool isValid = CheckRow(board,i,j) &&
                        CheckCol(board,i,j) && CheckBox(board,i,j);
                    if (!isValid)
                        return isValid;
                }
            }
        }
        return true;
    }
    public bool CheckRow(char[][] board, int row,int col)
    {
        for(int i=0; i < board.Length; i++)
        {
            if(i!=row && board[i][col] == board[row][col])
            {
                return false;
            }
        }
        return true;
    }
    public bool CheckCol(char[][] board, int row, int col)
    {
        for (int j = 0; j < board.Length; j++)
        {
            if (j != col && board[row][j] == board[row][col])
            {
                return false;
            }
        }
        return true;
    }
    public bool CheckBox(char[][] board, int row, int col)
    {
        int rowBase = (row/3)*3;
        int colBase = (col/3)*3;
        for (int i = rowBase; i < rowBase+3; i++)
        {
            for (int j = colBase; j < colBase +3; j++)
            {
                if (i!=row && j != col && board[i][j] == board[row][col])
                {
                    return false;
                }
            }
        }
        return true;
    }
}

//HasSet
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        HashSet<int>[] row = new HashSet<int>[9]; 
        HashSet<int>[] col = new HashSet<int>[9]; 
        HashSet<int>[] box = new HashSet<int>[9]; 
        for(int i = 0; i < 9; i++){
            row[i] = new HashSet<int>();
            col[i] = new HashSet<int>();
            box[i] = new HashSet<int>();
        }
        for(int i = 0; i < 9; i++){
            for(int j = 0; j < 9; j++){
                if(board[i][j] != '.'){
                    int val = board[i][j] - '0';
                    if(!row[i].Contains(val) && !col[j].Contains(val) 
                      && !box[(i/3)*3 + (j/3)].Contains(val)) {
                        row[i].Add(val);
                        col[j].Add(val);
                        box[(i/3)*3 + (j/3)].Add(val);
                    }
                    else{
                        return false;
                    }
                }
            }
        }
        return true;
    }
}