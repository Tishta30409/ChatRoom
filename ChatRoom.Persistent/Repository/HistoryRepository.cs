using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Persistent.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private string connectionString;

        public HistoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public (Exception exception, History history) Add(History history)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<History>(
                        "pro_historyAdd",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            roomID = history.f_roomID,
                            nickName = history.f_nickName,
                            content = history.f_content,
                            createDateTime = history.f_createDateTime
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

        public (Exception exception, IEnumerable<History> historys) QueryList(int roomID)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.Query<History>(
                        "pro_historyQueryList",
                        new { roomID = roomID },
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

        public (Exception exception, IEnumerable<History> historys) SortOut()
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.Query<History>(
                        "pro_historySortOut",
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
    }
}
