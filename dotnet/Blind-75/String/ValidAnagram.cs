namespace Blind_75.String;

public class ValidAnagram : ISolution
{
    public void Solve()
    {
        var res = IsAnagram("rat", "cat");
    }
    
    public bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> counts = new();

        if (s.Length != t.Length) return false;

        foreach (var c in s)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }
        
        foreach (var c in t)
        {
            if (counts.ContainsKey(c) && counts[c] > 0)
                counts[c]--;
            else
                return false;
        }

        return true;
    }
}