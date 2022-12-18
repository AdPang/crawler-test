


using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace 爬虫测试;



public class Program
{
    public static void Main(string[] args)
    {
        Test test = new Test();
        Console.WriteLine("aaaa");
        Console.WriteLine(test.MyStr.ToString());
        Console.WriteLine("bbbb");
    }
}

public class Test 
{
    public string MyStr { get; set; }

}





//int[] ints1 = new int[9999];
//int[] ints2 = new int[9999];
//Random random = new Random();
//for (int i = 0; i < ints1.Length; i++)
//{
//    ints1[i] = random.Next(100000);
//    ints2[i] = ints1[i];
//}
//var startTime = DateTime.Now;
//QuickSort(ints1, 0, ints1.Length - 1);
//var endTime = DateTime.Now;
//Console.WriteLine($"QuickSort used time:{startTime - endTime}");
//startTime = DateTime.Now;
//PopSort(ints2);
//endTime = DateTime.Now;
//Console.WriteLine($"PopSort used time:{startTime - endTime}");



//foreach (var i in ints1)
//{
//    Console.WriteLine(i);
//}

//foreach (var i in ints2)
//{
//    Console.WriteLine(i);
//}

//static void PopSort(int[] arr)
//{
//    for (int i = 0; i < arr.Length - 1; i++)
//    {
//        for (int j = i ; j < arr.Length; j++)
//        {
//            if (arr[i] > arr[j])
//            {
//                int t = arr[i];
//                arr[i] = arr[j];
//                arr[j] = t;
//            }
//        }

//    }
//}

//static void QuickSort(int[] arr,int start,int end)
//{
//    if (start < end)
//    {
//        int stard = arr[start];
//        int low = start;
//        int high = end;
//        while(low < high)
//        {
//            while(low < high && stard <= arr[high])
//            {
//                high--;
//            }
//            arr[low] = arr[high];
//            while (low < high && arr[low] <= stard)
//            {
//                low++;
//            }
//            arr[high] = arr[low];
//        }
//        arr[low] = stard;
//        QuickSort(arr, start, low);
//        QuickSort(arr, low + 1, end);
//    }
//}










//using System.Collections.Specialized;
//using System.Configuration;
//using System.IO;

//Console.WriteLine(SystemSettingsModel.GetDownloadPath());

//SystemSettingsModel.SetDownloadPath("C:\\Users\\AdPang\\Desktop");

//Console.WriteLine(SystemSettingsModel.GetDownloadPath());

//public static class SystemSettingsModel
//{
//    private static string downloadPath = string.Empty;

//    static SystemSettingsModel()
//    {
//        downloadPath = Environment.CurrentDirectory;
//        string? configPath = ConfigurationManager.AppSettings["DownloadPath"];
//        if (string.IsNullOrEmpty(configPath))
//        {
//            return;
//        }
//        else 
//        {
//            var dir = new DirectoryInfo(configPath);
//            if (dir.Exists)
//            {
//                downloadPath = configPath;
//            }
//        }
//    }

//    public static string GetDownloadPath()
//    {
//        return downloadPath;
//    }
//    public static string SetDownloadPath(string path)
//    {
//        var dir = new DirectoryInfo(path);
//        if (!dir.Exists) { return string.Empty; }
//        Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
//        cfa.AppSettings.Settings["DownloadPath"].Value = dir.FullName;
//        cfa.Save(ConfigurationSaveMode.Modified);
//        downloadPath = dir.FullName;
//        return downloadPath;
//    }
//}


