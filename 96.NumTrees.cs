// 96. Unique Binary Search Trees
// Given an integer n, return the number of structurally unique BST's (binary search trees) which has exactly n nodes
// of unique values from 1 to n.

// Example 1:
// Input: n = 3
// Output: 5
// Example 2:
// Input: n = 1
// Output: 1

public class Solution {
    public int NumTrees(int n) {
        int[] numTree = new int[n+1];
        numTree[0] = 1;
        for(int i = 1; i <= n; i++){
            for(int j = 1; j <= i; j++)
                numTree[i] += numTree[j-1]*numTree[i-j];
        }
        return numTree[n];
    }
}

/*    
Explanation:
    //G(n) = G(0) * G(n-1) + G(1) * G(n-2) + … + G(n-1) * G(0) 
    n = 0;     null   
    
    count[0] = 1
    
    
    n = 1;      1       
    
    count[1] = 1 
    
    
    n = 2;    1__       			 __2     
    		      \					/                 
    		     count[1]	   	count[1]	
    
    count[2] = 1 + 1 = 2
    
    
    
    n = 3;    1__				      __2__	                   __3
    		      \		            /       \			      /		
    		  count[2]		  count[1]    count[1]		count[2]
    
    count[3] = 2 + 1 + 2  = 5
    
    
    
    n = 4;    1__  					__2__					   ___3___                  
    		      \				 /        \					  /		  \			
    		  count[3]		 count[1]    count[2]		  count[2]   count[1]
    
                 __4				
               /
           count[3]   
    
    count[4] = 5 + 2 + 2 + 5 = 14     
    

And  so on...
*/