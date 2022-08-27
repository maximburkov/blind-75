namespace Blind_75.String;

public class MinimumWindowSubstring : ISolution
{
    public void Solve()
    {
        var test = MinWindow("ADOBECODEBANC", "ABC");
    }
    
    public string MinWindow(string s, string t)
    {
        if (t.Length > s.Length) return string.Empty;

        int l = 0, r = 0;
        Dictionary<char, int> target = new Dictionary<char, int>();
        Dictionary<char, int> current = new Dictionary<char, int>();
        string minWindow = string.Empty;

        foreach (var c in t)
        {
            AddOrIncrement(target, c);
        }

        while (r < s.Length)
        {
            bool containsAll = false;
            while (r < s.Length && !containsAll)
            {
                AddOrIncrement(current, s[r]);
                containsAll = ContainsAll(target, current);
                r++;
            }

            if (!containsAll) break;

            while (ContainsAll(target, current))
            {
                int len = r - l; // r should point to right bound + 1
                if (string.IsNullOrEmpty(minWindow) || len < minWindow.Length)
                {
                    minWindow = s.Substring(l, len);
                }
                
                RemoveOrDecrement(current, s[l]);
                l++;
            }
        }

        return minWindow;
    }

    private static void AddOrIncrement(Dictionary<char, int> dict, char key)
    {
        if (dict.ContainsKey(key))
            dict[key]++;
        else
            dict[key] = 1;
    }

    private static void RemoveOrDecrement(Dictionary<char, int> dict, char key)
    {
        dict[key]--;

        if (dict[key] <= 0)
            dict.Remove(key);
    }

    private bool ContainsAll(Dictionary<char, int> target, Dictionary<char, int> current)
    {
        foreach (var targetChar in target)
        {
            if (!current.ContainsKey(targetChar.Key) || target[targetChar.Key] > current[targetChar.Key])
            {
                return false;
            }
        }

        return true;
    }
}