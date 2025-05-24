// 119. Pascal's Triangle II
// Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.
// In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:


// Example 1:
// Input: rowIndex = 3
// Output: [1,3,3,1]
// Example 2:
// Input: rowIndex = 0
// Output: [1]
// Example 3:
// Input: rowIndex = 1
// Output: [1,1]

// Constraints:
// 0 <= rowIndex <= 33


public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        IList<int> pascalT = new List<int> { 1 };
        long prev = 1;
        for (int i = 1; i < rowIndex + 1; i++)
        {
            long next = prev * (rowIndex - i + 1) / i;
            pascalT.Add((int)next);
            prev = next;
        }
        return pascalT;
    }
}
//https://youtu.be/BY95fxcrjag