// 207. Course Schedule
// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

// For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
// Return true if you can finish all courses. Otherwise, return false.

// Example 1:
// Input: numCourses = 2, prerequisites = [[1,0]]
// Output: true
// Explanation: There are a total of 2 courses to take. 
// To take course 1 you should have finished course 0. So it is possible.
// Example 2:
// Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
// Output: false
// Explanation: There are a total of 2 courses to take. 
// To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.


//Detect Cycle | Deadlock
public class Solution {
	
    int[] Visited = new int[2000];
	//unprocessed ->0
	//processed ->1
	//processing ->2
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] path = new List<int>[numCourses];

        for(int i = 0; i < numCourses; i++)
        {
            path[i] = new List<int>();
        }
        foreach(var item in prerequisites)
        {
            path[item[0]].Add(item[1]);
        }
        for(int i = 0; i < numCourses; i++)
        {
            if (Visited[i] == 0)
            {
                if (IsCycle(i, path))
                    return false;
            }
        }
        return true;
    }
    public bool IsCycle(int Vertice, List<int>[] path)
    {
        if (Visited[Vertice] == 2)
            return true;
        Visited[Vertice] = 2;
        foreach(var item in path[Vertice])
        {
            if (Visited[item] != 1)
                if (IsCycle(item, path))
                    return true;
        }
        Visited[Vertice] = 1;
        return false;
    }
}