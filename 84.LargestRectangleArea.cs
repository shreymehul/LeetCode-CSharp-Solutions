// 84. Largest Rectangle in Histogram
// Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, 
// return the area of the largest rectangle in the histogram.
// Example 1:
// Input: heights = [2,1,5,6,2,3]
// Output: 10
// Explanation: The above is a histogram where width of each bar is 1.
// The largest rectangle is shown in the red area, which has an area = 10 units.
// Example 2:
// Input: heights = [2,4]
// Output: 4
// Constraints:
// 1 <= heights.length <= 105
// 0 <= heights[i] <= 104

public class Solution {
    public int LargestRectangleArea(int[] heights) {
        
        int[] nextSmallest = new int[heights.Length];
        Stack<int> st = new Stack<int>();
        for (int i = heights.Length - 1; i >= 0; i--)
        {
            while (st.Any() && heights[st.Peek()] >= heights[i])
            {
                st.Pop();
            }
            if (st.Any())
                nextSmallest[i] = st.Peek();
            else
                nextSmallest[i] = heights.Length;
            st.Push(i);
        }
        st.Clear();
        int[] prevSmallest = new int[heights.Length];
        for (int i = 0; i < heights.Length; i++)
        {
            while (st.Any() && heights[st.Peek()] >= heights[i])
            {
                st.Pop();
            }
            if (st.Any())
                prevSmallest[i] = st.Peek();
            else
                prevSmallest[i] = -1;
            st.Push(i);
        }
        int maxarea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            maxarea = Math.Max(maxarea,
                (heights[i] * (nextSmallest[i] - prevSmallest[i] - 1)));
        }
        return maxarea;
    
    }
}


public class Solution {
    public int LargestRectangleArea(int[] heights)
    {
        // Edge case: if heights array is empty or null
        if (heights == null || heights.Length == 0)
            return 0;

        // Stack to store indices of histogram bars
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;

        // Traverse all bars and an extra iteration to process remaining stack
        for (int i = 0; i <= heights.Length; i++)
        {
            // Handle the final case where we treat the "last" height as 0
            int currentHeight = (i == heights.Length) ? 0 : heights[i];

            // Maintain a non-decreasing height stack; calculate area for taller bars
            while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
            {
                // Pop the top element which represents the height of a rectangle
                int height = heights[stack.Pop()];

                // Calculate the width of the rectangle
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;

                // Update max area if a larger rectangle is found
                maxArea = Math.Max(maxArea, height * width);
            }

            // Push the current bar's index onto the stack
            stack.Push(i);
        }

        return maxArea;
    }
}