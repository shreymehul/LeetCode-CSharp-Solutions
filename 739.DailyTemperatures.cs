// 739. Daily Temperatures
// Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.
// Example 1:
// Input: temperatures = [73,74,75,71,69,72,76,73]
// Output: [1,1,4,2,1,1,0,0]
// Example 2:
// Input: temperatures = [30,40,50,60]
// Output: [1,1,1,0]
// Example 3:
// Input: temperatures = [30,60,90]
// Output: [1,1,0]

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        Stack<(int,int)> st = new Stack<(int,int)>();
        int[] res = new int[temperatures.Length];
        st.Push((temperatures[temperatures.Length-1],temperatures.Length-1));
        for(int i = temperatures.Length-2; i >= 0; i--){
            while(st.Count > 0 && st.Peek().Item1 <= temperatures[i]){
                st.Pop();
            }
            if(st.Count > 0 && st.Peek().Item1 > temperatures[i]){
                res[i] = st.Peek().Item2 - i;
            }
            st.Push((temperatures[i],i));
        }
        return res;
    }
}