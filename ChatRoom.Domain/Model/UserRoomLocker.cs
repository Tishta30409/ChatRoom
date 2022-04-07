using ChatRoom.Domain.Model.DataType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatRoom.Domain.Model
{
    public class UserRoomLocker
    {
        private object locker;

        private List<UserRoom> userRooms;

        public UserRoomLocker(List<UserRoom> data)
        {
            this.locker = new object();
            this.userRooms = data;
        }

        public List<UserRoom> GetRoomUsers()
        {
            return this.userRooms;
        }

        public UserRoom GetElement(int rowIndex)
        {
            return this.userRooms[rowIndex];
        }

        public int Count()
        {
            return this.userRooms.Count;
        }

        public void Clear()
        {
            this.userRooms.Clear();
        }

        //
        public bool TryAdd(UserRoom userRoom)
        {
            lock (locker)
            {
                 if( this.userRooms.FirstOrDefault(x => x.f_nickName == userRoom.f_nickName) == null)
                {
                    this.userRooms.Add(userRoom);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Remove(UserRoom userRoom)
        {
            lock (locker)
            {
                this.userRooms =  this.userRooms.Where(p=> p.f_nickName != userRoom.f_nickName).ToList();
            }
        }

    }
}
