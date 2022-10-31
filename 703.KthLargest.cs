// 703. Kth Largest Element in a Stream

// Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.

// Implement KthLargest class:

// KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
// int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.
 

// Example 1:

// Input
// ["KthLargest", "add", "add", "add", "add", "add"]
// [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
// Output
// [null, 4, 5, 5, 8, 8]

// Explanation
// KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
// kthLargest.add(3);   // return 4
// kthLargest.add(5);   // return 5
// kthLargest.add(10);  // return 5
// kthLargest.add(9);   // return 8
// kthLargest.add(4);   // return 8

//list
public class KthLargest {
    List<int> list = new List<int>();
    int k;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        list.AddRange(nums);
    }
    
    public int Add(int val) {
        list.Add(val);
        list.Sort();
        
        return list[list.Count - k];
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

 //minHeap
 public class KthLargest {
    PriorityQueue<int,int> minHeap = new PriorityQueue<int,int>();
    int k;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        foreach(int num in nums){
            minHeap.Enqueue(num,num);
            if(minHeap.Count > k)
                minHeap.Dequeue();
        }
    }
    
    public int Add(int val) {
        minHeap.Enqueue(val,val);
        if(minHeap.Count > k)
            minHeap.Dequeue();
        
        return minHeap.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */