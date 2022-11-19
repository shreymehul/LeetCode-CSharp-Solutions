// 223. Rectangle Area
// Given the coordinates of two rectilinear rectangles in a 2D plane, return the total area covered by the two rectangles.
// The first rectangle is defined by its bottom-left corner (ax1, ay1) and its top-right corner (ax2, ay2).
// The second rectangle is defined by its bottom-left corner (bx1, by1) and its top-right corner (bx2, by2).
// Example 1:
// Rectangle Area
// Input: ax1 = -3, ay1 = 0, ax2 = 3, ay2 = 4, bx1 = 0, by1 = -1, bx2 = 9, by2 = 2
// Output: 45
// Example 2:
// Input: ax1 = -2, ay1 = -2, ax2 = 2, ay2 = 2, bx1 = -2, by1 = -2, bx2 = 2, by2 = 2
// Output: 16

public class Solution {
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) {
        int area1 = 0, area2 = 0, areaCom = 0;
        
        area1 = (ax2-ax1)*(ay2-ay1);
        area2 = (bx2-bx1)*(by2-by1); 
        int left = Math.Max(ax1,bx1);
        int bottom = Math.Max(ay1,by1);
        int right = Math.Min(ax2,bx2);
        int top = Math.Min(ay2,by2);

        if(right > left && top > bottom){
            areaCom = (top - bottom) * (right - left);
        }
        return area1+area2-areaCom;
    }
}