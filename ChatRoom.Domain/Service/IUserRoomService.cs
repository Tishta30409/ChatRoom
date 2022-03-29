using ChatRoom.Domain.Model.DataType.Tsql;
using System;

namespace ChatRoom.Domain.Service
{
    public interface IUserRoomService
    {

        (Exception exception, UserRoom userRoom) JoinRoom(UserRoom userRoom);


        (Exception exception, UserRoom userRoom) LeaveRoom(string account);

 
    }
}
