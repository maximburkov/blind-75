namespace Blind_75.String;

public class LongestPalindromeTask : ISolution
{
    public void Solve()
    {
        
    }
    
    public int LongestPalindrome(string s)
    {
        var map = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (map.ContainsKey(c))
                map[c]++;
            else
                map[c] = 1;
        }

        int totalLength = 0;
        bool hasOdd = false;
        foreach (var item in map.Values)
        {
            if (item % 2 == 0)
            {
                totalLength += item;
            }
            else
            {
                totalLength += (item - 1);
                hasOdd = true;
            }
        }

        return hasOdd ? totalLength + 1 : totalLength;
    }
}