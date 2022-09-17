// 239. Sliding Window Maximum

// You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.

// Return the max sliding window.


//c# incomplete solution.
//need deque implementation
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int[] res = new int[nums.Length-k+1];
        Deque<int> max = new Deque<int>();
        for (int i = 0; i < k; i++)
        {
            if (max.Count > 0 && max.PeekFirst() < nums[i])
            {
                max.Clear();
            }
            max.AddFirst(nums[i]);
        }
        res[0] = max.PeekFirst();
        for (int i = k; i < nums.Length; i++)
        {
            if (max.Count > 0 && max.PeekFirst() == nums[i-k])
                max.PopFirst();
            if (max.Count > 0 && max.Peek() < nums[i])
            {
                max.Clear();
            }
            while(max.Count > 0 && max.PeekLast > nums[i])
                max.PopLast();
            max.Enqueue(nums[i]);
            res[i-k+1] = max.PeekFirst();
        }
        return res;
    }
}


////c++ dequeue soln
vector<int> maxSlidingWindow(vector<int>& nums, int k) {
    
    vector <int> ans;
    
    deque<int> dq;
    
    int i=0,j=0;
    
    while(j<nums.size())
    {
        while(!dq.empty() && dq.back()<nums[j])
        {
            dq.pop_back();  //coz we dont need elemnt lesser than it in front of queue 
            // to better understanding dry run on nums={1,3,1,2,0,5} & k=3
        }
        
        dq.push_back(nums[j]);
        
        //if window size not achieved
        if(j-i+1<k)
        {
            j++;
        }
        else
        {
           
            ans.push_back(dq.front());
            
            //calculation for i
            if(nums[i]==dq.front())
            {
                dq.pop_front();
            }
            
            i++;
            j++;
        }
    }
    
    return ans;