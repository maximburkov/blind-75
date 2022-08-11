namespace Blind_75.Other;

public class TimeMap
{
    private readonly Dictionary<string, List<(int Timestamp, string Value)>> _store;

    public TimeMap()
    {
        _store = new Dictionary<string, List<(int, string)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!_store.ContainsKey(key))
        {
            _store.Add(key, new List<(int, string)>());
        }
        
        _store[key].Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) 
    {
        if (_store.ContainsKey(key))
        {
            var list = _store[key];
            int l = 0;
            int r = list.Count;

            while (l <= r)
            {
                int m = (l + r) / 2;
                if (list[m].Timestamp <= timestamp && (m == list.Count - 1 || list[m+1].Timestamp > timestamp))
                {
                    return list[m].Value;
                }
                else if (list[m].Timestamp > timestamp)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return string.Empty;
        }

        return string.Empty;
    }
}
