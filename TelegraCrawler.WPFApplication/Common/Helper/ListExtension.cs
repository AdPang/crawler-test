using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
