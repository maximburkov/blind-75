namespace Blind_75.Other;

public class Permutations : ISolution
{
    public void Solve()
    {
        var res = Permute(new[] {1, 2, 3});
    }
    
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        FindPermutations(nums, new HashSet<int>(), result);
        return result;
    }

    private void FindPermutations(int[] nums, HashSet<int> used, List<IList<int>> result)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (!used.Contains(nums[i]))
            {
                used.Add(nums[i]);

                if (used.Count == nums.Length)
                {
                    result.Add(used.ToList());
                }
                else
                {
                    FindPermutations(nums, used, result);
                }

                used.Remove(nums[i]);
            }
        }
    }
}