namespace Blind_75.Tree;

public class ImplementTrie : ISolution
{
    public void Solve()
    {
        throw new NotImplementedException();
    }
}

public class Trie
{
    public class TrieNode
    {
        public TrieNode(char letter)
        {
            Letter = letter;
            Children = new ();
        }
    
        public char Letter { get; set; }
    
        public Dictionary<char, TrieNode> Children { get; set; }
    
        public bool HasWord { get; set; }
    }
    
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode('-');
    }
    
    public void Insert(string word)
    {
        TrieNode current = root;
        
        foreach (var c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new TrieNode(c);
            }
            
            current = current.Children[c];
        }

        current.HasWord = true;
    }
    
    public bool Search(string word) 
    {
        TrieNode current = root;
        
        foreach (var c in word)
        {
            if (!current.Children.ContainsKey(c))
                return false;
            
            current = current.Children[c];
        }

        return current.HasWord;
    }
    
    public bool StartsWith(string prefix) 
    {
        TrieNode current = root;
        
        foreach (var c in prefix)
        {
            if (!current.Children.ContainsKey(c))
                return false;
            
            current = current.Children[c];
        }

        return true;
    }
}