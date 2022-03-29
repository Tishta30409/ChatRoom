using ChatRoom.Domain.Model.DataType.Tsql;
using System;
using System.Collections.Generic;

namespace ChatRoom.Domain.Service
{
    public interface IUserRoomService
    {

        (Exception exception, UserRoom userRoom) JoinRoom(UserRoom userRoom);


        (Exception exception, UserRoom userRoom) LeaveRoom(string account);

        (Exception exception, IEnumerable<UserRoom> userRooms) QueryList(int? roomID);


    }
}
