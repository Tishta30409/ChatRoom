using ChatRoom.Domain.Model.DataType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatRoom.Domain.Model
{
    public class RoomLocker
    {
        private object locker;

        private List<Room> rooms;

        public RoomLocker(List<Room> data)
        {
            this.locker = new object();
            this.rooms = data;
        }

        public List<Room> GetRooms()
        {
            return this.rooms;
        }

        public Room GetElement(int rowIndex)
        {
            return this.rooms[rowIndex];
        }

        public bool SetElement(int rowIndex, Room room)
        {
            lock (this.locker)
            {
                this.rooms[rowIndex] = room;
                return true;
            }
           
        }

        public int Count()
        {
            return this.rooms.Count;
        }

        public void Clear()
        {
            this.rooms.Clear();
        }

        //
        public bool TryAdd(Room room)
        {
            lock (locker)
            {
                 if( this.rooms.FirstOrDefault(x => x.f_roomName == room.f_roomName) == null)
                {
                    this.rooms.Add(room);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Remove(Room room)
        {
            lock (locker)
            {
                this.rooms =  this.rooms.Where(p=> p.f_roomName != room.f_roomName).ToList();
            }
        }

    }
}
