using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;
using System.Text.RegularExpressions;

namespace ChatRoom.Client.Model.Process
{
    public class RegisterMainProcess : IMainProcess
    {
        private IAccountService accountSvc;

        private IConsoleWrapper console;

        public RegisterMainProcess(IAccountService accountSvc, IConsoleWrapper console)
        {
            this.accountSvc = accountSvc;
            this.console = console;
        }

        public ProcessViewType Execute()
        {
            try
            {
                this.console.Clear();
                this.console.Write("註冊畫面:\n");


                string pattern = @"^[a-zA-Z0-9]*$";

                string account = string.Empty;

                while (
                    account == string.Empty ||
                    account.Length > 20 ||
                    !Regex.IsMatch(account, pattern)
                )
                {
                    this.console.Write("請輸入帳號:\n");
                    account = this.console.ReadLine();
                }

                string passwordFirst = string.Empty;

                string passwordSecond = string.Empty;

                while (
                    passwordFirst != passwordSecond ||
                    passwordFirst == string.Empty ||
                    passwordFirst.Length > 20 ||
                    !Regex.IsMatch(passwordFirst, pattern)
                )
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    this.console.Write("請輸入密碼:\n");
                    passwordFirst = string.Empty;
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
                                passwordFirst += ck.KeyChar.ToString();
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

                    this.console.Write("請再次輸入密碼:\n");
                    passwordSecond = string.Empty;
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
                                passwordSecond += ck.KeyChar.ToString();
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

                    this.console.WriteLine($"passwordFirst:{passwordFirst}");
                    this.console.WriteLine($"passwordFirst:{passwordFirst.Length}");
                    this.console.WriteLine($"passwordSecond:{passwordSecond}");
                    this.console.WriteLine($"passwordSecond:{passwordSecond.Length}");

                }

                string nickName = string.Empty;

                while (
                    nickName == string.Empty ||
                    nickName.Length > 10
                )
                {
                    this.console.Write("請輸入暱稱:\n");
                    nickName = this.console.ReadLine();
                }


                var result = this.accountSvc.Register(new AccountDto()
                {
                    Account = account,
                    Password = passwordFirst,
                    NickName = nickName
                });

                if(result.result == null)
                {
                    this.console.Write("註冊失敗:\n");
                }
                else
                {
                    this.console.Write("註冊成功:\n");
                }

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
