// 846. Hand of Straights
// Alice has some number of cards and she wants to rearrange the cards into groups so that each group is of size groupSize, and consists of groupSize consecutive cards.

// Given an integer array hand where hand[i] is the value written on the ith card and an integer groupSize, return true if she can rearrange the cards, or false otherwise.

// Example 1:
// Input: hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
// Output: true
// Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8]
// Example 2:
// Input: hand = [1,2,3,4,5], groupSize = 4
// Output: false
// Explanation: Alice's hand can not be rearranged into groups of 4.

// Constraints:
// 1 <= hand.length <= 104
// 0 <= hand[i] <= 109
// 1 <= groupSize <= hand.length

public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length%groupSize != 0)
            return false;
        
        Array.Sort(hand);

        Dictionary<int,int> cardFreq = new();
        foreach(var card in hand){
            if(cardFreq.ContainsKey(card))
                cardFreq[card]++;
            else
                cardFreq[card] = 1;
        }
        while(cardFreq.Any()){
            int card = cardFreq.First().Key;
            for(int i = 0; i < groupSize; i++){
                int currCard = card  + i;
                if(cardFreq.ContainsKey(currCard)){
                    cardFreq[currCard]--;
                    if(cardFreq[currCard] == 0)
                        cardFreq.Remove(currCard);
                }
                else
                        return false;
            }
        }
        return true;
    }
}