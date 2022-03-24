using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace ChatRoom.Client.Model.Process
{
    public class LoginMainProcess : IMainProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        private IHubClient hubClient;

        public LoginMainProcess(IAccountService accountSvc, IConsoleWrapper console, IKeyboardReader keyboardReader, IHubClient hubClient )
        {
            this.accountSvc = accountSvc;
            this.console = console;
            this.keyboardReader = keyboardReader;
            this.hubClient = hubClient;
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
                    account = this.keyboardReader.GetInputString(pattern, false, UserConstants.AccountLength);
                }

                string password = string.Empty;
                this.console.Write("請輸入密碼:\r\n");
                while (password == string.Empty)
                {
                    password = this.keyboardReader.GetInputString(pattern, true, UserConstants.PasswordLength);
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
                    this.console.Write((result.result.resultCode).ToDisplay());
                       
                    if(result.result.resultCode == ResultCode.SUCCESS)
                    {
                        // 存帳號資料
                        LoginUserData.account = result.result.account;
                        this.console.WriteLine("登入成功 嘗試建立連線");

                        //連線
                        if (hubClient != null)
                        {
                            hubClient.StartAsync();
                            while (!SpinWait.SpinUntil(() => false, 1000) && hubClient.State != ConnectionState.Connected)
                            {
                                console.Clear();
                                console.WriteLine($"HubClient State:{hubClient.State}...");
                            }
                        }
                        
                        return ProcessViewType.Lobby;
                    }
                    else
                    {
                        this.console.WriteLine("登入失敗 返回主畫面");
                        this.console.WriteLine($"{result.result.resultCode }");
                        this.console.Read();
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
