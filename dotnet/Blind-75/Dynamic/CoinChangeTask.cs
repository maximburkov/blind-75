namespace Blind_75.Dynamic;

public class CoinChangeTask : ISolution
{
    public void Solve()
    {
        var res = CoinChange(new[] {1}, 0);
    }
    
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0)
            return 0;
        
        int[] countingArr = new int[amount + 1];

        for (int i = 1; i <= amount; i++)
        {
            int min = int.MaxValue;
            foreach (var coin in coins)
            {
                if (i - coin >= 0 && countingArr[i - coin] != int.MaxValue)
                {
                    min = Math.Min(min, countingArr[i - coin] + 1);
                }
            }

            countingArr[i] = min;
        }

        return countingArr[amount] == int.MaxValue ? -1 : countingArr[amount];
    }
}