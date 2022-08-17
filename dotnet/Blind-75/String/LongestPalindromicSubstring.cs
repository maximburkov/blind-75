namespace Blind_75.String;

public class LongestPalindromicSubstring : ISolution
{
    public void Solve()
    {
        // better solution: https://leetcode.com/problems/longest-palindromic-substring/discuss/110368/Accepted-C-easy-to-understand-solution-with-explanation.
        var res = LongestPalindrome("cbbd");
    }
    
    public string LongestPalindrome(string s)
    {
        string maxPalindrome = s[0].ToString();
        
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                int l = i, r = j, lenght = j - i + 1;
                bool isPalindrome = true;
                
                while (l < r && isPalindrome)
                {
                    if (s[l] == s[r])
                    {
                        l++;
                        r--;
                    }
                    else
                    {
                        isPalindrome = false;
                    }
                }

                if (isPalindrome && lenght > maxPalindrome.Length)
                {
                    maxPalindrome = s.Substring(i, lenght);
                }
            }
        }

        return maxPalindrome;
    }
}