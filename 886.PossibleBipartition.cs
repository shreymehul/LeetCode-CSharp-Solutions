// 886. Possible Bipartition
// We want to split a group of n people (labeled from 1 to n) into two groups of any size. Each person may dislike some other people, and they should not go into the same group.
// Given the integer n and the array dislikes where dislikes[i] = [ai, bi] indicates that the person labeled ai does not like the person labeled bi, return true if it is possible to split everyone into two groups in this way.
// Example 1:
// Input: n = 4, dislikes = [[1,2],[1,3],[2,4]]
// Output: true
// Explanation: group1 [1,4] and group2 [2,3].
// Example 2:
// Input: n = 3, dislikes = [[1,2],[1,3],[2,3]]
// Output: false
// Example 3:
// Input: n = 5, dislikes = [[1,2],[2,3],[3,4],[4,5],[1,5]]
// Output: false
// Constraints:
// 1 <= n <= 2000
// 0 <= dislikes.length <= 104
// dislikes[i].length == 2
// 1 <= dislikes[i][j] <= n
// ai < bi
// All the pairs of dislikes are unique.

public class Solution {
    public bool PossibleBipartition(int n, int[][] dislikes) {
        List<List<int>> adj = new List<List<int>>();
        for(int i = 0; i <= n; i++){
            adj.Add(new List<int>());
        }
        foreach(var pair in dislikes){
            adj[pair[0]].Add(pair[1]);
            adj[pair[1]].Add(pair[0]);
        }
        int[] colors = new int[n+1];
        Array.Fill(colors,-1);
        for(int i = 1; i <= n; i++){
            if(colors[i] == -1){
                if(!dfs(i, 0, colors, adj)) 
                    return false;
            }
        }
        return true;
    }
    public bool dfs(int node, int color, int[] colors, List<List<int>> adj){
        colors[node] = color;
        foreach(int nbr in adj[node]){
            if(colors[node] == colors[nbr]) return false;
            if(colors[nbr] == -1)
                if(!dfs(nbr, 1 - color , colors, adj)) return false;
        }
        return true;
    }
}