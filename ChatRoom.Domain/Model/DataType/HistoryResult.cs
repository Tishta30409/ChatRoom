using ChatRoom.Domain.Repository;
using System.Collections.Generic;

namespace ChatRoom.Domain.Model.DataObj
{
    public class HistoryResult
    { 
        //各類型資料
        public ResultCode ResultCode { get; set; }

        public IEnumerable<History> Historys  { get; set; }

    }
}
