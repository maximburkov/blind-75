namespace Blind_75.Other;

public class SumTree : ISolution
{
    public void Solve()
    {
        var res = ThreeSum(new[] {0, 1, 1});

    }

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        System.Array.Sort(nums);
        int n = nums.Length;
        IList<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < n - 2; i++)
        {
            if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
            {
                int l = i + 1;
                int r = n - 1;

                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        result.Add(new List<int> {nums[i], nums[l], nums[r]});
                        while (l < r && nums[l] == nums[l + 1]) l++;
                        while (l < r && nums[r] == nums[r - 1]) r--;
                        l++;
                        r--;
                    }
                    else if (sum < 0)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }
        }

        return result;
    }
}