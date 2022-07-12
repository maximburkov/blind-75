namespace Blind_75.Array;

public class MaximumSubarray : ISolution
{
    // Kadane's algorithm https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
    public int MaxSubArray(int[] nums)
    {
        int allTimeMax = int.MinValue;
        int currentSum = 0;

        foreach (var num in nums)
        {
            currentSum += num;

            if (currentSum > allTimeMax)
                allTimeMax = currentSum;

            if (currentSum < 0)
                currentSum = 0;
        }

        return allTimeMax;
    }
    
    public void Solve()
    {
        var res = MaxSubArray(new[] {-2, -3, 4, -1, -2, 1, 5, -3});
    }
}