// 11. Container With Most Water

// You are given an integer array height of length n. 
// There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

// Find two lines that together with the x-axis form a container, such that the container contains the most water.

// Return the maximum amount of water a container can store.

// Notice that you may not slant the container.

// Example 1:
// Input: height = [1,8,6,2,5,4,8,3,7]
// Output: 49
// Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7].
// In this case, the max area of water (blue section) the container can contain is 49.
// Example 2:
// Input: height = [1,1]
// Output: 1

public class Solution {
    //intution: We can solve this problem by using two pointers.
    //We can use two pointers to iterate through the array and find the maximum area.
    //We can use the two pointers to find the maximum area by finding the minimum of the two heights
    //and the distance between the two pointers.
    //We can return the maximum area.
    //Time complexity: O(n)
    //Space complexity: O(1)
    public int MaxArea(int[] height) {
        int left = 0,
            right = height.Length -1;
        int currArea = 0,
            maxArea = 0;
        while(left < right){
            currArea = (right-left)* Math.Min(height[left],height[right]);
            maxArea = Math.Max(maxArea, currArea);
            if(height[left] <= height[right])
                left++;
            else
                right--;
        }
        return maxArea;
    }
}