using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace 今日剩余
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            #region 防止多开

            bool onlyInstance = false;
            Mutex mutex = new Mutex(true, Application.ProductName, out onlyInstance);
            if (!onlyInstance)
            {
                return;
            }
            Application.Run(new 今日剩余());
            GC.KeepAlive(mutex);

            #endregion 防止多开

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 今日剩余());
        }
    }
}