using ChatRoom.Domain.Repository;
using System.Collections.Generic;

namespace ChatRoom.Domain.Model.DataObj
{
    public class RoomResult
    { 
        //各類型資料
        public ResultCode ResultCode { get; set; }

        public Room Room { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

    }
}
