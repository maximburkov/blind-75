using System.Threading.Channels;

namespace Blind_75.Array;

public class TwoSum : ISolution
{
    public void Solve()
    {
        var array = new int[] {2, 7, 11, 15};
        int target = 9;
        var res = GetTwoSum(array, target);
    }
    
    public int[] GetTwoSum(int[] nums, int target)
    {
        Dictionary<int, HashSet<int>> map = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], new HashSet<int>(new []{i}));
            }
            else
            {
                map[nums[i]].Add(i);
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int dif = target - nums[i];

            if (map.ContainsKey(dif) && map[dif].Any(el => el != i))
            {
                return new[] {i, map[dif].First(el => el != i)};
            }
        }

        throw new Exception("Not found.");
    }
}