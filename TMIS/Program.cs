using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

using System.Threading;
using WHC.Framework.Commons;
using TMIS.Forms;

namespace TMIS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //InitDataConfig();
            GlobalMutex();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //******启动代码**********
            Splasher.Show(typeof(frmSplash));
            Application.Run(new MainForm());
            //Application.Run(new FormTools());
            
        }

        //private static void InitDataConfig()
        //{
        //    string connectionString = "";//= string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}Database1.mdb;User ID=Admin;Jet OLEDB:Database Password=;",
        //    //System.AppDomain.CurrentDomain.BaseDirectory);
        //    AppConfig config = new AppConfig();
        //    config.SetConnectionString("DataAccess", connectionString);

        //    //更新配置文件，以便起效
        //    ConfigurationManager.RefreshSection("dataConfiguration");
        //    ConfigurationManager.RefreshSection("connectionStrings");
        //    ConfigurationManager.RefreshSection("appSettings");
        //}

        private static Mutex mutex = null;
        /// <summary>
        /// 程序只能单例运行
        /// </summary>
        private static void GlobalMutex()
        {
            // 是否第一次创建mutex
            bool newMutexCreated = false;
            string mutexName = "Global\\" + "TMIS";//系统名称，Global为全局，表示即使通过通过虚拟桌面连接过来，也只是允许运行一次
            try
            {
                mutex = new Mutex(false, mutexName, out newMutexCreated);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
            }

            // 第一次创建mutex
            if (newMutexCreated)
            {
                Console.WriteLine("程序已启动");
                //todo:此处为要执行的任务
            }
            else
            {
                MessageUtil.ShowTips("另一个窗口已在运行，不能重复运行。");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);//退出程序
            }
        }
    }
}
