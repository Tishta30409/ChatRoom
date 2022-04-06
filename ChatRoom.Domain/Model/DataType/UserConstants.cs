using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model.DataType
{
    //常數
    public static class UserConstants
    {
        //聊天室最大行數
        public const int ChatRoomMaxLine = 20;

        //最大字數
        public const int AccountLength = 20;
        public const int PasswordLength = 20;
        public const int NickNameLength = 10;
        public const int RoomNameLength = 10;
        public const int ContentLength = 20;
        public const int DefaultLength = 20;
    }
}
