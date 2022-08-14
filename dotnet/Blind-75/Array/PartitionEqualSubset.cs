namespace Blind_75.Array;

public class PartitionEqualSubset : ISolution
{
    public void Solve()
    {
        var res = CanPartition(new[] {1, 5, 11, 5});
    }
    
    public bool CanPartition(int[] nums) {
        if(nums.Length < 2)
            return false;

        int sum = nums.Sum();

        if (sum % 2 == 1)
            return false;

        int n = nums.Length;
        int half = sum / 2;
        bool[,] dp = new bool[half + 1, n + 1];

        for (int i = 0; i <= n; i++)
        {
            dp[0, i] = true;
        }

        for (int i = 1; i <= half; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                dp[i, j] = dp[i, j - 1];
                int currentNumber = nums[j - 1];
                if (i - currentNumber >= 0 && !dp[i, j])
                {
                    dp[i, j] = dp[i - currentNumber, j - 1];
                }
            }
        }

        return dp[half, n];
    }
}