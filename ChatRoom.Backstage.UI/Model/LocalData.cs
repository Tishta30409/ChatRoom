using ChatRoom.Domain.Model;

namespace ChatRoom.Backstage.UI.Model
{
    public class LocalData
    {
        public string Account = "Admin";

        private int? roomID;

        private string roomName;

        public int? RoomID
        {
            set { this.roomID = value; }
            get
            {
                return this.roomID;
            }
        }

        public string RoomName
        {
            set { this.roomName = value; }
            get
            {
                return this.roomName;
            }
        }

    }
}
