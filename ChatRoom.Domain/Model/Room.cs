using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model
{
    public class Room
    {
        public int f_id { get; set; }

        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string f_roomName { get; set; }
    }
}
