﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TelegraCrawler.WPFApplication.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    WindowSizeControl.Kind = PackIconKind.WindowMaximize;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    WindowSizeControl.Kind = PackIconKind.WindowRestore;
                }
            };
            btnClose.Click += (s, e) =>
            {

                this.Close();
            };

            titleBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };


            titleBar.MouseLeftButtonDown += (s, e) =>
            {
                
                if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
                {
                    if (this.WindowState == WindowState.Normal)
                    {
                        this.WindowState = WindowState.Maximized;

                        WindowSizeControl.Kind = PackIconKind.WindowRestore;
                    }
                    else
                    {
                        this.WindowState = WindowState.Normal;
                        WindowSizeControl.Kind = PackIconKind.WindowMaximize;
                    }
                }
            };
        }
    }
}
