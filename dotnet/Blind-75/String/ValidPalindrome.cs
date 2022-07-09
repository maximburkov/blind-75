namespace Blind_75.String;

public class ValidPalindrome : ISolution
{
    public void Solve()
    {
        var res = IsPalindrome("A man, a plan, a canal: Panama");
        Console.WriteLine(res);
    }
    
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();
        int l = 0, r = s.Length - 1;

        while (l <= r)
        {
            if(!Char.IsLetterOrDigit(s[l]))
                l++;
            else if(!Char.IsLetterOrDigit(s[r]))
                r--;

            else if (s[l] == s[r])
            {
                l++;
                r--;
            }
            else
                return false;
        }

        return true;
    }
}