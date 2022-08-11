namespace Blind_75.Other;

public class SortColorsTask : ISolution
{
    public void Solve()
    {
        var input = new[] {2, 0, 2, 1, 1, 0};
        SortColors(input);
        Console.WriteLine(input);
    }
    
    public void SortColors(int[] nums)
    {
        int n = 3;
        int[] counts = new int[n];

        foreach (var color in nums)
        {
            counts[color]++;
        }

        int index = 0;
        for (int color = 0; color < n && index < nums.Length; color++)
        {
            for (int i = 0; i < counts[color]; i++)
            {
                nums[index] = color;
                index++;
            }
        }
    }
}