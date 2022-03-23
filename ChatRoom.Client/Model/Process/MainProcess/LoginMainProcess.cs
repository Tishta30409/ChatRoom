using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using System;
using System.Text.RegularExpressions;

namespace ChatRoom.Client.Model.Process
{
    public class LoginMainProcess : IMainProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public LoginMainProcess(IAccountService accountSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
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
                this.console.WriteLine("登入介面:");

                string pattern = @"^[a-zA-Z0-9]*$";

                string account = string.Empty;
                while (account == string.Empty )
                {
                    this.console.Write("請輸入登入帳號:\r\n");
                    account = this.keyboardReader.GetInputString(pattern, false, 40);
                }

                string password = string.Empty;
                this.console.Write("請輸入密碼:\r\n");
                while (password == string.Empty)
                {
                    password = this.keyboardReader.GetInputString(pattern, true, 40); ;
                }

                var result = this.accountSvc.Login(new LoginDto()
                {
                    Account = account,
                    Password = password
                });

                // 檢查是否登入成功
                if (result.result == null)
                {
                    this.console.Write(ResultCode.ACCOUNT_NOTEXIST.ToDisplay());
                    this.console.WriteLine("登入失敗 返回主畫面");
                    return ProcessViewType.Main;
                }
                else
                {
                    this.console.Write(((ResultCode)result.result.resultCode).ToDisplay());
                       
                    if(result.result.resultCode == ResultCode.SUCCESS)
                    {
                        // 存帳號資料
                        LoginUserData.account = result.result.account;
                        this.console.WriteLine("登入成功 進入大廳");
                        return ProcessViewType.Lobby;
                    }
                    else
                    {
                        this.console.WriteLine("登入失敗 返回主畫面");
                        return ProcessViewType.Main;
                    }
                }
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
