// 743. Network Delay Time
// You are given a network of n nodes, labeled from 1 to n. You are also given times, a list of travel times as directed edges times[i] = (ui, vi, wi), where ui is the source node, vi is the target node, and wi is the time it takes for a signal to travel from source to target.
// We will send a signal from a given node k. Return the minimum time it takes for all the n nodes to receive the signal. If it is impossible for all the n nodes to receive the signal, return -1.
// Example 1:
// Input: times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
// Output: 2
// Example 2:
// Input: times = [[1,2,1]], n = 2, k = 1
// Output: 1
// Example 3:
// Input: times = [[1,2,1]], n = 2, k = 2
// Output: -1
// Constraints:
// 1 <= k <= n <= 100
// 1 <= times.length <= 6000
// times[i].length == 3
// 1 <= ui, vi <= n
// ui != vi
// 0 <= wi <= 100
// All the pairs (ui, vi) are unique. (i.e., no multiple edges.)


//Using Bellman Ford Algorithm.
//Initialise Distance with infinity, and distance of starting node with 0
//Run loop on edges for N-1 time.
 
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int[] time = new int[n+1];
        Array.Fill(time,999);
        time[0] = 0;
        time[k] = 0;
        for(int i = 1; i < n; i++){
            foreach(var edge in times){
                if((time[edge[0]] + edge[2]) < time[edge[1]]){
                    time[edge[1]] = time[edge[0]] + edge[2];
                }
            }
        }
        int maxTime = time.Max();
        return maxTime == 999 ? -1 : maxTime;
    }
}