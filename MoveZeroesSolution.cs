namespace LeetCodeCSharpSolution
{
    internal class MoveZeroesSolution
    {
        //283. Move Zeroes
        //Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        //Note that you must do this in-place without making a copy of the array.

        public void MoveZeroes(int[] nums)
        {
            int count = 0;
            for (int index = 0; (index + count) < nums.Length; index++)
            {
                while ((index + count) < nums.Length && nums[index + count] == 0)
                {
                    count++;
                }
                if (index != (index + count) && index + count < nums.Length)
                {
                    nums[index] = nums[index + count];
                }
            }
            for (int index = nums.Length - count; index < nums.Length; index++)
            {
                nums[index] = 0;
            }
        }
    }
}
