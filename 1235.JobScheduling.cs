// 1235. Maximum Profit in Job Scheduling
// We have n jobs, where every job is scheduled to be done from startTime[i] to endTime[i], obtaining a profit of profit[i].
// You're given the startTime, endTime and profit arrays, return the maximum profit you can take such that there are no two jobs in the subset with overlapping time range.
// If you choose a job that ends at time X you will be able to start another job that starts at time X.
// Example 1:
// Input: startTime = [1,2,3,3], endTime = [3,4,5,6], profit = [50,10,40,70]
// Output: 120
// Explanation: The subset chosen is the first and fourth job. 
// Time range [1-3]+[3-6] , we get profit of 120 = 50 + 70.
// Example 2:
// Input: startTime = [1,2,3,4,6], endTime = [3,5,10,6,9], profit = [20,20,100,70,60]
// Output: 150
// Explanation: The subset chosen is the first, fourth and fifth job. 
// Profit obtained 150 = 20 + 70 + 60.
// Example 3:
// Input: startTime = [1,1,1], endTime = [2,3,4], profit = [5,6,4]
// Output: 6
public class Solution {
    int[] maxProfit;
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        maxProfit = new int[profit.Length];
        (int start, int end, int profit)[] jobs = new (int, int, int)[profit.Length];
        for(int i = 0; i < profit.Length; i++)
        {
            jobs[i] = (startTime[i], endTime[i], profit[i]);
        }
        jobs = jobs.OrderBy(x => x.start).ToArray();
        Array.Fill(maxProfit, -1);
        return Scheduling(jobs, 0, 0);
    }
    public int Scheduling((int start, int end, int profit)[] jobs, int idx, int time)
    {
        if (maxProfit[idx] == -1) {
            int exProfit = idx + 1 < jobs.Length ? Scheduling(jobs, idx + 1, time) : 0;
            int inProfit = jobs[idx].profit;
            for(int i = idx+1; i < jobs.Length; i++) {
                if (jobs[i].start >= jobs[idx].end)
                {
                    inProfit += Scheduling(jobs, i, time + jobs[idx].end);
                    break;
                }
            }
            maxProfit[idx] = Math.Max(inProfit, exProfit);
        }
        return maxProfit[idx];
    }
}