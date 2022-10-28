// 295. Find Median from Data Stream

// The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value and the median is the mean of the two middle values.

// For example, for arr = [2,3,4], the median is 3.
// For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
// Implement the MedianFinder class:

// MedianFinder() initializes the MedianFinder object.
// void addNum(int num) adds the integer num from the data stream to the data structure.
// double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.

// Example 1:

// Input
// ["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
// [[], [1], [2], [], [3], []]
// Output
// [null, null, null, 1.5, null, 2.0]

// Explanation
// MedianFinder medianFinder = new MedianFinder();
// medianFinder.addNum(1);    // arr = [1]
// medianFinder.addNum(2);    // arr = [1, 2]
// medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
// medianFinder.addNum(3);    // arr[1, 2, 3]
// medianFinder.findMedian(); // return 2.0


public class MedianFinder {
    //will behave as maxHeap
    //item, priority -> Lower the value higher the priority
    PriorityQueue<int,int> lower = new PriorityQueue<int, int>();
    //will behave as minHeap
    PriorityQueue<int,int> higher = new PriorityQueue<int, int>();

    public MedianFinder() {
        
    }
    //Insertion in Heap will take O(logN) time and to insert N item it will take O(NlogN)
    public void AddNum(int num) {
        //as lower in MaxHeap -> storing priority as number negative which ensure, 
        //higher the number higher is its priority(as negavive of highest number will be lowest).
        lower.Enqueue(num , -1*num);
        int maxOfLower = lower.Dequeue();
        higher.Enqueue(maxOfLower,maxOfLower);
        
        //Ensuring that number are divide into two parts such that;
        // lower <= higher <= lower + 1
        // 0 <= lower - higher <= 1
        if(lower.Count<higher.Count){
            int minOfHigher = higher.Dequeue();
            lower.Enqueue(minOfHigher, -1*minOfHigher);
        }
    }
    //finding median will take O(1)
    public double FindMedian() {
        if(lower.Count == higher.Count)
            return (double)(lower.Peek()+higher.Peek())/2;
        return (double)lower.Peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */