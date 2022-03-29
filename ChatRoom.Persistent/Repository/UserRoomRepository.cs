using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChatRoom.Persistent.Repository
{
    public class UserRoomRepository:IUserRoomRepository
    {
        private string connectionString;

        public UserRoomRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public (Exception exception, UserRoom userRoom) JoinRoom(UserRoom userRoom)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<UserRoom>(
                        "pro_userRoomJoin",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            Account = userRoom.f_account,
                            RoomID = userRoom.f_roomID,
                            NickName = userRoom.f_nickName,
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

        /// <summary>
        /// 登出有資料就清空
        /// </summary>
        /// <param name="userRoom"></param>
        /// <returns></returns>
        public (Exception exception, UserRoom userRoom) LeaveRoom(string account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<UserRoom>(
                        "pro_userRoomLeave",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            Account = account
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

        public (Exception exception, IEnumerable<UserRoom> userRooms) QueryList(int roomID)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.Query<UserRoom>(
                        "pro_userRoomQueryList",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            RoomID = roomID
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
