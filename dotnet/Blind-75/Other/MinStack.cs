namespace Blind_75.Other;

public class MinStack
{
    private Stack<int> _stack, _minStack;
    

    public MinStack()
    {
        _stack = new();
        _minStack = new();
    }
    
    public void Push(int val)
    {
        _stack.Push(val);
        _minStack.Push(_minStack.TryPeek(out var peek) ? Math.Min(peek, val) : val);
    }
    
    public void Pop()
    {
        _stack.Pop();
        _minStack.Pop();
    }

    public int Top() => _stack.Peek();

    public int GetMin() => _minStack.Peek();
}