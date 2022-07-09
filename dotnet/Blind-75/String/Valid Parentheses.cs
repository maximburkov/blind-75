namespace Blind_75.String;

// https://leetcode.com/problems/valid-parentheses/
public class Valid_Parentheses : ISolution
{
    public void Solve()
    {
        var res = IsValid("");
    }
    
    public bool IsValid(string s)
    {
        Stack<char> stack = new();

        if (s.Length % 2 != 0) return false;

        foreach (var character in s)
        {
            if (IsOpening(character))
            {
                stack.Push(character);
            }
            else
            {
                if (stack.TryPop(out var popped))
                {
                    if (!IsMatching(popped, character))
                        return false;
                }
                else
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    private bool IsOpening(char character) => character is '(' or '[' or '{';

    private bool IsMatching(char opening, char closing) => opening switch
    {
        '(' => closing == ')',
        '[' => closing == ']',
        '{' => closing == '}',
        _ => throw new ArgumentException()
    };
}