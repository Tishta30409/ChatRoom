using Autofac;
using ChatRoom.Backstage.UI.Forms;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.Signalr;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Service;
using Microsoft.AspNet.SignalR.Client;
using NLog;
using System;
using System.Windows.Forms;

namespace ChatRoom.Backstage.Forms.UI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// hub client
        /// </summary>
        private IHubClient hubClient;

        private IHistoryService historySvc;

        private LocalData localData;

        private ILogger logger = LogManager.GetLogger("ChatRoomUI");

        private delegate void DelShowMessage(ChatMessageAction action);

        private delegate void DelShowJoinRoom();

        /// <summary>
        /// 背景計時器
        /// </summary>
        private Timer timer;

        public MainForm()
        {
            InitializeComponent();

            this.hubClient = AutofacConfig.Container.Resolve<IHubClient>();
            this.historySvc = AutofacConfig.Container.Resolve<IHistoryService>();
            this.localData = AutofacConfig.Container.Resolve<LocalData>();



            this.timer = new Timer();
            this.timer.Interval = 500;
            this.timer.Tick += (object sender, EventArgs e) =>
            {
                this.ChangeStatus();
            };

            this.timer.Start();
            this.hubClient.StartAsync();
        }

        private void SetJoinRoom(bool enable)
        {
            this.btnRoomUser.Enabled = !enable;

            this.textRoomName.Text = this.localData.RoomName;

        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                switch (btn.Name)
                {
                    case "btnRoomUser":
                        var roomUsers = AutofacConfig.Container.BeginLifetimeScope().Resolve<RoomUsersForm>();
                        roomUsers.ShowDialog();
                        break;
                    case "btnUserList":
                        var userList = AutofacConfig.Container.BeginLifetimeScope().Resolve<UserInfoListForm>();
                        userList.ShowDialog();
                        break;
                    case "btnRoomList":
                        var roomList = AutofacConfig.Container.BeginLifetimeScope().Resolve<RoomListForm>();
                        roomList.ShowDialog();
                        break;
                    case "btnSend":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ChangeStatus()
        {

            if (this.hubClient.State == ConnectionState.Connected)
            {
                this.textConnectState.Text = "連線中";
                this.timer.Stop();
            }
            else
            {
                this.textConnectState.Text = "等待連線中..";
            }
        }

        public void OnReceiveMessage(ChatMessageAction action)
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

        public void ShowJoinRoom()
        {
            if (this.InvokeRequired)
            {
                DelShowJoinRoom del = new DelShowJoinRoom(ShowJoinRoom);
                this.Invoke(del);
            }
            else
            {
                this.textMessage.Text = "";
                var result = this.historySvc.QueryList(this.localData.RoomID);
                if (result.historys != null)
                {
                    foreach (History history in result.historys)
                    {
                        this.textMessage.Text += $"{history.f_nickName}({history.f_createDateTime}): {history.f_content}";
                    }
                }

                this.textRoomName.Text = this.localData.RoomName;
            }

        }

    }
}
