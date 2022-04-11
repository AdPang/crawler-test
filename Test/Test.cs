using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Test
    {
        /// <summary>
        /// 设置剪贴板的文本内容
        /// </summary>
        /// <param name="s">文本内容</param>
        public static void SetText(string s)
        {
            Clipboard.SetDataObject(s ?? "");
        }

        /// <summary>
        /// 获取剪贴板中的文本内容
        /// </summary>
        /// <returns>返回剪贴板文本</returns>
        public static string GetText()
        {
            IDataObject iData = Clipboard.GetDataObject();
            return (string)iData.GetData(DataFormats.Text);
        }

        /// <summary>
        /// 获取剪贴板位图格式数据（比如从画图软件里复制的图片……）
        /// </summary>
        /// <returns>位图</returns>
        public static Bitmap GetBitmap()
        {
            IDataObject iData = Clipboard.GetDataObject();
            //确定此实例中存储的数据是否与指定的格式关联，或是否可以转换成指定的格式
            if (iData.GetDataPresent(DataFormats.Bitmap))
            {
                Bitmap bt = (Bitmap)iData.GetData(DataFormats.Bitmap);
                return bt;
            }
            return null;
        }
    }
}
