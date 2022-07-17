namespace Blind_75.Other;

public class MyQueue
{
    private readonly Stack<int> _tail = new (), _head = new ();
    

    public MyQueue() {
        
    }
    
    public void Push(int x) {
        _tail.Push(x);
    }
    
    public int Pop()
    {
        if (_head.TryPop(out int res))
        {
            return res;
        }

        MoveStack();
        return _head.Pop();
    }
    
    public int Peek()
    {
        if (_head.TryPeek(out int res))
        {
            return res;
        }

        MoveStack();
        return _head.Peek();
    }
    
    public bool Empty()
    {
        return !_head.Any() && !_tail.Any();
    }

    private void MoveStack()
    {
        while (_tail.TryPop(out int item))
        {
            _head.Push(item);
        }
    }
}


public class QueueUsingStacks : ISolution
{
    public void Solve()
    {
    }
}