namespace Blind_75.Array;

public class ReturnMajorityElement : ISolution
{
    public void Solve()
    {
        var res = MajorityElement(new[] {2, 2, 1, 1, 1, 2, 2});
    }
    
    public int MajorityElement(int[] nums)
    {
        int majIndex = 0;
        int count = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[majIndex])
                count++;
            else
                count--;

            if (count == 0)
            {
                majIndex = i;
                count = 1;
            }
        }

        return nums[majIndex];
    }
}