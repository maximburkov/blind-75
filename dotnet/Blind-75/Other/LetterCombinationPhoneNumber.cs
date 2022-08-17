namespace Blind_75.Other;

public class LetterCombinationPhoneNumber : ISolution
{
    public void Solve()
    {
        var res = LetterCombinations("7");
    }
    
    public IList<string> LetterCombinations(string digits)
    {
        List<string> result = new List<string>();

        if (string.IsNullOrEmpty(digits))
            return result;
        
        var lettersPerButton = Enumerable.Repeat(3, 5).ToList();
        lettersPerButton.AddRange(new []{4,3,4});
        var ranges = new (int Start, int End)[lettersPerButton.Count];

        int index = 0;
        for (int i = 0; i < lettersPerButton.Count; i++)
        {
            ranges[i] = (index + 'a', index + lettersPerButton[i] - 1 + 'a');
            index += lettersPerButton[i];
        }
        
        BackTrack(digits, 0, ranges, string.Empty, result);

        return result;
    }

    public void BackTrack(string digits, int digitIndex, (int Start, int End)[] ranges, string currentString, IList<string> result)
    {
        if (digitIndex == digits.Length)
        {
            result.Add(currentString);
            return;
        }

        int rangeIndex = digits[digitIndex] - '0' - 2;
        for (int j = ranges[rangeIndex].Start; j <= ranges[rangeIndex].End; j++)
        {
            BackTrack(digits, digitIndex + 1, ranges, currentString + (char) j, result);
        }
    }
}