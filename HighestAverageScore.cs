// Question 1:
// Given a 2-D String array of student-marks find the student with the highest average and output his average score. 
// If the average is in decimals, floor it down to the nearest integer.

// Example 1:
// Input:  [{"Bob","87"}, {"Mike", "35"},{"Bob", "52"}, {"Jason","35"}, {"Mike", "55"}, {"Jessica", "99"}]
// Output: 99
// Explanation: Since Jessica's average is greater than Bob's, Mike's and Jason's average.

using System;
using System.Collections.Generic;

public class Solution {
    public int HighestAverageScore(string[,] studentMarks) {
        var scoreMap = new Dictionary<string, List<int>>();

        // Parse student scores and group by student names
        int rows = studentMarks.GetLength(0);
        for (int i = 0; i < rows; i++) {
            string name = studentMarks[i, 0];
            int score = int.Parse(studentMarks[i, 1]);

            if (!scoreMap.ContainsKey(name))
                scoreMap[name] = new List<int>();
            
            scoreMap[name].Add(score);
        }

        int maxAverage = int.MinValue;

        // Calculate the highest average score
        foreach (var entry in scoreMap) {
            int totalScore = 0;
            foreach (var score in entry.Value)
                totalScore += score;

            int average = totalScore / entry.Value.Count;
            maxAverage = Math.Max(maxAverage, average);
        }

        return maxAverage;
    }
    
    public static void Main() {
        string[,] input = {
            {"Bob", "87"}, {"Mike", "35"},
            {"Bob", "52"}, {"Jason", "35"},
            {"Mike", "55"}, {"Jessica", "99"}
        };
        Solution solution = new Solution();
        Console.WriteLine(solution.HighestAverageScore(input)); // Output: 99
    }
}

// Explanation:
// We use a dictionary to map student names to their list of scores.
// For each student, we calculate the total score and derive the average.
// We keep track of the maximum average encountered.
// The result is floored due to integer division.
// Complexity Analysis:
// Time Complexity: O(N) whereN is the number of records.
// Space Complexity: O(M) where M is the number of unique students.