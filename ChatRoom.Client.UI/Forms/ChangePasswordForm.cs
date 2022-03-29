using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Model.DataObj;
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

namespace ChatRoom.Client.UI.Forms
{
    public partial class ChangePasswordForm : Form
    {

        private IAccountService accountSvc;
        public ChangePasswordForm()
        {
            InitializeComponent();

            this.accountSvc = AutofacConfig.Container.Resolve<IAccountService>();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var result =  this.accountSvc.ChangePwd(new AccountDto()
            {
                Account = LocalUserData.Account.f_account,
                Password = this.textNewPwd.Text
            });

            if(result.account != null)
            {
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("更新失敗");
            }

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
    }
}
