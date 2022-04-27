using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LaunchApps
{
    public partial class AppLauncher : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public AppLauncher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process flash = new Process();
            flash.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

            flash.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
            flash.Start();
            Thread.Sleep(200);

            ShowWindow(flash.MainWindowHandle, 3);
            MoveWindow(flash.MainWindowHandle, Screen.AllScreens[0].Bounds.X, Screen.AllScreens[0].Bounds.Y, Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height, true);
        }

    }
}
