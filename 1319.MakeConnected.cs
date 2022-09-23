// 1319. Number of Operations to Make Network Connected

// There are n computers numbered from 0 to n - 1 connected by ethernet cables connections forming a network where connections[i] = [ai, bi] represents a connection between computers ai and bi. Any computer can reach any other computer directly or indirectly through the network.

// You are given an initial computer network connections. You can extract certain cables between two directly connected computers, and place them between any pair of disconnected computers to make them directly connected.

// Return the minimum number of times you need to do this in order to make all the computers connected. If it is not possible, return -1.

 

// Example 1:


// Input: n = 4, connections = [[0,1],[0,2],[1,2]]
// Output: 1
// Explanation: Remove cable between computer 1 and 2 and place between computers 1 and 3.
// Example 2:


// Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2],[1,3]]
// Output: 2
// Example 3:

// Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2]]
// Output: -1
// Explanation: There are not enough cables.


public class Solution {
    public bool[] Visited = new bool[100000];
    public int MakeConnected(int n, int[][] connections)
    {
        if (connections.Length - (n - 1) < 0)
            return - 1;
        List<int>[] edges = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            edges[i] = new List<int>();
        }
        for (int i = 0; i < connections.Length; i++)
        {
            edges[connections[i][0]].Add(connections[i][1]);
            edges[connections[i][1]].Add(connections[i][0]);
        }
        int noOfConected = 0;
        for (int i = 0; i < n; i++)
        {
            if (!Visited[i])
            {
                connectedComponent(edges, i);
                noOfConected++;
            }
        }
        return noOfConected - 1;
    }

    public void connectedComponent(List<int>[] edges, int src)
    {
        if (Visited[src])
            return;
        Visited[src] = true;
        foreach (var edge in edges[src])
        {
            if (!Visited[edge])
                connectedComponent(edges, edge);
        }
    }
}