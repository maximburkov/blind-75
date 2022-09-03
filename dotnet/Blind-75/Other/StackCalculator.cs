using System.Text;
using Blind_75.Tree;

namespace Blind_75.Other;

#nullable disable
public class StackCalculator : ISolution
{
    public int Calculate(string s)
    {
        // Generate tokens
        var tokens = ToPolishNotation(s);
        Stack<string> stack = new();

        foreach (var token in tokens)
        {
            if (token is "+" or "-")
            {
                int first = int.Parse(stack.Pop());
                int second = int.Parse(stack.Pop());

                stack.Push((token switch
                {
                    "+" => first + second,
                    "-" => second - first,
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

    private List<string> ToPolishNotation(string input)
    {
        var number = "";
        var tokens = new List<string>();
        Stack<string> stack = new();

        void AddOperand()
        {
            if (!string.IsNullOrWhiteSpace(number))
            {
                tokens?.Add(number);
                number = "";
            }
        }

        char prev = Char.MinValue;
        foreach (var c in input)
        {
            if (char.IsDigit(c))
            {
                number += c;
            }
            else if (c is '(')
            {
                stack.Push(c.ToString());
            }
            else if (c is ')')
            {
                AddOperand();
                while (true)
                {
                    var popped = stack.Pop();
                    if (popped == "(") break;
                    tokens.Add(popped);
                }
            }
            else if (c is '+' or '-')
            {
                if (prev == char.MinValue || prev == '(')
                {
                    number += c;
                    continue;
                }
                
                AddOperand();
                if (stack.Count == 0 || stack.Peek() == "(")
                {
                    stack.Push(c.ToString());
                }
                else
                {
                    tokens.Add(stack.Pop());
                    stack.Push(c.ToString());
                }
            }

            if (c != ' ')
                prev = c;
        }

        AddOperand();
        if (stack.Any())
        {
            tokens.Add(stack.Pop());
        }

        return tokens;
    }

    public void Solve()
    {
        // TODO: Negation "- (3 + (4 + 5))" is not working.
        //var res = Calculate("(1  + (4 +5+2)-3 ) +(6+8)");
        var res = Calculate("3 +(-2 +1)");
    }
}