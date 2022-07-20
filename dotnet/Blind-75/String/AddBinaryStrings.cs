namespace Blind_75.String;

public class AddBinaryStrings : ISolution
{
    public string AddBinary(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int sum = 0;
        string res = string.Empty;

        while (i >= 0 || j >= 0 || sum == 1)
        {
            sum += i >= 0 ? a[i] - '0' : 0;
            sum += j >= 0 ? b[j] - '0' : 0;

            res = (char) (sum % 2 + '0') + res;
            sum /= 2;
            i--;
            j--;
        }

        return res;
    }
    
    
    public void Solve()
    {
        var res = AddBinary("11", "1");
        
    }
}