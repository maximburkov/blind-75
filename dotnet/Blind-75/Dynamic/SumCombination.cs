using System.ComponentModel;

namespace Blind_75.Dynamic;

public class SumCombination : ISolution
{
    public void Solve()
    {
        var res = CombinationSum(new[] {2, 3, 5}, 8);
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        FindCombinations(0, candidates, target, 0, new LinkedList<int>(), result);
        return result;
    }

    private void FindCombinations(int index, int[] array, int target, int sum, LinkedList<int> usedList, IList<IList<int>> resultList)
    {
        if(usedList.Count > 0)
            sum += usedList.Last();

        if (sum == target)
        {
            resultList.Add(usedList.ToList());
        }
        else if (sum < target)
        {
            for (int i = index; i < array.Length; i++)
            {
                usedList.AddLast(array[i]);
                FindCombinations(i, array, target, sum, usedList, resultList);
                usedList.RemoveLast();
            }
        }
    }
}