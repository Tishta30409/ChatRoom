using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using System;
using System.Windows.Forms;

namespace ChatRoom.Client.UI
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

            using (var scope = AutofacConfig.Container.BeginLifetimeScope())
            {
                var lobby = scope.Resolve<LobbyForm>();
                var main = scope.Resolve<MainForm>();
                var chatRoom = scope.Resolve<ChatRoomForm>();


                while(main.ShowDialog() == DialogResult.OK)
                {
                    lobby.ShowDialog();
                }

            }

            //Application.Run(new Main());
        }
    }
}
