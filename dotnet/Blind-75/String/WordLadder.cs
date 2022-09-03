using System.Security.Cryptography.X509Certificates;

namespace Blind_75.String;

#nullable disable
public class WordLadder : ISolution
{
    public void Solve()
    {
        var res = LadderLength("hit", "cog", new[] {"hot", "dot", "dog", "lot", "log", "cog"});
    }
    
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> words = new HashSet<string>(wordList);
        Queue<string> queue = new();
        int level = 1;

        if (!words.Contains(endWord)) return 0;
        
        queue.Enqueue(beginWord);

        while (queue.Any())
        {
            int count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                string word = queue.Dequeue();

                var characters = word.ToArray();

                for (int k = 0; k < word.Length; k++)
                {
                    char originalChar = word[k];
                    for (int c = 'a'; c <= 'z'; c++)
                    {
                        if (c == characters[k]) continue;

                        characters[k] = (char)c;
                        var afterChange = new System.String(characters);
                        if (afterChange == endWord)
                        {
                            return level + 1;
                        }
                        else if (words.Contains(afterChange))
                        {
                            queue.Enqueue(afterChange);
                            words.Remove(afterChange);
                        }
                    }

                    characters[k] = originalChar;
                }
            }

            level++;
        }
        
        return 0;
    }
}