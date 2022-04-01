using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using Microsoft.AspNet.SignalR.Client;
using NLog;
using System;
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

        private LocalData localData;

        /// <summary>
        /// 背景計時器
        /// </summary>
        private Timer timer;

        public MainForm()
        {
            InitializeComponent();

            this.hubClient = AutofacConfig.Container.Resolve<IHubClient>();
            this.accountSvc = AutofacConfig.Container.Resolve<IAccountService>();

            this.localData = AutofacConfig.Container.Resolve<LocalData>();

            this.timer = new Timer();
            this.timer.Interval = 500;
            this.timer.Tick += (object sender, EventArgs e) =>
            {
                this.ChangeStatus();
            };
        }

        public void Main_Shown(object sender, EventArgs e)
        {
            this.msgLogin.Visible = false;
            this.btnLogin.Enabled = true;
            this.btnRegister.Enabled = true;
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
                    /** 建立連線 */
                    if (hubClient != null)
                    {
                        this.btnLogin.Enabled = false;
                        this.btnRegister.Enabled = false;

                        this.localData.Account = result.result.Account;

                        this.hubClient.StartAsync();
                        this.timer.Start();
                    }
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

        private void ChangeStatus()
        {
            this.msgLogin.Visible = true;

            if (this.hubClient.State == ConnectionState.Connected)
            {
                this.localData.FormViewType = FormViewType.Lobby;
                this.DialogResult = DialogResult.OK;
                this.Close();
                this.msgLogin.Text = "連線成功";
                this.timer.Stop();
            }
            else
            {
                this.msgLogin.Text = "等待連線中..";
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
