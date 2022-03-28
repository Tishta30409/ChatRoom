using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Model;
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
    public partial class LobbyForm : Form
    {

        private IHubClient hubClient;

        private IRoomService roomSvc;

        private IAccountService accountSvc;

        private ILogger logger = LogManager.GetLogger("ChatRoomUI");

        private Room[] rooms;

        public LobbyForm()
        {
            InitializeComponent();

            this.hubClient = AutofacConfig.Container.Resolve<IHubClient>();
            this.roomSvc = AutofacConfig.Container.Resolve<IRoomService>();
            this.accountSvc = AutofacConfig.Container.Resolve<IAccountService>();

        }

        private void Initialize()
        {
            try
            {
                //暱稱更新
                this.textNickName.Text = LoginUserData.Account.f_nickName;

                //房間列表
                var result = this.roomSvc.GetList();

                if (result.exception != null)
                {
                    throw result.exception;
                }

                this.rooms = result.rooms.ToArray();

                var bind = new BindingList<Room>(this.rooms);
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
                    MessageBox.Show("請輸入暱稱!");
                    return;
                }



                


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnChangeNickName_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(this.textNickName.Text))
                {
                    MessageBox.Show("請輸入暱稱!");
                    return;
                }

                if(this.textNickName.Text == LoginUserData.Account.f_nickName)
                {
                    MessageBox.Show("暱稱沒有更動");
                    return;
                }

                var updateResult = this.accountSvc.Update(new Account()
                {
                    f_account = LoginUserData.Account.f_account,
                    f_password = LoginUserData.Account.f_password,
                    f_nickName = this.textNickName.Text,
                    f_errorTimes = LoginUserData.Account.f_errorTimes,
                    f_isLocked = LoginUserData.Account.f_isLocked,
                    f_isMuted = LoginUserData.Account.f_isMuted,
                    f_loginIdentifier = LoginUserData.Account.f_loginIdentifier,
                });

                //沒有回傳值 更新失敗
                if(updateResult.account == null)
                {
                    MessageBox.Show("更新失敗");
                }
                else
                {
                    MessageBox.Show("更新成功");
                }


            }
            catch (Exception)
            {

                throw;
            }
           


        }
    }
}
