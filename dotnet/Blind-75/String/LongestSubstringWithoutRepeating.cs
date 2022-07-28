namespace Blind_75.String;

public class LongestSubstringWithoutRepeating : ISolution
{
    public void Solve()
    {
        var res = LengthOfLongestSubstring("pwwkew");
    }
    
    public int LengthOfLongestSubstring(string s)
    {
        int maxLength = 0;
        HashSet<char> set = new HashSet<char>();
        int start = 0;

        for (int i = 0; i < s.Length; i++)
        {
            while (set.Contains(s[i]))
            {
                set.Remove(s[start]);
                start++;
            }

            set.Add(s[i]);
            maxLength = Math.Max(i - start + 1, maxLength);
        }

        return maxLength;
    }
}