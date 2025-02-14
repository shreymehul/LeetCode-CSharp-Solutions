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


//Approch: Sort start time, linear search next job
// Time Complexity:O(n^2) in the worst case because for each job we may iterate over the remaining jobs to find the next valid job.
// Sorting step takes O(nlogn).
// Space Complexity:O(n) for memoization and recursion stack.
public class Solution 
{
    int[] maxProfit;

    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        int n = profit.Length;
        maxProfit = new int[n];

        // Initialize max profit array with -1 for memoization
        Array.Fill(maxProfit, -1);

        // Create job tuples containing start, end times, and profit
        (int start, int end, int profit)[] jobs = new (int, int, int)[n];
        for (int i = 0; i < n; i++) 
        {
            jobs[i] = (startTime[i], endTime[i], profit[i]);
        }

        // Sort jobs by their start time to facilitate recursive exploration
        jobs = jobs.OrderBy(x => x.start).ToArray();
        
        return Scheduling(jobs, 0, 0);
    }

    private int Scheduling((int start, int end, int profit)[] jobs, int idx, int time)
    {
        if (idx >= jobs.Length) return 0; // Base case: No more jobs

        // Return memoized result if already computed
        if (maxProfit[idx] != -1) return maxProfit[idx];

        // Exclude current job and compute profit
        int exProfit = Scheduling(jobs, idx + 1, time);

        // Include current job and find next non-overlapping job
        int inProfit = jobs[idx].profit;
        for (int i = idx + 1; i < jobs.Length; i++) 
        {
            if (jobs[i].start >= jobs[idx].end) 
            {
                inProfit += Scheduling(jobs, i, time + jobs[idx].end);
                break;
            }
        }

        // Cache the result and return maximum of include/exclude
        maxProfit[idx] = Math.Max(inProfit, exProfit);
        return maxProfit[idx];
    }
}

// Approch: Sort end time, binary search next job
// Time Complexity:
// Sorting: O(nlogn)
// Binary search for each job: O(nlogn)
// Total: O(nlogn)
// Space Complexity: O(n) for the dp array and job list.
public class Solution 
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) 
    {
        int n = profit.Length;
        
        // Create job tuples containing start, end times, and profit
        (int start, int end, int profit)[] jobs = new (int, int, int)[n];
        for (int i = 0; i < n; i++) 
        {
            jobs[i] = (startTime[i], endTime[i], profit[i]);
        }

        // Sort jobs by their end time to simplify job selection
        Array.Sort(jobs, (a, b) => a.end.CompareTo(b.end));

        // Memoization array to store max profit until each job
        int[] dp = new int[n];
        dp[0] = jobs[0].profit;

        for (int i = 1; i < n; i++) 
        {
            // Include current job profit
            int includeProfit = jobs[i].profit;

            // Find the last non-conflicting job using binary search
            int l = BinarySearch(jobs, i);
            if (l != -1) 
            {
                includeProfit += dp[l];
            }

            // Max of including or excluding the current job
            dp[i] = Math.Max(dp[i - 1], includeProfit);
        }

        return dp[n - 1];
    }

    // Binary search to find the last job that doesn't overlap
    private int BinarySearch((int start, int end, int profit)[] jobs, int index) 
    {
        int low = 0, high = index - 1;
        while (low <= high) 
        {
            int mid = (low + high) / 2;
            if (jobs[mid].end <= jobs[index].start) 
            {
                if (jobs[mid + 1].end <= jobs[index].start) 
                {
                    low = mid + 1;
                } 
                else 
                {
                    return mid;
                }
            } 
            else 
            {
                high = mid - 1;
            }
        }
        return -1;
    }
}


//Raw
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