// 118. Pascal's Triangle

// Given an integer numRows, return the first numRows of Pascal's triangle.

// In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

// Example 1:
// Input: numRows = 5
// Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
// Example 2:
// Input: numRows = 1
// Output: [[1]]

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> result = new List<IList<int>>();
            for (int i = 1; i <= numRows; i++)
            {
                int[] rList = new int[i];
                rList[0] = rList[i - 1] = 1;
                int mid = i / 2;
                for (int j = 1; j <= mid && i > 2; j++)
                {
                    rList[j] = result[i - 2][j - 1] + result[i - 2][j];
                    rList[i - j - 1] = rList[j];
                }
                result.Add(rList);
            }
            return result;
    }
}