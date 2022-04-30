namespace LeetCodeCSharpSolution
{
    //485. Max Consecutive Ones
    //Given a binary array nums, return the maximum number of consecutive 1's in the array.
    internal class FindMaxConsecutiveOnesSolution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max, temp;
            max = temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    temp = 0;
                }
                else
                    temp++;
                if (max < temp)
                    max = temp;
            }
            return max;
        }
    }
}
