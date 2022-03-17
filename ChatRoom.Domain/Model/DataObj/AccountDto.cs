using ChatRoom.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model.DataObj
{
    public class AccountDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string Account { get; set; }


        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 限制長度 10 可含中 英 數
        /// </summary>
        public string NickName { get; set; }

        public AccountState State { get; set; }

        public byte ErrorTimes { get; set; }

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
