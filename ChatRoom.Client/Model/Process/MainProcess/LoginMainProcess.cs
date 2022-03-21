using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;
using System.Text.RegularExpressions;

namespace ChatRoom.Client.Model.Process
{
    public class LoginMainProcess : IMainProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        public LoginMainProcess(IAccountService accountSvc, IConsoleWrapper console)
        {
            this.accountSvc = accountSvc;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("請輸入帳號");

                var cmd = string.Empty;

                string pattern = @"^[a-zA-Z0-9]*$";

                string account = string.Empty;

                while (
                    account == string.Empty &&
                    account.Length > 20 &&
                    !Regex.IsMatch(account, pattern)
                )
                {
                    this.console.Write("請輸入登入帳號");
                    account = this.console.ReadLine();
                }

                this.console.Read();

                // 檢查是否登入成功

                return true;
            }
            catch (Exception ex)
            {
                this.console.Clear();
                this.console.WriteLine(ex.Message);
                this.console.Read();

                return false;
            }
        }
    }
}
