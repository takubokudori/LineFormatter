/*
Copyright 2021 takubokudori

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
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
