//229. Majority Element II
//Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        int maj1 = nums[0];
        int maj2 = 0;
        int count1 = 1;
        int count2 = 0;

        for(int i =1; i<nums.Length; i++){
            if(maj1 == nums[i]){
                count1++;
            }
            else if(maj2 == nums[i]){
                count2++;
            }
            else if(count1 == 0)
            {
                maj1 = nums[i];
                count1++;
            }
            else if(count2 == 0){
                maj2 = nums[i];
                count2++;
            }
            else{
                count1--;
                count2--;
            }
        }
        IList<int> result = new List<int>();
        count1=0;
        count2=0;
        for(int i = 0; i < nums.Length; i++){
            if(maj1==nums[i]){
                count1++;
            }
            else if(maj2 == nums[i]){
                count2++;
            }
        }
        if(count1 > nums.Length/3)
            result.Add(maj1);
        if(count2 > nums.Length/3)
            result.Add(maj2);
        
        return result;
    }
}