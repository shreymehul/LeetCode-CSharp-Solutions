// 210. Course Schedule II
// M
// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

// For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
// Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

// Example 1:

// Input: numCourses = 2, prerequisites = [[1,0]]
// Output: [0,1]
// Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].
// Example 2:

// Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
// Output: [0,2,1,3]
// Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
// So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].
// Example 3:

// Input: numCourses = 1, prerequisites = []
// Output: [0]

//Detect Cycle  & Reverse Topological Sort
public class Solution {
    Stack<int> stack = new Stack<int>();
    int[] Process = new int[2000];
    //unprocessed ->0
	//processed ->1
	//processing ->2
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<int>[] path = new List<int>[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            path[i] = new List<int>();
        }
        foreach (var item in prerequisites)
        {
            path[item[0]].Add(item[1]);
        }
         
        for (int i = 0; i < numCourses; i++)
        {
            if(Process[i] == 0)
            {
                if (IsCycleAndTopologicalSort(i, path))
                    return new int[0];
            }
        }
        int[] result = new int[numCourses];
        for(int i = numCourses-1; i >=0; i--)
        {
            result[i] = stack.Pop();
        }
        return result;
    }
    public bool IsCycleAndTopologicalSort(int Vertice, List<int>[] path)
    {
        if (Process[Vertice] == 2)
            return true;
        Process[Vertice] = 2;
        foreach (var item in path[Vertice])
        {
            if (Process[item] != 1)
                if (IsCycleAndTopologicalSort(item, path))
                    return true;
        }
        Process[Vertice] = 1;
        stack.Push(Vertice);

        return false;
    }
}