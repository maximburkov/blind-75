namespace Blind_75.Tree;

#nullable disable
public class Codec
{
    private const string NullString = "n";
    private Queue<int?> _queue;

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        _queue = new Queue<int?>();
        SerializeTraverse(root);
        return string.Join(',', _queue.Select(i => i is null ? NullString : i.ToString()));
    }

    private void SerializeTraverse(TreeNode node)
    {
        if(node is null)
            _queue.Enqueue(null);
        else
        {
            _queue.Enqueue(node.val);
            
            SerializeTraverse(node.left);
            SerializeTraverse(node.right);
        }
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        _queue = new Queue<int?>(data.Split(',').Select(i => i == NullString ? (int?)null : int.Parse(i)));
        return DeserializeTraverse();
    }

    private TreeNode DeserializeTraverse()
    {
        if (_queue.TryDequeue(out var val))
        {
            if (val is null)
                return null;

            var node = new TreeNode();
            node.val = val.Value;
            node.left = DeserializeTraverse();
            node.right = DeserializeTraverse();

            return node;
        }
        
        return null;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));