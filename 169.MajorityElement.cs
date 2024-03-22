//169. Majority Element
// Given an array nums of size n, return the majority element.

// The majority element is the element that appears more than ⌊n / 2⌋ times.
// You may assume that the majority element always exists in the array.

//Moor's Voting Algorithm
//Time Complexity: O(n)
//Space Complexity: O(1)
public class Solution {
    public int MajorityElement(int[] nums) {
        int count = 1;
        int candidate = nums[0];
        //Find the candidate for majority element using Moore's Voting Algorithm
        for(int i = 1; i < nums.Length; i++){
            //If the current element is the same as the candidate, then increment the count
            if(nums[i] == candidate)
                count++;
            else{
                //If the current element is different from the candidate, then decrement the count
                count--;
                if(count == 0){
                    //If the count is 0, then the current element is the candidate for majority element
                    candidate = nums[i];
                    count = 1;
                }
            }
        }
        
        return candidate;
    }
}

//HashMap
//Time Complexity: O(n)
//Space Complexity: O(n)
public class Solution {
    public int MajorityElement(int[] nums) {
        Dictionary<int,int> Counter = new();
        //Count the frequency of each element
        for(int i = 0; i < nums.Length; i++){
            if(Counter.ContainsKey(nums[i]))
                Counter[nums[i]]++;
            else
                Counter[nums[i]] = 1;
        }
        //Return the element with the maximum frequency
        return Counter.MaxBy(x => x.Value).Key;
    }
}