// 207. Course Schedule
// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
// You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first
// if you want to take course ai.
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
// To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1.
// So it is impossible.


//Detect Cycle | Deadlock
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // Graph represented as adjacency list
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }

        // Build the graph (reverse edges: course → prerequisite)
        foreach (var pair in prerequisites) {
            int course = pair[0];
            int prerequisite = pair[1];
            graph[course].Add(prerequisite);
        }

        // Status array: 0 = unvisited, 1 = visited, 2 = visiting
        int[] status = new int[numCourses];

        // Perform DFS for each course
        for (int i = 0; i < numCourses; i++) {
            if (status[i] == 0) {
                if (HasCycle(i, graph, status)) {
                    return false; // Cycle detected → can't finish all courses
                }
            }
        }

        return true; // No cycles found → possible to finish all courses
    }

    private bool HasCycle(int course, List<int>[] graph, int[] status) {
        if (status[course] == 2) return true;  // Found a back edge → cycle exists
        if (status[course] == 1) return false; // Already processed → no cycle

        status[course] = 2; // Mark as visiting

        foreach (var neighbor in graph[course]) {
            if (HasCycle(neighbor, graph, status)) {
                return true; // Cycle found in recursion
            }
        }

        status[course] = 1; // Mark as visited
        return false;
    }
}
