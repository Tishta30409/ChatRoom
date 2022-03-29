﻿using ChatRoom.Domain.Model.DataType.Tsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Repository
{
    public interface IUserRoomRepository
    {
        (Exception exception, UserRoom userRoom) JoinRoom(UserRoom userRoom);

        (Exception exception, UserRoom userRoom) LeaveRoom(string account);
    }
}
