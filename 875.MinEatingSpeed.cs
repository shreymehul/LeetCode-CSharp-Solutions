// 875. Koko Eating Bananas
// Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.

// Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.

// Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.

// Return the minimum integer k such that she can eat all the bananas within h hours.

public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int min, max;
        min = 1;
        max = piles[0];
        for(int i=1;i<piles.Length;i++){
            max= Math.Max(max,piles[i]);
        }
        int res = -1;
        while(min<=max){
            int mid = min + (max-min)/2;
            if(Check(piles,h,mid)){
                res = mid;
                max = mid - 1;
            }
            else{
                min = mid + 1;
            }
        }
        return res;
    }
    public bool Check(int[] piles, int h, int mid){
        int t = 0;
        for (int i = 0; i < piles.Length; i++)
        {
            t += piles[i] / mid;
            if (piles[i] % mid != 0)
                t++;
            if (t > h)
                return false;
        }
        return true;
    }
}