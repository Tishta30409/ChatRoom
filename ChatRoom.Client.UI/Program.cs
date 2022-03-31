using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.Service;
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

            var hubClient = AutofacConfig.Container.Resolve<IHubClient>();


            var localData = AutofacConfig.Container.Resolve<LocalData>();


            using (var scope = AutofacConfig.Container.BeginLifetimeScope())
            {
                var lobby = scope.Resolve<LobbyForm>();
                var main = scope.Resolve<MainForm>();
                var chatRoom = AutofacConfig.Container.Resolve<ChatRoomForm>();
                var changePwd = scope.Resolve<ChangePasswordForm>();

                while (localData.FormViewType != FormViewType.Leave)
                {
                    switch (localData.FormViewType)
                    {
                        case FormViewType.Main:
                            var result =  main.ShowDialog();

                            if(result == DialogResult.Cancel)
                            {
                                localData.FormViewType = FormViewType.Leave;
                            }
                            break;
                        case FormViewType.Lobby:
                            if(lobby.ShowDialog() == DialogResult.Cancel)
                            {
                                localData.FormViewType = FormViewType.Main;
                                changePwd.Close();
                                localData.DisConnect();
                            }
                            break;
                        case FormViewType.ChatRoom:
                            if(chatRoom.ShowDialog() == DialogResult.Cancel)
                            {
                                localData.FormViewType = FormViewType.Lobby;

                                hubClient.SendAction(new ChatMessageAction()
                                {
                                    Account = localData.Account.f_account,
                                    Content = "離開房間",
                                    NickName = localData.Account.f_nickName,
                                    RoomID = (int)localData.RoomID,
                                    IsRecord = false
                                });

                                //正常離開房間
                                var userRoomSvc = AutofacConfig.Container.Resolve<IUserRoomService>();
                                userRoomSvc.LeaveRoom(localData.Account.f_account);

                                //確定離開房間才清值
                                localData.LeaveRoom();

                                chatRoom.Hide();
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
