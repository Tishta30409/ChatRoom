using ChatRoom.Domain.Model;

namespace ChatRoom.Client.Model
{
    public class LoginUserData
    {
        public static Account account;

        public static int GetRoomID()
        {
            return account.f_roomID;
    }
    }

   
}
