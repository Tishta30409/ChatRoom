using ChatRoom.Domain.Model.DataObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model
{

    public class KeyboardReader : IKeyboardReader
    { 
        /// <summary>
        /// 取得輸入字串
        /// </summary>
        /// <param name="reg">正則格式</param>
        /// <param name="isEncode">是否顯示</param>
        /// /// <param name="length">字串長度</param>
        /// <returns></returns>
        public string GetInputString(string reg = "", bool isEncode = false,  int length = UserConstants.DefaultLength)
        {
            string output = string.Empty;

            while (true)
            {
                //儲存使用者輸入的按鍵，並且在輸入的位置不顯示字元
                ConsoleKeyInfo ck = Console.ReadKey(true);

                //判斷使用者是否按下的Enter鍵
                if (ck.Key != ConsoleKey.Enter)
                {
                    // 字元正則檢查
                    if (ck.Key != ConsoleKey.Backspace)
                    {
                        if (Regex.IsMatch(ck.KeyChar.ToString(), reg) && output.Length < length)
                        {
                            //將使用者輸入的字元存入字串中
                            output += ck.KeyChar.ToString();
                            //密碼類型 只顯示 *
                            if (isEncode)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write(ck.KeyChar.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(output))
                        {
                            output = output.Substring(0, output.Length - 1);

                            //判斷是否為中文
                            if (output[output.Length - 1] > 127)
                            {
                                Console.Write("\b \b");
                                Console.Write("\b \b");
                            }
                            else
                            {
                                //刪除錯誤的字元
                                Console.Write("\b \b");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }

            return output;
        }
    }
}
