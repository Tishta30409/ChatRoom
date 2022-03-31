using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Service;
using NLog;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChatRoom.Client.UI.Forms
{
    public partial class LobbyForm : Form
    {
        private IRoomService roomSvc;

        private IAccountService accountSvc;

        private IUserRoomService userRoomSvc;

        private ILogger logger = LogManager.GetLogger("ChatRoomUI");

        private ChatRoomForm chatRoomFrom;

        private LocalData localData;

        private delegate void DelOnDisconnect();

        public LobbyForm()
        {
            InitializeComponent();

            this.roomSvc = AutofacConfig.Container.Resolve<IRoomService>();
            this.accountSvc = AutofacConfig.Container.Resolve<IAccountService>();
            this.userRoomSvc = AutofacConfig.Container.Resolve<IUserRoomService>();

            this.chatRoomFrom = AutofacConfig.Container.Resolve<ChatRoomForm>();

            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        private void Initialize()
        {
            try
            {
                //暱稱更新
                this.textNickName.Text = this.localData.Account.f_nickName;

                //房間列表
                var result = this.roomSvc.GetList();

                if (result.exception != null)
                {
                    throw result.exception;
                }

                this.localData.Rooms = result.rooms.ToList();

                var bind = new BindingList<Room>(this.localData.Rooms);
                var source = new BindingSource(bind, null);
                this.dataGridViewRooms.DataSource = source;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 畫面展開時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LobbyForm_Shown(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void DgvRoomList_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textNickName.Text))
                {
                    MessageBox.Show("請輸入暱稱");
                    return;
                }

                //if (this.textNickName.Text == LocalUserData.Account.f_account)
                //{
                //    MessageBox.Show("請先修改暱稱");
                //    return;
                //}

                if (e.RowIndex > -1 && e.RowIndex < this.localData.Rooms.Count())
                {
                    var result = this.userRoomSvc.JoinRoom(new UserRoom()
                    {
                        f_account = this.localData.Account.f_account,
                        f_roomID = this.localData.Rooms[e.RowIndex].f_id,
                        f_nickName = this.localData.Account.f_nickName

                    });

                    if (result.userRoom != null)
                    {
                        this.localData.RoomID = result.userRoom.f_roomID;
                        this.localData.FormViewType = FormViewType.ChatRoom;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                switch (btn.Name)
                {
                    case "btnChangeNickName":
                        this.ChangeNickName();
                        break;
                    case "btnChangePwd":
                        this.ChangePassword();
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

        private void ChangeNickName()
        {
            try
            {
                if (string.IsNullOrEmpty(this.textNickName.Text))
                {
                    MessageBox.Show("請輸入暱稱!");
                    return;
                }

                if (this.textNickName.Text == this.localData.Account.f_nickName)
                {
                    MessageBox.Show("暱稱沒有更動");
                    return;
                }

                var updateResult = this.accountSvc.Update(new Account()
                {
                    f_account = this.localData.Account.f_account,
                    f_password = this.localData.Account.f_password,
                    f_nickName = this.textNickName.Text,
                    f_errorTimes = this.localData.Account.f_errorTimes,
                    f_isLocked = this.localData.Account.f_isLocked,
                    f_isMuted = this.localData.Account.f_isMuted,
                    f_loginIdentifier = this.localData.Account.f_loginIdentifier,
                });

                //沒有回傳值 更新失敗
                if (updateResult.account == null)
                {
                    MessageBox.Show("更新失敗");
                }
                else
                {
                    this.localData.Account = updateResult.account;
                    MessageBox.Show("更新成功");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ChangePassword()
        {
            var pwdForm = AutofacConfig.Container.BeginLifetimeScope().Resolve<ChangePasswordForm>();
            pwdForm.ShowDialog();
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
                var pwdForm = AutofacConfig.Container.BeginLifetimeScope().Resolve<ChangePasswordForm>();
                pwdForm.Close();
                pwdForm.DialogResult = DialogResult.OK;
            }
        }
    }
}
