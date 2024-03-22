// 684. Redundant Connection
// In this problem, a tree is an undirected graph that is connected and has no cycles.

// You are given a graph that started as a tree with n nodes labeled from 1 to n, with one additional
// edge added. The added edge has two different vertices chosen from 1 to n, and was not an edge that 
// already existed. The graph is represented as an array edges of length n where edges[i] = [ai, bi] 
// indicates that there is an edge between nodes ai and bi in the graph.

// Return an edge that can be removed so that the resulting graph is a tree of n nodes. 
// If there are multiple answers, return the answer that occurs last in the input.

// Example 1:
// Input: edges = [[1,2],[1,3],[2,3]]
// Output: [2,3]
// Example 2:
// Input: edges = [[1,2],[2,3],[3,4],[1,4],[1,5]]
// Output: [1,4]

// Constraints:
// n == edges.length
// 3 <= n <= 1000
// edges[i].length == 2
// 1 <= ai < bi <= edges.length
// ai != bi
// There are no repeated edges.
// The given graph is connected.


public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] parent = new int[n + 1];
        // Initialize parent array
        for (int i = 0; i <= n; i++) {
            parent[i] = i;
        }
        
        int[] result = new int[2];
        // Union Find
        // If the parent of both nodes are same, then it is a cycle
        // If the parent of both nodes are different, then make the parent of one node as the parent of the other node
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            int parentU = Find(parent, u);
            int parentV = Find(parent, v);
            
            // If the parent of both nodes are same, then it is a cycle
            if (parentU == parentV) {
                result[0] = u;
                result[1] = v;
            } else {
                parent[parentV] = parentU;
            }
        }
        
        return result;
    }
    
    private int Find(int[] parent, int x) {
        // If the parent of the node is not the node itself, then recursively find the parent of the parent
        if (parent[x] != x) {
            parent[x] = Find(parent, parent[x]);
        }
        return parent[x];
    }
}

