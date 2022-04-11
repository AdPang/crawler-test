using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 爬虫测试
{
    public class InterceptKeys
    {
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;

        /// <summary>
        /// 启动监测程序
        /// </summary>
        public static void RunHook()
        {
            _hookID = SetHook(_proc);
        }

        /// <summary>
        /// 关闭监测程序
        /// </summary>
        public static void UnHook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        /// <summary>
        /// 设置默认值与数据
        /// </summary>
        /// <param name="initInt"></param>
        /// <param name="outString">"F:\图片\精品分类\品牌图片\google徽标\@_@.gif"</param>
        public static void Init(int initInt, string outString)
        {
            i = initInt;
            str = outString;
        }

        private static int i = 0;
        private static string str = @"I:\over\Images\google\@_@.jpg";

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                //同时按下Ctrl+V键的时候
                if (Control.ModifierKeys == Keys.Control && key.Equals(Keys.V))
                {
                    //获得剪切板数据
                    string data = Clipboard.GetText(TextDataFormat.UnicodeText);
                    //重新设置剪切板数据
                    DataObject m_data = new DataObject();
                    m_data.SetData(DataFormats.Text, true, str.Replace("@_@", Convert.ToString(++i)));
                    Clipboard.SetDataObject(m_data, true);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        #region 调用API

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook,

        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

        IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }
}
