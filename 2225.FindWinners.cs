// 2225. Find Players With Zero or One Losses
// You are given an integer array matches where matches[i] = [winneri, loseri] indicates that the player winneri defeated player loseri in a match.
// Return a list answer of size 2 where:
// answer[0] is a list of all players that have not lost any matches.
// answer[1] is a list of all players that have lost exactly one match.
// The values in the two lists should be returned in increasing order.
// Note:
// You should only consider the players that have played at least one match.
// The testcases will be generated such that no two matches will have the same outcome.
// Example 1:
// Input: matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]
// Output: [[1,2,10],[4,5,7,8]]
// Explanation:
// Players 1, 2, and 10 have not lost any matches.
// Players 4, 5, 7, and 8 each have lost one match.
// Players 3, 6, and 9 each have lost two matches.
// Thus, answer[0] = [1,2,10] and answer[1] = [4,5,7,8].
// Example 2:
// Input: matches = [[2,3],[1,3],[5,4],[6,4]]
// Output: [[1,2,5,6],[]]
// Explanation:
// Players 1, 2, 5, and 6 have not lost any matches.
// Players 3 and 4 each have lost two matches.
// Thus, answer[0] = [1,2,5,6] and answer[1] = [].

public class Solution {
    public IList<IList<int>> FindWinners(int[][] matches) {
        Dictionary<int,int> stats = new Dictionary<int,int>();
        foreach(var item in matches){
            if(!stats.ContainsKey(item[0])){
                stats[item[0]] = 0;
            }
            if(stats.ContainsKey(item[1])){
                stats[item[1]]++;
            }
            else{
                stats[item[1]] = 1;
            }
        }
        IList<IList<int>> result = new List<IList<int>>();
        List<int> l1 = new List<int>();
        List<int> l2 = new List<int>();
        foreach(var item in stats){
            if(item.Value == 0)
                l1.Add(item.Key);
            if(item.Value == 1)
                l2.Add(item.Key);
        }
        l1.Sort();
        l2.Sort();
        result.Add(l1);
        result.Add(l2);
        return result;
    }
}