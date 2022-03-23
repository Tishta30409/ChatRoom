using ChatRoom.Domain.Model;
using System;

namespace ChatRoom.Client.Model
{
    public class LoginUserData
    {
        public static Account account;

        public static int GetRoomID()
        {
            return account.f_roomID;
        }

        public static Guid GetGUID()
        {
            return account.f_guid;
        }

        public static string GetAccount()
        {
            return account.f_account;
        }

        public static string GetNickName()
        {
            return account.f_nickName;
        }

        public static bool GetIsMuted()
        {
            return account.f_isMuted;
        }

        public static void LeaveRoom()
        {
             account.f_roomID = -1;
        }
    }


}
