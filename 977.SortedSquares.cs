//977. Squares of a Sorted Array
//Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        int[] sq = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            sq[i] = nums[i] * nums[i];
        }
        Array.Sort(sq);
        return sq;
    }
}