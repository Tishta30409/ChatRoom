using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;
using ChatRoom.Domain.Model.DataObj;
using Newtonsoft.Json;

namespace ChatRoom.Backstage.Model
{
    public class AccountUpdateBackStageProcess : IBackStageProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public AccountUpdateBackStageProcess(IAccountService sujectSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
        {
            this.accountSvc = sujectSvc;
            this.console = console;
            this.keyboardReader = keyboardReader;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("更新會員資料:\n");

                string account = string.Empty;
                while (account == string.Empty)
                {
                    this.console.WriteLine("請輸入會員帳號");
                    account = this.keyboardReader.GetInputString(@"^[a-zA-Z0-9]*$", false, UserConstants.AccountLength);
                }

                var result = this.accountSvc.Query(account);
                if (result.account == null)
                {
                    this.console.WriteLine("帳號不存在");
                }
                else
                {
                    string password = string.Empty;
                    while (password == string.Empty)
                    {
                        this.console.WriteLine("請輸入要修改的密碼");
                        password = this.keyboardReader.GetInputString(@"^[a-zA-Z0-9]*$", false, UserConstants.PasswordLength);
                    }

                    string nickName = string.Empty;
                    while (nickName == string.Empty)
                    {
                        this.console.WriteLine("請輸入要修改的暱稱");
                        nickName = this.keyboardReader.GetInputString("", false, UserConstants.NickNameLength);
                    }

                    var updateResult = this.accountSvc.Update(new Account()
                    {
                        f_account = account,
                        f_password = password,
                        f_nickName = nickName,
                        f_errorTimes = result.account.f_errorTimes,
                        f_loginIdentifier = result.account.f_loginIdentifier,
                        f_isLocked = result.account.f_isLocked,
                        f_isMuted = result.account.f_isMuted,
                    });

                    this.console.WriteLine($"更新結果::{JsonConvert.SerializeObject(updateResult.account)}");
                }

                this.console.Read();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
