using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LineFormatter
{
    class WinApi
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public const int WM_SETREDRAW = 0x000B;

        // コントロールの描画停止
        public static void StopDrawing(Control control)
        {
            SendMessage(control.Handle, WM_SETREDRAW, 0, 0);
        }

        // コントロールの描画開始
        public static void StartDrawing(Control control)
        {
            SendMessage(control.Handle, WM_SETREDRAW, 1, 0);
            control.Refresh();
        }
    }
}
