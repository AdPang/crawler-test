// See https://aka.ms/new-console-template for more information
using Nancy.Json;
using Newtonsoft.Json;
using SeleniumUtil;
using SeleniumUtil.Entitys;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Text;
using 爬虫测试;
using Size = SeleniumUtil.Entitys.Size;

using System.Linq;
using RestSharp;

namespace 爬虫测试
{
    public class Program
    {
        public static void Main()
        {

            var files = GetAllFileByContainsStrName(@"C:\Users\AdminPang\Downloads\game", "百度");
            Console.WriteLine(files.Count);

        }

        static void GetAllFiles(DirectoryInfo rootDir,List<FileInfo> files)
        {
            var childrenDir = rootDir.GetDirectories();
            foreach (var dir in childrenDir)
            {
                GetAllFiles(dir, files);
                files.AddRange(dir.GetFiles());
            }
        }

        static bool IsFileContentContainsStr(FileInfo file,string containsContentStr)
        {
            string contents = File.ReadAllText(file.FullName);
            return contents.Contains(containsContentStr);
        }

        static List<FileInfo> GetAllFileByContainsStrName(string path,string containsName)
        {
            var files = new DirectoryInfo(path);
            var filesList = new List<FileInfo>();
            GetAllFiles(files, filesList);
            filesList = filesList.Where(x => IsFileContentContainsStr(x, containsName)).ToList();
            return filesList;
        }

    }
}






/*
11.任意给定一个字符串数组string[] factors，求其中两个字符串长度乘积 length(factors [i]) * length (factors[j]) 的最大值，要求factors [i]和factors [j]自身及相互之间都不能含有相同的字母。假定所有字符串的字母都是小写。如果没有符合条件的两个单词，返回 0。
条件：可以使用数组和string的Length方法/属性，不能使用.net库基础类型以外的数据类型和Liqu方法。
示例 1：输入: ["adcw","daz","too","dar","xftn","adcbef"]   输出: 16  ("adcw", "xftn")
示例 2：输入: ["a","ad","adc","b","cb","dcb","adcb"]   输出: 4  ("ad ", "cb")
示例 3：输入: ["c","cc","ccc","cccc"]   输出: 0  (没有符合条件的两个单词)
示例 4：输入: ["cc","cdd","dddd"]   输出: 8  ("cc","dddd")
 */


//using System;

//string? input = Console.ReadLine();
//DateTime startTime = DateTime.Now;
//input = input.TrimStart('[').TrimEnd(']');
//var strArr = input.Split(',').ToList();
//List<string> newStrlist = new();

//strArr.ForEach(x =>
//{
//    var tempStr = x.TrimStart('\"').TrimEnd('\"');
//    if (!CheckRepeat(tempStr))
//    {
//        newStrlist.Add(tempStr);
//    }
//});
//int firstStrIndex = 0;
//int secoundStrIndex = 0;
//int maxProduct = 0;
//newStrlist.ForEach(firstStr =>
//{
//    var currentIndex = newStrlist.IndexOf(firstStr);
//    var tempStrList = newStrlist.Skip(currentIndex + 1).ToList();
//    tempStrList.ForEach(secondStr =>
//    {
//        var hasRepeat = false;
//        foreach (var c in firstStr)
//        {
//            if (secondStr.Contains(c))
//            {
//                hasRepeat = true;
//                break;
//            }
//        }
//        if (!hasRepeat)
//        {
//            if (maxProduct <= firstStr.Length * secondStr.Length)
//            {
//                maxProduct = firstStr.Length * secondStr.Length;
//                firstStrIndex = newStrlist.IndexOf(firstStr);
//                secoundStrIndex = newStrlist.IndexOf(secondStr);
//            }
//        }
//    });
//});
//if (maxProduct!=0)
//{
//    Console.WriteLine($"{maxProduct}  (\"{newStrlist[firstStrIndex]}\",\"{newStrlist[secoundStrIndex]}\")");
//}
//else
//{
//    Console.WriteLine("0  (没有符合条件的两个单词)");
//}

//bool CheckRepeat(string str)
//{
//    for (int i = 0; i < str.Length - 1; i++)
//    {
//        for (int j = i + 1; j < str.Length; j++)
//        {
//            if (str[i] == str[j])
//            {
//                return true;
//            }
//        }
//    }
//    return false;
//}

//newStrlist.ForEach(x => global::System.Console.WriteLine(x.ToString()));

/*int maxProduct = 0;
int firstIndex = 0, secondIndex = 0;
for (int i = 0; i < strArr.Length - 1; i++)
{
    for (int j = i + 1; j < strArr.Length; j++)
    {
        bool flag = false;
        string str1 = strArr[i].TrimEnd('\"').TrimStart('\"');
        string str2 = strArr[j].TrimEnd('\"').TrimStart('\"');
        if (CheckRepeat(str1) || CheckRepeat(str2))
        {
            continue;
        }
        foreach (char c in str2)
        {
            if (str1.IndexOf(c) >= 0)
            {
                flag = true;
                break;
            }
        }
        if (flag)
        {
            continue;
        }
        if (maxProduct < str1.Length * str2.Length)
        {
            maxProduct = str1.Length * str2.Length;
            firstIndex = i;
            secondIndex = j;
        }
    }
}
Console.WriteLine("耗时:" + (DateTime.Now - startTime));
if (maxProduct > 0)
{
    Console.WriteLine($"{maxProduct} ({strArr[firstIndex]},{strArr[secondIndex]})");
}
else
{
    Console.WriteLine(0);
}

bool CheckRepeat(string str)
{
    for (int i = 0; i < str.Length - 1; i++)
    {
        for (int j = i + 1; j < str.Length; j++)
        {
            if (str[i] == str[j])
            {
                return true;
            }
        }
    }
    return false;
}
*/

//System.Diagnostics.Process process = new System.Diagnostics.Process();
//var a = FileTypeRegister.GetFileTypeRegInfo(".docx");


//Console.WriteLine(path);
//DirectoryInfo directory = new DirectoryInfo(path);
//List<FileInfo> fileInfos = new();
//DateTime startTime = DateTime.Now;
//GetAllFileFromDir(directory, fileInfos);
//DateTime endTime = DateTime.Now;
//Console.WriteLine("用时:" + (endTime - startTime));
//fileInfos.ForEach(x =>
//{
//    global::System.Console.WriteLine(x.FullName);
//});

//void GetAllFileFromDir(DirectoryInfo dir,List<FileInfo> fileInfos)
//{
//    var dirFiles = dir.GetFiles();
//    if (dirFiles.Length > 0)
//    {
//        fileInfos.AddRange(dirFiles);
//    }
//    var dirChildrenDir = dir.GetDirectories();
//    foreach (var dirChild in dirChildrenDir)
//    {
//        GetAllFileFromDir(dirChild, fileInfos);
//    }
//}


//while (true)
//{

//    Thread.Sleep(3000);
//    Console.WriteLine("还活着");
//}

/*List<string> fhs = new List<string>()
{
    "ipx-120","ssis-301","abw-044","aas-grh","sag-458"
};
var sb = new StringBuilder();
var a = GetHDSerial("c", sb);
Console.WriteLine(sb.ToString());

var b = Test.GetDiskVolume("f"); //8ece2b5c e86ca35 ba5883ff                c97e2ce6 f05e8b66 b39d6
Console.WriteLine(b);*/

//JavaScriptSerializer serializer = new JavaScriptSerializer();

/*

#region 将List<>转换为Json
string List2JSON(List<object> objlist, string classname)
{
    string result = "{";
    if (classname.Equals(typeof(string)))//如果没有给定类的名称，那么自做聪明地安一个
    {
        object o = objlist[0];
        classname = o.GetType().ToString();
    }
    result += "\"" + classname + "\":[";
    bool firstline = true;//处理第一行前面不加","号
    foreach (object oo in objlist)
    {
        if (!firstline)
        {
            result = result + "," + OneObjectToJSON(oo);
        }
        else
        {
            result = result + OneObjectToJSON(oo) + "";
            firstline = false;
        }
    }
    return result + "]}";
}

string OneObjectToJSON(object o)
{
    string result = "{";
    List<string> ls_propertys = new List<string>();
    ls_propertys = GetObjectProperty(o);
    foreach (string str_property in ls_propertys)
    {
        if (result.Equals("{"))
        {
            result = result + str_property;
        }
        else
        {
            result = result + "," + str_property + "";
        }
    }
    return result + "}";
}

List<string> GetObjectProperty(object o)
{
    List<string> propertyslist = new List<string>();
    PropertyInfo[] propertys = o.GetType().GetProperties();
    foreach (PropertyInfo p in propertys)
    {
        propertyslist.Add("\"" + p.Name.ToString() + "\":\"" + p.GetValue(o, null) + "\"");
    }
    return propertyslist;
}

#endregion

int GetHDSerial(string driveLetter, StringBuilder serialNumber)
{
    try
    {
        ManagementObjectSearcher mc1 = new ManagementObjectSearcher("select * from Win32_DiskDrive");
        Dictionary<int, string> dic_indexAndServerNumber = new Dictionary<int, string>();
        foreach (ManagementObject item in mc1.Get())
        {
            int index = int.Parse(item["Index"].ToString());
            string SerialNumber = item["SerialNumber"].ToString().Trim();
            if (!dic_indexAndServerNumber.ContainsKey(index))
            {
                dic_indexAndServerNumber.Add(index, SerialNumber);
            }
        }
        mc1 = new ManagementObjectSearcher("select * from Win32_LogicalDiskToPartition");
        Dictionary<string, string> dic_logicaldisk = new Dictionary<string, string>();
        foreach (ManagementObject item in mc1.Get())
        {
            string driname = item["Dependent"].ToString().Split('=')[1].Split(':')[0].Replace("\"", "");
            driveLetter = driveLetter.Replace(":", "");
            driveLetter = driveLetter.ToUpper();
            if (driveLetter == driname)
            {
                int index = int.Parse(item["Antecedent"].ToString().Split('=')[1].Split(',')[0].Split('#')[1]);
                if (dic_indexAndServerNumber.ContainsKey(index))
                {
                    serialNumber.Append(dic_indexAndServerNumber[index]);
                    return 0;
                }
            }

        }
        return -1;
    }
    catch (Exception ex)
    {
        return -1;
    }
}

Dictionary<string, string> PaTmd(List<string> fhs)
{
    var data = new CrawlerMain(browser: BrowserEnum.Edge, isEnableVerboseLogging: true, size: new Size(800, 1200));
    data.GoToUrl("https://javdb.com/");
    var success = data.FindElementsByClassName("is-success");
    success.Click();
    Thread.Sleep(200);

    Dictionary<string, string> results = new Dictionary<string, string>();

    foreach (var fh in fhs)
    {
        var url = GetSearchUrl(fh);
        data.GoToUrl(url);
        Thread.Sleep(200);
        var strspilt = SearchView(data, fh).Split('♀').ToList();
        strspilt.RemoveAt(strspilt.Count - 1);
        var actors = string.Join(",", strspilt);
        results.Add(fh, actors);
    }
    return results;
}

string SearchView(CrawlerMain data, string fh)
{

    fh = fh.ToUpperInvariant();
    var gridItems = data.FindElementsByClassNames("grid-item");
    var girdItem = gridItems.Where(x => x.Text.Contains(fh)).FirstOrDefault();
    girdItem.Click();
    Thread.Sleep(300);

    return GetActors(data);
}


string GetSearchUrl(string fh)
{
    return "https://javdb.com/search?q=" + fh + "&f=all";
}

string GetActors(CrawlerMain data)
{
    var wd = data.FindElementsByClassNames("value");

    var item = wd.Where(x => x.Text.Contains('♀')).FirstOrDefault();

    return item.Text;
}

*/