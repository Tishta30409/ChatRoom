using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using System;

namespace ChatRoom.Client.Model.Process
{
    public class RegisterMainProcess : IMainProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public RegisterMainProcess(IAccountService accountSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
        {
            this.accountSvc = accountSvc;
            this.console = console;
            this.keyboardReader = keyboardReader;
        }

        public ProcessViewType Execute()
        {
            try
            {
                this.console.Clear();
                this.console.Write("註冊畫面:\n");

                string pattern = @"^[a-zA-Z0-9]*$";

                string account = string.Empty;
                while (account == string.Empty)
                {
                    this.console.Write("請輸入帳號:\n");
                    account = this.keyboardReader.GetInputString(pattern, false, UserConstants.AccountLength);
                }

                string passwordFirst = string.Empty;

                string passwordSecond = string.Empty;

                while (passwordFirst != passwordSecond || passwordFirst == string.Empty )
                {
                    this.console.Write("請輸入密碼:\n");
                    passwordFirst = this.keyboardReader.GetInputString(pattern, true, UserConstants.PasswordLength);

                    this.console.Write("請再次輸入密碼:\n");
                    passwordSecond = this.keyboardReader.GetInputString(pattern, true, UserConstants.PasswordLength);
                }

                string nickName = string.Empty;
                while (nickName == string.Empty)
                {
                    this.console.Write("請輸入暱稱:\n");
                    nickName = this.keyboardReader.GetInputString("", false, UserConstants.NickNameLength);
                }

                var result = this.accountSvc.Register(new AccountDto()
                {
                    Account = account,
                    Password = passwordFirst,
                    NickName = nickName
                });



                if(result.result == ResultCode.SUCCESS)
                {
                    this.console.Write("註冊成功\n");
                }
                else
                {
                    this.console.Write("註冊失敗\n");
                    this.console.WriteLine($"{result.result}");
                }

                this.console.Read();

                return ProcessViewType.Main;
            }
            catch (Exception ex)
            {
                this.console.Clear();
                this.console.WriteLine(ex.Message);
                this.console.Read();

                return ProcessViewType.Main;
            }
        }
    }
}
