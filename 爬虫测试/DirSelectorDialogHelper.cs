﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winform = System.Windows.Forms;

namespace 爬虫测试
{
    public class DirSelectorDialogHelper
    {
        public static string GetPathByFolderBrowserDialog()
        {
            Winform.FolderBrowserDialog dialog = new()
            {
                Description = "请选择文件夹路径"
            };
            dialog.ShowDialog();
            return dialog.SelectedPath;
        }

        public static string GetPathByFileBrowserDialog()
        {
            Winform.OpenFileDialog openFileDialog = new();
            string path = string.Empty;
            if (openFileDialog.ShowDialog() == Winform.DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            return path;
        }
    }
}
