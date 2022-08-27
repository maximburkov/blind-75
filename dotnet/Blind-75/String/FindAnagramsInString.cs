namespace Blind_75.String;

public class FindAnagramsInString : ISolution
{
    public void Solve()
    {
        var s = "cbaebabacd";
        var p = "abc";
        var res = FindAnagrams(s, p);
    }
    
    public IList<int> FindAnagrams(string s, string p)
    {
        int l = 0;
        int r = p.Length - 1;
        Dictionary<char, int> dict = new();
        List<int> result = new();

        if (s.Length < p.Length)
            return result;

        foreach (var c in p)
        {
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict[c] = 1;
        }

        for (int i = 0; i < p.Length; i++)
        {
            if (dict.ContainsKey(s[i]))
                dict[s[i]]--;
        }

        while (r < s.Length)
        {
            if (dict.Values.All(i => i == 0))
            {
                result.Add(l);
            }

            if (dict.ContainsKey(s[l]))
                dict[s[l]]++;
            
            l++;
            r++;
            
            if (r < s.Length && dict.ContainsKey(s[r]))
                dict[s[r]]--;
        }

        return result;
    }
}