using ChatRoom.Domain.Model;
using System;

namespace ChatRoom.Client.UI.Model
{
    public static class LoginUserData
    {
        private static Account account;

        private static Room room;

        //外面就不用NEW了
        public static Account Account
        {
            set { account = value; }
            get
            {
                if (account == null)
                {
                    account = new Account();
                }
                return account;
            }
        }

        //自動屬性
        public static Room Room {
            set { room = value; }
            get
            {
                if (room == null)
                {
                    room = new Room();
                }
                return room;
            }
        }

        public static void DisConnect()
        {
            account = null;
            room = null;
        }

        public static void LeaveRoom()
        {
            room = null;
        }



    }
}
