namespace Blind_75.Array;

public class ProductOfArrayExceptSelf : ISolution
{
    public void Solve()
    {
        var res = ProductExceptSelf(new[] {1, 2, 3, 4});
    }
    
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] result = new int[nums.Length];

        result[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] * nums[i];
        }

        int pro = 1;
        for (int i = nums.Length - 1; i > 0; i--)
        {
            result[i] = pro * result[i - 1];
            pro *= nums[i];
        }

        result[0] = pro;
        return result;
    }
}