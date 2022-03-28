using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChatRoom.Persistent.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private string connectionString;

        public RoomRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public (Exception exception, Room room) Add(string roomName)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Room>(
                        "pro_roomAdd",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            roomName = roomName,
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Room room) Delete(int id)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Room>(
                        "pro_roomDelete",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            id = id,
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<Room> rooms) QueryList()
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.Query<Room>(
                        "pro_roomQueryList",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Room room) Update(Room room)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Room>(
                        "pro_roomUpdate",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            id = room.f_id,
                            roomName = room.f_roomName,
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }


    }
}
