// 42. Trapping Rain Water

// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it 
// can trap after raining.

// Example :
// Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
// Output: 6
// Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water 
// (blue section) are being trapped.
// Example 2:
// Input: height = [4,2,0,3,2,5]
// Output: 9

// Constraints:
// n == height.length
// 1 <= n <= 2 * 104
// 0 <= height[i] <= 105

//Prefix Sum
//Space O(n) Time O(n)
public class Solution
{
    public int Trap(int[] height)
    {
        int[] maxleft = new int[height.Length];
        int[] maxright = new int[height.Length];
        int res = 0;
        maxleft[0] = height[0];
        maxright[height.Length - 1] = height[height.Length - 1];
        for (int i = 1; i < height.Length; i++)
        {
            maxleft[i] = Math.Max(maxleft[i - 1], height[i]);
        }
        for (int i = height.Length - 2; i >= 0; i--)
        {
            maxright[i] = Math.Max(maxright[i + 1], height[i]);
        }
        for (int i = 0; i < height.Length; i++)
        {
            res += Math.Min(maxleft[i], maxright[i]) - height[i];
        }
        return res;
    }
}

//Two pointer
//Space O(1) Time O(n)
public class Solution {
    public int Trap(int[] height) {
        int leftMax = height[0], rightMax = height[^1];
        int left = 0, right = height.Length -1;
        int water = 0;
        while(left < right){
            if(leftMax < rightMax){
                water += leftMax - height[left];
                left++;
                leftMax = Math.Max(leftMax, height[left]);
            }
            else{
                water += rightMax - height[right];
                right--;
                rightMax = Math.Max(rightMax, height[right]);
            }
        }
        return water;
    }
}

public class Solution {
    public int Trap(int[] height) {
        int leftMax = 0, rightMax = 0;        // Track max heights from left and right
        int left = 0, right = height.Length - 1; // Two pointers starting from both ends
        int water = 0;                        // Total water trapped

        // Traverse until the two pointers meet
        while (left < right) {
            if (height[left] < height[right]) {
                // Left side is smaller ⇒ potential to trap water is bounded by leftMax
                if (leftMax > height[left]) {
                    // Water can be trapped at this position
                    water += leftMax - height[left];
                } else {
                    // Update leftMax if current height is greater
                    leftMax = height[left];
                }
                left++; // Move the left pointer inward
            } else {
                // Right side is smaller or equal ⇒ bounded by rightMax
                if (rightMax > height[right]) {
                    // Water can be trapped at this position
                    water += rightMax - height[right];
                } else {
                    // Update rightMax if current height is greater
                    rightMax = height[right];
                }
                right--; // Move the right pointer inward
            }
        }

        return water; // Total trapped water
    }
}
