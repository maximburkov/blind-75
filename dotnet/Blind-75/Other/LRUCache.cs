namespace Blind_75.Other;

#nullable disable
public class LRUCache
{
    private readonly LinkedList<(int Key, int Value)> _list;
    private int _maxOperationsCount = 200001;
    private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> _nodesMap;
    private int _capacity;
    

    public LRUCache(int capacity)
    {
        _list = new LinkedList<(int, int)>();
        _nodesMap = new Dictionary<int, LinkedListNode<(int Key, int Value)>>();
        _capacity = capacity;
    }
    
    public int Get(int key)
    {
        if (_nodesMap.ContainsKey(key))
        {
            var node = _nodesMap[key];
            _list.Remove(node);
            _list.AddLast(node);
            return node.Value.Value;
        }

        return -1;
    }
    
    public void Put(int key, int value)
    {
        var newNode = new LinkedListNode<(int Key, int Value)>((key, value));
        if (_nodesMap.ContainsKey(key))
        {
            var existingNode = _nodesMap[key];
            _list.Remove(existingNode);
        }
        else
        {
            if (_list.Count >= _capacity)
            {
                var firstNode = _list.First;
                _list.RemoveFirst();
                if(firstNode is not null) _nodesMap.Remove(firstNode.Value.Key);
            }
        }
        
        _list.AddLast(newNode);
        _nodesMap[key] = newNode;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
 
 /*
var cache = new LRUCache(2);
cache.Put(1, 1);
cache.Put(2, 2);
var res = cache.Get(1);
cache.Put(3, 3);
res = cache.Get(2);
cache.Put(4, 4);
res = cache.Get(1);
res = cache.Get(3);
res = cache.Get(4);
Console.WriteLine(res);
*/