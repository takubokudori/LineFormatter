using System;
using System.Threading;
using System.Windows.Forms;

namespace LineFormatter
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += ApplicationThreadExceptionHandler;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void ApplicationThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($@"エラーが発生しました: {e.Exception.Message}");
        }
    }
}
