using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
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
                var hubClient = scope.Resolve<IHubClient>();

                var lobby = scope.Resolve<LobbyForm>();
                var main = scope.Resolve<MainForm>();
                var chatRoom = scope.Resolve<ChatRoomForm>();

                while (LocalUserData.FormViewType != FormViewType.Leave)
                {
                    switch (LocalUserData.FormViewType)
                    {
                        case FormViewType.Main:
                            var result =  main.ShowDialog();
                            if(result == DialogResult.Cancel)
                            {
                                LocalUserData.FormViewType = FormViewType.Leave;
                            }
                            break;
                        case FormViewType.Lobby:
                            if(lobby.ShowDialog() == DialogResult.Cancel)
                            {
                                LocalUserData.FormViewType = FormViewType.Main;
                                LocalUserData.DisConnect();
                            }
                            break;
                        case FormViewType.ChatRoom:
                            if(chatRoom.ShowDialog() == DialogResult.Cancel)
                            {
                                LocalUserData.FormViewType = FormViewType.Lobby;
                                hubClient.SendAction(new ChatMessageAction()
                                {
                                    Content = "加入房間!",
                                    RoomID = LocalUserData.Room.f_id,
                                    NickName = LocalUserData.Account.f_nickName,
                                });
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
