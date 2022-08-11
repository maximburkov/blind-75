using System.Diagnostics;

namespace Blind_75.Interval;

// TODO: Not Implemented
public class AccountsMergeTask : ISolution
{
    public void Solve()
    {
        IList<IList<string>> input = new List<IList<string>>
        {
            new List<string> {"John", "johnsmith@mail.com", "john_newyork@mail.com"},
            new List<string> {"John", "johnsmith@mail.com", "john00@mail.com"},
            new List<string> {"Mary", "mary@mail.com"},
            new List<string> {"John", "johnnybravo@mail.com"}
        };

        var res = AccountsMerge(input);
    }
    
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        SortedDictionary<string, HashSet<int>> mailCounts = new();

        for (int i = 0; i < accounts.Count; i++)
        {
            for (int j = 1; j < accounts[i].Count; j++)
            {
                if (!mailCounts.ContainsKey(accounts[i][j]))
                {
                    mailCounts[accounts[i][j]] = new HashSet<int>();
                }
                
                mailCounts[accounts[i][j]].Add(i);
            }
        }

        Dictionary<int, HashSet<string>> merged = new();

        foreach (var email in mailCounts)
        {
            foreach (var index in email.Value)
            {
                if (!merged.ContainsKey(index))
                {
                    merged[index] = new HashSet<string>();
                }

                merged[index].Add(email.Key);
            }
        }

        IList<IList<string>> result = new List<IList<string>>();

        foreach (var merge in merged)
        {
            var list = new List<string> {accounts[merge.Key][0]};
            list.AddRange(merge.Value);
            result.Add(list);
        }

        return result;
    }
}