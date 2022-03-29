using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Service;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom.Client.UI.Forms
{
    public partial class ChatRoomForm : Form
    {
        private IHubClient hubClient;

        private IUserRoomService userRoomSvc;

        private ILogger logger = LogManager.GetLogger("ChatRoomUI");

        private delegate void DelShowMessage(ChatMessageAction action);

        public ChatRoomForm()
        {
            InitializeComponent();

            this.hubClient = AutofacConfig.Container.Resolve<IHubClient>();
            this.userRoomSvc = AutofacConfig.Container.Resolve<IUserRoomService>();
        }

        private void ChatRoom_Shown(object sender, EventArgs e)
        {
            this.labNickName.Text = $"暱稱: {LocalUserData.Account.f_nickName}";
            this.labRoomName.Text = $"房間名稱: {LocalUserData.Rooms.FirstOrDefault(room => room.f_id == LocalUserData.Room?.f_id).f_roomName}";

            if (LocalUserData.Account.f_isMuted == 1)
            {
                this.btnSend.Enabled = false;
            }

            this.hubClient.SendAction(new ChatMessageAction()
            {
                Content = "加入房間!",
                RoomID = LocalUserData.Room.f_id,
                NickName = LocalUserData.Account.f_nickName,
            });
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                switch (btn.Name)
                {
                    case "btnSend":
                        this.sendMessage();
                        break;
                    case "btnUserList":
                        this.openRoomList();
                        break;
                    default:
                        MessageBox.Show("無效的選項");
                        break;
                }

            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} ButtonOnClick Exception");
                MessageBox.Show(ex.Message);
            }
        }


        private void sendMessage()
        {
            this.hubClient.SendAction(new ChatMessageAction()
            {
                Content = this.textUserEnter.Text,
                RoomID = LocalUserData.Room.f_id,
                NickName = LocalUserData.Account.f_nickName,
            });

            this.textUserEnter.Text = "";
        }
        
        //
        public void OnMutedStateChanged()
        {

        }

        public void OnReceiveMessage(ChatMessageAction action )
        {
            //執行緒問題
            if (this.InvokeRequired)
            {
                DelShowMessage del = new DelShowMessage(OnReceiveMessage);
                this.Invoke(del, action);
            }
            else
            {
                this.textMessage.Text += $"{action.NickName}({action.CreateDateTime}) :: {action.Content}\r\n";
            }

        }

        public void OnDisconncet()
        {

        }

        private void openRoomList()
        {
            var userlist =  AutofacConfig.Container.BeginLifetimeScope().Resolve<UserListForm>();
            userlist.ShowDialog();
        }

        private void btnUserList_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textUserEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && this.textUserEnter.Text != "")
            {
                this.sendMessage();
            }
        }
    }
}
