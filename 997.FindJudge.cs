// 997. Find the Town Judge
// In a town, there are n people labeled from 1 to n. There is a rumor that one of these people is secretly the town judge.

// If the town judge exists, then:

// The town judge trusts nobody.
// Everybody (except for the town judge) trusts the town judge.
// There is exactly one person that satisfies properties 1 and 2.
// You are given an array trust where trust[i] = [ai, bi] representing that the person labeled ai trusts the person labeled bi.
// Return the label of the town judge if the town judge exists and can be identified, or return -1 otherwise.
// Example 1:
// Input: n = 2, trust = [[1,2]]
// Output: 2
// Example 2:
// Input: n = 3, trust = [[1,3],[2,3]]
// Output: 3
// Example 3:
// Input: n = 3, trust = [[1,3],[2,3],[3,1]]
// Output: -1

//adj matrix
public class Solution {
    public int FindJudge(int n, int[][] trust) {
        List<int>[] adj = new List<int>[n + 1];
        for (int i = 0; i <= n; i++)
            adj[i] = new List<int>();
        for (int i = 0; i < trust.Length; i++)
        {
            adj[trust[i][0]].Add(trust[i][1]);
        }
        int judge = -1;
        for (int i = 1; i <= n; i++)
        {
            if (adj[i].Count == 0)
                judge = i;
        }
        for (int i = 1; i <= n; i++)
        {
            if (i != judge && !adj[i].Contains(judge))
                return -1;
        }
        return judge;
    }
}

//In degree- Out degree
//judge will have in degree = n-1, out degree = 0
public class Solution {
    public int FindJudge(int n, int[][] trust) {
        int[] degree = new int[n+1];
        for (int i = 0; i < trust.Length; i++)
        {
            degree[trust[i][0]]--;
            degree[trust[i][1]]++;
        }
        for (int i = 1; i <= n; i++)
        {
            if (degree[i] == n-1)
                return i;
        }
        return -1;
    }
}