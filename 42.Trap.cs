// 42. Trapping Rain Water

// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it 
// can trap after raining.
 
// Example :
// Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
// Output: 6
// Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.

public class Solution {
    public int Trap(int[] height) {
        int[] maxleft = new int[height.Length];
        int[] maxright = new int[height.Length];
        int res = 0;
        maxleft[0] = height[0];
        maxright[height.Length-1] = height[height.Length-1];
        for(int i=1;i<height.Length;i++){
            maxleft[i] = Math.Max(maxleft[i-1],height[i]);
        }
        for(int i=height.Length-2;i>=0;i--){
            maxright[i] = Math.Max(maxright[i+1],height[i]);
        }
        for(int i=0;i<height.Length;i++){
            res += Math.Min(maxleft[i],maxright[i]) - height[i];
        }
        return res;
    }
}