public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if(strs.Length == 0)
        {
            return "";
        }else if(strs.Length == 1)
        {
            return strs[0];
        }
        var strList = strs.ToList();
        int minLength = strList[0].Length;
        var resultStr = strList[0];
        foreach (var str in strList)
        {
            if(str.Length < minLength)
            {
                resultStr = str;
                minLength = str.Length;
            }
        }
        string temp = "";
        string temp2 = "";
        for (int i = 1; i <= resultStr.Length; i++)
        {
            temp2 = temp;
            temp = resultStr.Substring(0, i);
            var flag = true;
            foreach (var str in strList)
            {
                if(!str.Contains(temp))
                {
                    flag = false;
                    break;
                }
            }
            if (flag) continue;
            else return temp2;
        }
        return temp2;
    }
}