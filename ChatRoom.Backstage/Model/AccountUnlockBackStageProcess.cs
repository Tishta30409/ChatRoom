using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.Model
{
    public class AccountUnlockBackStageProcess : IBackStageProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public AccountUnlockBackStageProcess(IAccountService accountSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
        {
            this.accountSvc = accountSvc;
            this.console = console;
            this.keyboardReader = keyboardReader;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("鎖定解鎖會員資料:\n");

                string account = string.Empty;
                while (account == string.Empty)
                {
                    this.console.WriteLine("請輸入會員帳號");
                    account = this.keyboardReader.GetInputString(@"^[a-zA-Z0-9]*$", false, UserConstants.AccountLength);
                }

                var result = this.accountSvc.Query(account);
                if(result.account == null)
                {
                    this.console.WriteLine("帳號不存在");
                }
                else
                {
                    var updateResult = this.accountSvc.Update(new Account()
                    {
                        f_account = account,
                        f_password = result.account.f_password,
                        f_nickName = result.account.f_nickName,
                        f_errorTimes = 0,
                        f_isLocked = 0,
                        f_isMuted = result.account.f_isMuted,
                        f_loginIdentifier = result.account.f_loginIdentifier,
                    });

                    this.console.WriteLine($"更新結果::\n{JsonConvert.SerializeObject(updateResult.account)}");
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
