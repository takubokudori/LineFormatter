using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LineFormatter
{
    class WinApi
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_SETREDRAW = 0x000B;
        private const int EM_LINEFROMCHAR = 0xC9;

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

        // 行数の取得
        public static int GetNumOfLines(Control control)
        {
            return SendMessage(control.Handle, EM_LINEFROMCHAR, -1, 0).ToInt32() + 1;
        }
    }
}
