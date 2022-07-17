namespace Blind_75.String;

public class RansomNote : ISolution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> map = new();

        foreach (var c in ransomNote)
        {
            if (map.ContainsKey(c))
                map[c]++;
            else
                map[c] = 1;
        }

        foreach (var c in magazine)
        {
            if (map.ContainsKey(c) && map[c] > 0)
                map[c]--;
        }

        return !map.Values.Any(v => v > 0);
    }
    
    public void Solve()
    {
    }
}