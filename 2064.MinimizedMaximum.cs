// 2064. Minimized Maximum of Products Distributed to Any Store

// You are given an integer n indicating there are n specialty retail stores. There are m product types of varying amounts, which are given as a 0-indexed integer array quantities, where quantities[i] represents the number of products of the ith product type.

// You need to distribute all products to the retail stores following these rules:

// A store can only be given at most one product type but can be given any amount of it.
// After distribution, each store will have been given some number of products (possibly 0). Let x represent the maximum number of products given to any store. You want x to be as small as possible, i.e., you want to minimize the maximum number of products that are given to any store.
// Return the minimum possible x.

public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        int right, left;
        right = 0;
        
        for (int i = 0; i < quantities.Length; i++)
        {
            right = Math.Max(right, quantities[i]);
        }
        
        left = 1;
        int res = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (Check(quantities, mid, n))
            {
                res = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return res;
    }
    public bool Check(int[] quantities, int mid, int n){
        int store = 0;
        for (int i = 0; i < quantities.Length; i++)
        {
            int quan = quantities[i];
            while (quan > 0)
            {
                if (quan > mid)
                {
                    store++;
                    quan -= mid;
                }
                else
                {
                    store++;
                    quan = 0;
                }
                if (store > n)
                    return false;
            }
        }
        return true;
    }
}