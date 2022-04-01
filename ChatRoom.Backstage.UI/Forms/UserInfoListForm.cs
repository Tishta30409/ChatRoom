using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom.Backstage.UI.Forms
{
    public partial class UserInfoListForm : Form
    {
        private Account[] accounts;

        private Account account;

        private IAccountService svc;

        public UserInfoListForm()
        {
            InitializeComponent();

            this.svc = AutofacConfig.Container.Resolve<IAccountService>();
        }

        private void UserInfoList_Shown(object sender, EventArgs e)
        {
            this.GetList();
        }

        private void GetList()
        {
            var getResult = this.svc.QueryList();

            if (getResult.exception != null)
            {
                throw getResult.exception;
            }

            this.accounts = getResult.accounts.ToArray();
            var bind = new BindingList<Account>(this.accounts);
            var source = new BindingSource(bind, null);
            this.dvgUserList.DataSource = source;
        }


        private void OnButtonClick(object sender, EventArgs e)
        {
            if(account == null)
            {
                MessageBox.Show("請先選擇帳號");
                return;
            }

            try
            {
                var btn = (Button)sender;

                switch (btn.Name)
                {
                    case "btnUnlock":
                        this.UnlockAccount();
                        break;
                    case "btnMute":
                        this.MuteAccount(true);
                        break;
                    case "btnUnMute":
                        this.MuteAccount(false);
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

        private void UnlockAccount()
        {
            var updateAccount = this.account;
            updateAccount.f_isLocked = Convert.ToByte(0);
            updateAccount.f_errorTimes = 0;
            var activeResult = this.svc.Update(updateAccount);
            if (activeResult.account != null)
            {
                MessageBox.Show("更新成功");
                this.account = activeResult.account;
                this.accounts[this.dvgUserList.CurrentCell.RowIndex] = activeResult.account;
                this.UpdateInfo();

                this.GetList();
            }
            else
            {
                MessageBox.Show("帳號不存在");
            }
        }

        private void MuteAccount(bool mute)
        {
            var updateAccount = this.account;
            updateAccount.f_isMuted = Convert.ToByte(mute);
            var activeResult = this.svc.Update(updateAccount);
            if (activeResult.account != null)
            {
                MessageBox.Show("更新成功");
                this.account = activeResult.account;
                this.accounts[this.dvgUserList.CurrentCell.RowIndex] = activeResult.account;
                this.UpdateInfo();

                this.GetList();
            }
            else
            {
                MessageBox.Show("帳號不存在");
            }
        }

        private void dvgUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < this.accounts.Length && e.RowIndex < this.accounts.Length)
            {
               this.account = this.accounts[e.RowIndex];
                this.UpdateInfo();
            }
        }

        private void UpdateInfo()
        {
            labState.Text = $"使用者:{account.f_account}, 鎖定: {Convert.ToBoolean(account.f_isLocked)} , 禁言: {Convert.ToBoolean(account.f_isMuted)}";

            this.btnUnlock.Enabled = Convert.ToBoolean(account.f_isLocked);
            this.btnMute.Enabled = !Convert.ToBoolean(account.f_isMuted);
            this.btnUnMute.Enabled = Convert.ToBoolean(account.f_isMuted);
        }
    }
}
