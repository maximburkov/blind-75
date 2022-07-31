namespace Blind_75.Other;

public class PolishNotationEvaluate : ISolution
{
    public void Solve()
    {
        var res = EvalRPN(new[] {"2", "1", "+", "3", "*"});
    }

    public int EvalRPN(string[] tokens)
    {
        Stack<string> stack = new();

        foreach (var token in tokens)
        {
            if (token is "+" or "-" or "*" or "/")
            {
                int first = int.Parse(stack.Pop());
                int second = int.Parse(stack.Pop());

                stack.Push((token switch
                {
                    "+" => first + second,
                    "-" => second - first,
                    "*" => first * second,
                    "/" => second / first,
                    _ => throw new InvalidOperationException()
                }).ToString());
            }
            else
            {
                stack.Push(token);
            }
        }

        return int.Parse(stack.Peek());
    }
}