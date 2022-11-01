// 378. Kth Smallest Element in a Sorted Matrix

// Given an n x n matrix where each of the rows and columns is sorted in ascending order, return the kth smallest element in the matrix.

// Note that it is the kth smallest element in the sorted order, not the kth distinct element.

// You must find a solution with a memory complexity better than O(n2).

// Example 1:

// Input: matrix = [[1,5,9],[10,11,13],[12,13,15]], k = 8
// Output: 13
// Explanation: The elements in the matrix are [1,5,9,10,11,12,13,13,15], and the 8th smallest number is 13
// Example 2:

// Input: matrix = [[-5]], k = 1
// Output: -5

public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        PriorityQueue<int,int> maxHeap = new PriorityQueue<int,int>();
        int row = matrix.Length;
        int col = matrix[0].Length;
        for(int i = 0; i < row; i++ ){
            for( int j = 0; j < col; j++){
                if(maxHeap.Count == k && matrix[i][j] >= maxHeap.Peek() )
                    break;
                maxHeap.Enqueue(matrix[i][j], -1*matrix[i][j]);
                if(maxHeap.Count > k){
                    maxHeap.Dequeue();
                }
            }
        }
        return maxHeap.Dequeue();
    }
}