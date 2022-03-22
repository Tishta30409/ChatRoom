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

        public LoginMainProcess(IAccountService accountSvc, IConsoleWrapper console)
        {
            this.accountSvc = accountSvc;
            this.console = console;
        }

        public ProcessViewType Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("登入介面:");

                string pattern = @"^[a-zA-Z0-9]*$";

                string account = string.Empty;


                this.console.Write("請輸入登入帳號:\r\n");
                while (
                    account == string.Empty ||
                    account.Length > 20 ||
                    !Regex.IsMatch(account, pattern)
                )
                {
                    account = this.console.ReadLine();
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                string password = string.Empty;

                this.console.Write("請輸入密碼:\r\n");
                while (
                    password == string.Empty ||
                    password.Length > 20 ||
                    !Regex.IsMatch(password, pattern)
                )
                {
                    password = string.Empty;
                    while (true)
                    {
                        //儲存使用者輸入的按鍵，並且在輸入的位置不顯示字元
                        ConsoleKeyInfo ck = Console.ReadKey(true);

                        //判斷使用者是否按下的Enter鍵
                        if (ck.Key != ConsoleKey.Enter)
                        {
                            if (ck.Key != ConsoleKey.Backspace)
                            {
                                //將使用者輸入的字元存入字串中
                                password += ck.KeyChar.ToString();
                                //將使用者輸入的字元替換為*
                                Console.Write("*");
                            }
                            else
                            {
                                //刪除錯誤的字元
                                Console.Write("\b \b");
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            break;
                        }
                    }
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
                    return ProcessViewType.Main;
                }
                else
                {
                    this.console.Write(((ResultCode)result.result.resultCode).ToDisplay());
                       
                    if(result.result.resultCode == ResultCode.SUCCESS)
                    {
                        // 存帳號資料
                        LoginUserData.account = result.result.account;
                        return ProcessViewType.Lobby;
                    }
                    else
                    {
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
