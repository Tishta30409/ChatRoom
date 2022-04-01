using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.Model
{
    public class AccountDeleteBackStageProcess : IBackStageProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public AccountDeleteBackStageProcess(IAccountService accountSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
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
                this.console.WriteLine("刪除會員資料:\n");

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
                    var deleteResult = this.accountSvc.Delete(result.account.f_id);

                    this.console.WriteLine($"刪除結果::\n{JsonConvert.SerializeObject(deleteResult.account)}");
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
