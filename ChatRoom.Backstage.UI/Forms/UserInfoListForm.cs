using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChatRoom.Backstage.UI.Forms
{
    public partial class UserInfoListForm : Form
    {
        private Account[] accounts;

        private Account account;

        private IAccountService svc;

        private delegate void DelOnRefreshList();

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
            updateAccount.f_isLocked = false;
            updateAccount.f_errorTimes = 0;
            var activeResult = this.svc.Update(updateAccount);
            if (activeResult.result != null)
            {
                //顯示訊息
                switch (activeResult.result.ResultCode)
                {
                    case ResultCode.DATA_NEED_REFRESH:
                        MessageBox.Show("更新失敗 資料已過期");
                        break;
                    case ResultCode.SUCCESS:
                        MessageBox.Show("更新成功");
                        break;
                    default:
                        break;
                }
                
                // 更新單筆資料
                this.account = activeResult.result.Account;
                this.accounts[this.dvgUserList.CurrentCell.RowIndex] = activeResult.result.Account;
                this.UpdateInfo();
            }
            else
            {
                MessageBox.Show("帳號不存在");
            }
        }

        private void MuteAccount(bool mute)
        {
            var updateAccount = this.account;
            updateAccount.f_isMuted = mute;
            var activeResult = this.svc.Update(updateAccount);
            if (activeResult.result.ResultCode == ResultCode.SUCCESS)
            {
                MessageBox.Show("更新成功");
                this.account = activeResult.result.Account;
                this.accounts[this.dvgUserList.CurrentCell.RowIndex] = activeResult.result.Account;
              

                this.GetList();
            }
            else if (activeResult.result.ResultCode == ResultCode.DATA_NEED_REFRESH)
            {
                MessageBox.Show("更新失敗 資料過期");
                this.account = activeResult.result.Account;
                this.accounts[this.dvgUserList.CurrentCell.RowIndex] = activeResult.result.Account;
                this.UpdateInfo();
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
            this.btnUnlock.Enabled = Convert.ToBoolean(account.f_isLocked);
            this.btnMute.Enabled = !Convert.ToBoolean(account.f_isMuted);
            this.btnUnMute.Enabled = Convert.ToBoolean(account.f_isMuted);
        }


        public void OnRefreshList()
        {
            if (this.InvokeRequired)
            {
                DelOnRefreshList del = new DelOnRefreshList(OnRefreshList);
                this.Invoke(del);
            }
            else
            {
                this.GetList();
            }
        }
    }
}
