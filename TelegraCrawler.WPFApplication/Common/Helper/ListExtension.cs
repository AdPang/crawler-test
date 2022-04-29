using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelegraCrawler.WPFApplication.Common.Helper
{
    public static class ListExtension
    {
        public static List<List<T>> SpiltPair<T>(this IEnumerable<T> list, int n = 10)
        {
            List<List<T>> listDir = new();
            for (int i = 0; i < list.Count() / n; i++)
                listDir.Add(list.Skip(i * n).Take(n).ToList());
            listDir.Add(list.Skip(list.Count() / n * n).Take(list.Count() % n).ToList());
            return listDir;
        }


        public static void FindImgNode(this HtmlNode parentNode,Func<HtmlNode, bool> func, ICollection<HtmlNode> nodes)
        {
            foreach (var item in parentNode.ChildNodes)
            {
                item.FindImgNode(func, nodes);
                if (func.Invoke(item))
                {
                    nodes.Add(item);
                }
            }
        }
    }
    public static class StringExtension
    {
        public static bool IsUrl(this string url)
        {
            try
            {
                string reg = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(url, reg);
            }
            catch
            {
                return false;
            }
        }
    }
}
