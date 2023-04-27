using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace ShowOpenApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Foo()
        {
            var processes = Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero).ToList();
            foreach (var item in processes)
            {
                Console.WriteLine(item.ProcessName);
            }

            IntPtr hWnd = processes[5].MainWindowHandle;
            ShowWindow(hWnd, 1);
            SetForegroundWindow(hWnd);
        }

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);
    }
}
