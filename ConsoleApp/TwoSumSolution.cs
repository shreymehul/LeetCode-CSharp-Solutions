namespace LeetCodeCSharpSolution
{
    internal class TwoSumSolution
    {
        //1. Two Sum
        //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        //You may assume that each input would have exactly one solution, and you may not use the same element twice.
        //You can return the answer in any order.
        
        public int[] TwoSum(int[] nums, int target)
        {
            int[] indices = new int[2];
            int flag = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        indices[0] = i;
                        indices[1] = j;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                    break;
            }
            return indices;
        }
    }
}
