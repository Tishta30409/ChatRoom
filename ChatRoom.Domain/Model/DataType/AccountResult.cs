using ChatRoom.Domain.Repository;
using System.Collections.Generic;

namespace ChatRoom.Domain.Model.DataType
{
    public class AccountResult
    { 
        //各類型資料
        public ResultCode ResultCode { get; set; }

        public Account Account { get; set; }
    }
}
