using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model
{
    public interface IConsoleWrapper
    {
        /// <summary>
        /// console clear
        /// </summary>
        void Clear();

        /// <summary>
        /// console read
        /// </summary>
        /// <returns></returns>
        int Read();

        /// <summary>
        /// console readLine
        /// </summary>
        /// <returns></returns>
        string ReadLine();

        /// <summary>
        /// console write
        /// </summary>
        /// <param name="str"></param>
        void Write(string str);

        /// <summary>
        /// console writeLine
        /// </summary>
        /// <param name="str"></param>
        void WriteLine(string str);
    }
}
