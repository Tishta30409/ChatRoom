using Autofac;
using ChatRoom.Backstage.Forms.UI;
using ChatRoom.Client.UI.Applibs;
using System;
using System.Windows.Forms;

namespace ChatRoom.Backstage.UI
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var main = AutofacConfig.Container.BeginLifetimeScope().Resolve<MainForm>();
            main.ShowDialog();
        }
    }
}
