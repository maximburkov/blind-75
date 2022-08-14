namespace Blind_75.Dynamic;

public class WordBreakTask : ISolution
{
    public void Solve()
    {
        var res = WordBreak("leetcode", new[] {"leet", "code"});
    }

    public bool WordBreak(string s, IList<string> wordDict)
    {
        var hashSet = wordDict.ToHashSet();
        var d = new bool[s.Length + 1];
        d[0] = true;

        int maxLength = 0;
        foreach (var word in wordDict)
        {
            maxLength = Math.Max(maxLength, word.Length);
        }

        for (int i = 0; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if(maxLength > i - j) break;
                if (d[j] && hashSet.Contains(s.Substring(j, i - j - 1)))
                {
                    d[i] = true;
                    break;
                }
            }
        }

        return d[^1];
    }
}