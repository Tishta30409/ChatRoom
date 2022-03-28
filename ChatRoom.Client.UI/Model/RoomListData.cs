using ChatRoom.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace ChatRoom.Client.UI.Model
{
    public class RoomListData
    {
        public static List<Room> Rooms;

        /// <summary>
        /// 取得房間名稱
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public static string GetRoomName(int roomID)
        {
            return Rooms.Where((element, index)=> element.f_id == roomID).FirstOrDefault().f_roomName;
        }
    }
}
