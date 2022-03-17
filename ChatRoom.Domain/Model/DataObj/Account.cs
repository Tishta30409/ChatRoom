using ChatRoom.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model
{
    public class Account
    {
        public int f_id { get; set; }

        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string f_account { get; set; }


        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string f_password { get; set; }

        /// <summary>
        /// 限制長度 10 可含中 英 數
        /// </summary>
        public string f_nickName { get; set; }

        public AccountState f_state { get; set; }

        public byte f_errorTimes { get; set; }
    }
}
