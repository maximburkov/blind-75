namespace Blind_75.Other;

public class FindSubsets : ISolution
{
    public void Solve()
    {
        var res = Subsets(new[] {1, 2, 3});
    }
    
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>();
        Backtrack(0, nums, new LinkedList<int>(), res);
        return res;
    }

    private void Backtrack(int index, int[] nums, LinkedList<int> used, IList<IList<int>> result)
    {
        result.Add(used.ToList());

        for (int i = index; i < nums.Length; i++)
        {
            used.AddLast(nums[i]);
            Backtrack(i + 1, nums, used, result);
            used.RemoveLast();
        }
    }
}