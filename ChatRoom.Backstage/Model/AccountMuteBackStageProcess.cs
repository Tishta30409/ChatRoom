using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.Model
{
    public class AccountMuteBackStageProcess : IBackStageProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public AccountMuteBackStageProcess(IAccountService sujectSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
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
                this.console.WriteLine("禁言解禁會員:\n");

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
                    var updateResult = this.accountSvc.Update(new Account()
                    {
                        f_account = account,
                        f_password = result.account.f_password,
                        f_nickName = result.account.f_nickName,
                        f_errorTimes = result.account.f_errorTimes,
                        f_guid = result.account.f_guid,
                        f_isLocked = result.account.f_isLocked,
                        f_isMuted = !result.account.f_isMuted,
                        f_roomID = result.account.f_roomID,
                    });

                    this.console.WriteLine($"執行結果::\n{JsonConvert.SerializeObject(updateResult.account)}");
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
