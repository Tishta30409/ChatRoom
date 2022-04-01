using ChatRoom.Domain.Model;
using System;
using System.Collections.Generic;

namespace ChatRoom.Client.UI.Model
{
    //目前畫面
    public enum FormViewType
    {
        Main = 0,
        Lobby = 1,
        ChatRoom = 2,
        Leave = 3,
    }

    public class LocalData
    {
        private FormViewType formViewType = FormViewType.Main;

        private Account account;

        private int? roomID;

        private List<Room> rooms;


        //外面就不用NEW了
        public  Account Account
        {
            set { account = value; }
            get
            {
                if (this.account == null)
                {
                    this.account = new Account();
                }
                return this.account;
            }
        }

        //自動屬性
        public int? RoomID
        {
            set { roomID = value; }
            get
            {
                return roomID;
            }
        }

        public List<Room> Rooms
        {
            set { rooms = value; }
            get { return rooms; }
        }

        public FormViewType FormViewType
        {
            get { return formViewType; }
            set { formViewType = value; }
        }

        public void DisConnect()
        {
            account = null;
            roomID = null;
        }

        public void LeaveRoom()
        {
            roomID = null;
        }



    }
}
