using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Repository;
using Dapper;
using System;
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
                        "pro_userroom_join",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            Account = userRoom.f_account,
                            RoomID = userRoom.f_roomID
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
                        "pro_userroom_leave",
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
    }
}
