// 149. Max Points on a Line
// Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.
// Example 1:
// Input: points = [[1,1],[2,2],[3,3]]
// Output: 3
// Example 2:
// Input: points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
// Output: 4
// Constraints:
// 1 <= points.length <= 300
// points[i].length == 2
// -104 <= xi, yi <= 104
// All the points are unique.

public class Solution {
    public int MaxPoints(int[][] points) {
        int max = 0;
        for(int i = 0; i < points.Length-1; i++){
            Dictionary<double,int> tan = new Dictionary<double,int>();
            tan[90] = 0;
            for(int j = i+1; j < points.Length;j++){
                if(points[i][0] == points[j][0]){
                    tan[90]++;
                }
                else{
                    double t = (double)((double)(points[j][1] - points[i][1]) /
                                    (double)(points[j][0] - points[i][0]));
                    if(tan.ContainsKey(t))
                        tan[t]++;
                    else
                        tan[t] = 1;
                }
            }
            foreach(var item in tan)
                max = Math.Max(max,item.Value);
        }
        return max+1;
    }
}