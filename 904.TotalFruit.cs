// 904. Fruit Into Baskets
// You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.

// You want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:

// You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.
// Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right. The picked fruits must fit in one of your baskets.
// Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
// Given the integer array fruits, return the maximum number of fruits you can pick.

//Approch1
public class Solution {
    public int TotalFruit(int[] fruits) {
        Dictionary<int, int> result = new Dictionary<int, int>();
        int left, right;
        left = 0;
        right = 1;
        result.Add(fruits[left], 1);
        int max = 1;
        while (right < fruits.Length)
        {
            if (result.ContainsKey(fruits[right]))
            {
                result[fruits[right]]++;
            }
            else
            {
                if (result.Count == 2)
                {
                    while (result[fruits[left]] > 1)
                    {
                        result[fruits[left]]--;
                        left++;
                    }
                    result.Remove(fruits[left]);
                    left++;
                }
                result.Add(fruits[right], 1);
            }
            max = Math.Max(max, right - left + 1);
            right++;
        }
        return max;
    }
}

//Approch2
public class Solution {
    public int TotalFruit(int[] fruits) {
        if (fruits.Length < 1)
            return fruits.Length;
        int left, right;
        left = 0;
        right = 0;
        int max = 1;
        int f1, f2;
        f1 = f2 =  fruits[0];


        while (right < fruits.Length && left <= right)
        {
            while (right < fruits.Length && f1 == fruits[right])
            {
                right++;
            }
            if(right < fruits.Length)
                f2 = fruits[right];
            while (right < fruits.Length && (f1 == fruits[right] || f2 == fruits[right]))
            {
                right++;
            }
            int localMax = right - left;
            if (right < fruits.Length)
            {
                int f3;
                if(fruits[right-1] == f1)
                {
                    f3 = f2;
                }
                else
                {
                    f3 = f1;
                }
                int slider = left;
                while (slider < right)
                {
                    if (f3 == fruits[slider])
                        left = slider + 1;
                    slider++;
                }
                f1 = fruits[left];
            }
            max = Math.Max(max, localMax);
        }
        return max;
    }
}