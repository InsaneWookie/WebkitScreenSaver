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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;
using CefSharp;
using Microsoft.Win32;

namespace WebkitScreenSaverWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebView web_view;
        private DateTime StartTime = DateTime.Now;

        public MainWindow()
        {
            InitializeComponent();

            Mouse.OverrideCursor = Cursors.None;

            RegistryKey reg = Registry.CurrentUser.CreateSubKey(Properties.Settings.Default.RegistryKey);
            string url = (string)reg.GetValue("Url", "http://192.168.1.2");
            reg.Close();

            web_view = new WebView(url, new CefSharp.BrowserSettings());

            this.mainGrid.Children.Add(web_view);
        }


        private void mainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            //mouse move is trigger on startup so we give it one second before we start detecting mouse movements
            if (StartTime.AddSeconds(1) < DateTime.Now)
                this.Close();
        }


        private void mainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Focus();
        }
    }
}
