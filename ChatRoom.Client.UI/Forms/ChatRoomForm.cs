using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Service;
using NLog;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatRoom.Client.UI.Forms
{
    public partial class ChatRoomForm : Form
    {
        private IHubClient hubClient;

        private IUserRoomService userRoomSvc;

        private IHistoryService historySvc;

        private ILogger logger = LogManager.GetLogger("ChatRoomUI");

        private delegate void DelShowMessage(ChatMessageAction action);

        private delegate void DelLeaveRoom();

        private delegate void DelUpdateAccount();

        private delegate void DelOnDisconnect();

        private StringBuilder sb;

        private LocalData localData;

        public ChatRoomForm()
        {
            InitializeComponent();

            this.hubClient = AutofacConfig.Container.Resolve<IHubClient>();
            this.userRoomSvc = AutofacConfig.Container.Resolve<IUserRoomService>();
            this.historySvc = AutofacConfig.Container.Resolve<IHistoryService>();

            this.localData = AutofacConfig.Container.Resolve<LocalData>();

            this.sb = new StringBuilder();
        }

        private void ChatRoom_Shown(object sender, EventArgs e)
        {
            this.labNickName.Text = $"暱稱: {this.localData.Account.f_nickName}";
            this.labRoomName.Text = $"房間名稱: {this.localData.Rooms.FirstOrDefault(room => room.f_id == this.localData.RoomID).f_roomName}";
            this.textMessage.Text = "";

            if (this.localData.Account.f_isMuted == 1)
            {
                this.btnSend.Enabled = false;
            }

            var result = this.historySvc.QueryList(this.localData.RoomID);

            if(result.historys != null)
            {
                foreach (History history in result.historys)
                {
                    this.sb.AppendLine($"{history.f_nickName}({history.f_createDateTime}): {history.f_content}");
                }

                this.textMessage.Text = this.sb.ToString();

                this.textMessage.SelectionStart = textMessage.Text.Length;
                this.textMessage.ScrollToCaret();
                this.textMessage.Refresh();
            }
            
            this.hubClient.SendAction(new ChatMessageAction()
            {
                Account = this.localData.Account.f_account,
                Content = "加入房間!",
                NickName = this.localData.Account.f_nickName,
                RoomID = (int)this.localData.RoomID,
                IsRecord = false
            }) ;
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                switch (btn.Name)
                {
                    case "btnSend":
                        this.SendMessage();
                        break;
                    case "btnUserList":
                        this.OpenRoomList();
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


        private void SendMessage()
        {
            this.hubClient.SendAction(new ChatMessageAction()
            {
                Account = this.localData.Account.f_account,
                Content = this.textUserEnter.Text,
                NickName = this.localData.Account.f_nickName,
                RoomID = (int)this.localData.RoomID,
                IsRecord = true
            });

            this.textUserEnter.Text = "";
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
                this.sb.AppendLine($"{action.NickName}({action.CreateDateTime}) :: {action.Content}");
                this.textMessage.Text = this.sb.ToString();

                this.textMessage.SelectionStart = textMessage.Text.Length;
                this.textMessage.ScrollToCaret();
                this.textMessage.Refresh();
            }

        }

        public void UpdateAccount()
        {
            //執行緒問題
            if (this.InvokeRequired)
            {
                DelUpdateAccount del = new DelUpdateAccount(UpdateAccount);
                this.Invoke(del);
            }
            else
            {
                this.btnSend.Enabled = !Convert.ToBoolean(this.localData.Account.f_isMuted);

            }
        }

        public void OnLeaveRoom()
        {
            //執行緒問題
            if (this.InvokeRequired)
            {
                DelLeaveRoom del = new DelLeaveRoom(OnLeaveRoom);
                this.Invoke(del);
            }
            else
            {
                this.sb.Clear();
                this.Hide();
                this.DialogResult = DialogResult.Cancel;
                
            }
        }

        private void OpenRoomList()
        {
            var userlist =  AutofacConfig.Container.BeginLifetimeScope().Resolve<UserListForm>();
            userlist.ShowDialog();
        }

        private void textUserEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && this.textUserEnter.Text != "")
            {
                this.SendMessage();
            }
        }

        private void ChatRoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //關閉視窗時取消
            this.DialogResult = DialogResult.Cancel;
            this.Hide(); //隱藏式窗,下次再show出
        }

        public void OnDisconnect()
        {
            //執行緒問題
            if (this.InvokeRequired)
            {
                DelOnDisconnect del = new DelOnDisconnect(OnDisconnect);
                this.Invoke(del);
            }
            else
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
                var userlist = AutofacConfig.Container.BeginLifetimeScope().Resolve<UserListForm>();
                userlist.Close();
                userlist.DialogResult = DialogResult.OK;
            }
        }
    }
}
