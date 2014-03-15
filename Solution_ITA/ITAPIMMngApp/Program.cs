using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ITAMngApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashAppContext context = new SplashAppContext(new GMngMainForm(), new Splash());
            Application.Run(context);
        }


        public static GMngMainForm MainApp = null;
    }
}