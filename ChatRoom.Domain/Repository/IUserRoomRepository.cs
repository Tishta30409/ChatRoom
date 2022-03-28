using ChatRoom.Domain.Model.DataType.Tsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Repository
{
    public interface IUserRoomRepository
    {
        (Exception exception, UserRoom data) AddRoom(UserRoom userRoom);

        (Exception exception, UserRoom data) LeaveRoom(string account);
    }
}
