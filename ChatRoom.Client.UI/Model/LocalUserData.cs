using ChatRoom.Domain.Model;
using System;
using System.Collections.Generic;

namespace ChatRoom.Client.UI.Model
{
    public enum FormViewType
    {
        Main = 0,
        Lobby = 1,
        ChatRoom = 2,
        Leave = 3,
    }

    public static class LocalUserData
    {
        private static FormViewType formViewType = FormViewType.Main;

        private static Account account;

        private static Room room;

        private static List<Room> rooms;


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
        public static Room Room
        {
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

        public static List<Room> Rooms
        {
            set { rooms = value; }
            get { return rooms; }
        }

        public static FormViewType FormViewType
        {
            get { return formViewType; }
            set { formViewType = value; }
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
