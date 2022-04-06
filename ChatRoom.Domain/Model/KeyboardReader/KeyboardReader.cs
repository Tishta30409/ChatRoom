using ChatRoom.Domain.Model.DataType;
using System;
using System.Text.RegularExpressions;

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
                if (ck.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    if(ck.Key == ConsoleKey.Backspace)
                    {
                        if (!String.IsNullOrEmpty(output))
                        {

                            if (output.Length != 0)
                            {
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

                                output = output.Substring(0, output.Length - 1);
                            }
                        }
                    }
                    else
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
                }
            }

            return output;
        }
    }
}
