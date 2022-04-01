using Autofac;
using ChatRoom.Backstage.UI.Forms;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.Signalr;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Service;
using Microsoft.AspNet.SignalR.Client;
using NLog;
using System;
using System.Text;
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

        private StringBuilder sb;

        private IUserRoomService userRoomService;

        /// <summary>
        /// 背景計時器
        /// </summary>
        private System.Windows.Forms.Timer timer;

        public MainForm()
        {
            InitializeComponent();

            this.hubClient = AutofacConfig.Container.Resolve<IHubClient>();
            this.historySvc = AutofacConfig.Container.Resolve<IHistoryService>();
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
            this.userRoomService = AutofacConfig.Container.Resolve<IUserRoomService>();

            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 500;
            this.timer.Tick += (object sender, EventArgs e) =>
            {
                this.ChangeStatus();
            };

            this.timer.Start();
            this.hubClient.StartAsync();

            this.sb = new StringBuilder();

            this.CheckMainButtonState();
        }

        private void CheckMainButtonState()
        {
            if(this.localData.RoomID == null)
            {
                this.btnLeaveRoom.Enabled = false;
                this.btnSend.Enabled = false;
                this.btnRoomUser.Enabled = false;
                this.btnRoomList.Enabled = true;
                this.textUserInput.Enabled = false;
            }
            else
            {
                this.btnLeaveRoom.Enabled = true;
                this.btnSend.Enabled = true;
                this.btnRoomUser.Enabled=true; 
                this.btnRoomList.Enabled=false;
                this.textUserInput.Enabled = true;
            }

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
                        this.SendMessage();
                        break;
                    case "btnLeaveRoom":
                        this.LeaveRoom();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void LeaveRoom()
        {
            var joinResult = this.userRoomService.LeaveRoom(this.localData.Account);

            this.localData.RoomID = null;

            this.textMessage.Text = "";

            this.CheckMainButtonState();
        }

        private void SendMessage()
        {
            if(this.localData.RoomID == null)
            {
                MessageBox.Show("請先加入房間");
                return;
            }

            this.hubClient.SendAction(new ChatMessageAction()
            {
                Account = this.localData.Account,
                Content = this.textUserInput.Text,
                NickName = this.localData.Account,
                RoomID = (int)this.localData.RoomID,
                IsRecord = true
            });

            this.textUserInput.Text = "";
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
                this.sb.AppendLine($"{action.NickName}({action.CreateDateTime}) :: {action.Content}");
                this.textMessage.Text = this.sb.ToString();

                this.textMessage.SelectionStart = textMessage.Text.Length;
                this.textMessage.ScrollToCaret();
                this.textMessage.Refresh();
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
                this.sb.Clear();
                var result = this.historySvc.QueryList(this.localData.RoomID);
                if (result.historys != null)
                {
                    foreach (History history in result.historys)
                    {
                       sb.AppendLine($"{history.f_nickName}({history.f_createDateTime}): {history.f_content}");
                    }

                    this.textMessage.Text = this.sb.ToString();
                    this.textMessage.SelectionStart = textMessage.Text.Length;
                    this.textMessage.ScrollToCaret();
                    this.textMessage.Refresh();
                }

                //Task
                //Thread t = new Thread(CheckMainButtonState);
                //t.IsBackground = true;
                //t.Start();

                this.CheckMainButtonState();
            }

        }
    }
}
