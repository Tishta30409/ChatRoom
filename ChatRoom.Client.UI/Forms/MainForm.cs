using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Repository;
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

namespace ChatRoom.Client.UI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// hub client
        /// </summary>
        private IHubClient hubClient;

        private IAccountService accountSvc;

        private ILogger logger = LogManager.GetLogger("ChatRoomUI");

        public MainForm()
        {
            InitializeComponent();

            this.hubClient = AutofacConfig.Container.Resolve<IHubClient>();
            this.accountSvc = AutofacConfig.Container.Resolve<IAccountService>();
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                switch (btn.Name)
                {
                    case "btnLogin":
                        this.Login();
                        break;
                    case "btnRegister":
                        this.Register();
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

        private void Login()
        {
            try
            {
                if (string.IsNullOrEmpty(this.textAccount.Text))
                {
                    MessageBox.Show("請輸入帳號!");
                    return;
                }

                if (string.IsNullOrEmpty(this.textPassword.Text))
                {
                    MessageBox.Show("請輸入密碼!");
                    return;
                }

                var result = this.accountSvc.Login(new LoginDto()
                {
                    Account = this.textAccount.Text,
                    Password = this.textPassword.Text,
                });

                if (result.result.ResultCode == ResultCode.SUCCESS)
                {
                    LoginUserData.Account = result.result.Account;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登入結果:" + result.result.ResultCode.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("登入結果例外");
            }
           
        }

        private void Register()
        {
            if (string.IsNullOrEmpty(this.textAccount.Text))
            {
                MessageBox.Show("請輸入帳號!");
                return;
            }

            if (string.IsNullOrEmpty(this.textPassword.Text))
            {
                MessageBox.Show("請輸入密碼!");
                return;
            }

            var result = this.accountSvc.Register(new AccountDto()
            {
                Account = this.textAccount.Text,
                Password = this.textPassword.Text,
            });

            MessageBox.Show("註冊結果:" + result.result.ToString());
        }
    }
}
