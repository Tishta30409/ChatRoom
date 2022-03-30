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

        private static int? roomID;

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
        public static int? RoomID
        {
            set { roomID = value; }
            get
            {
                return roomID;
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
            roomID = null;
        }

        public static void LeaveRoom()
        {
            roomID = null;
        }



    }
}
