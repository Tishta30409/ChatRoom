using ChatRoom.Domain.Repository;
using System.Collections.Generic;

namespace ChatRoom.Domain.Model.DataObj
{
    public class AccountResult
    { 
        //各類型資料
        public ResultCode ResultCode { get; set; }

        public Account Account { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        //Login
        public int? RoomID { get; set; }
    }
}
