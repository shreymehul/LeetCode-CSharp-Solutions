// 135. Candy

// There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.
// You are giving candies to these children subjected to the following requirements:
// Each child must have at least one candy.
// Children with a higher rating get more candies than their neighbors.
// Return the minimum number of candies you need to have to distribute the candies to the children.

// Example 1:
// Input: ratings = [1,0,2]
// Output: 5
// Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.
// Example 2:
// Input: ratings = [1,2,2]
// Output: 4
// Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
// The third child gets 1 candy because it satisfies the above two conditions.

// Constraints:
// n == ratings.length
// 1 <= n <= 2 * 104
// 0 <= ratings[i] <= 2 * 104

//greedy

public class Solution {
    public int Candy(int[] ratings) {
        int n = ratings.Length;
        int[] candy = new int[n];

        // 1. Give each child at least 1 candy
        for (int i = 0; i < n; i++) {
            candy[i] = 1;
        }

        // 2. Left to right: compare with left neighbor
        for (int i = 1; i < n; i++) {
            if (ratings[i] > ratings[i - 1]) {
                candy[i] = candy[i - 1] + 1;
            }
        }

        // 3. Right to left: compare with right neighbor
        for (int i = n - 2; i >= 0; i--) {
            if (ratings[i] > ratings[i + 1]) {
                candy[i] = Math.Max(candy[i], candy[i + 1] + 1);
            }
        }

        // 4. Sum total candies
        return candy.Sum();
    }
}
