using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Persistent.Repository;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace ChatRoom.Persistent.Tests
{
    [TestClass]
    public class HistoryRepositoryTests
    {
        private const string connectionString = @"Data Source=localhost;database=ChatRoom;Integrated Security=True";

        private IHistoryRepository repo;

        [TestInitialize]
        public void Init()
        {
            var sqlStr = @"TRUNCATE TABLE t_account";

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Execute(sqlStr);
            }

            this.repo = new HistoryRepository(connectionString);
        }

        [TestMethod]
        public void 新增歷史資料測試()
        {
            var addResult = this.repo.Add(new History()
            {
                f_roomID = 1,
                f_content = "123456",
                f_nickName = "你好我是",
                f_createDateTime = DateTime.Now
            });
            
            for (int i=0; i< 20; i++)
            {
                addResult = this.repo.Add(new History() 
                { 
                    f_roomID = 1, 
                    f_content = "123456", 
                    f_nickName = "你好我是" , 
                    f_createDateTime = DateTime.Now
                });
            }
                

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.history);
            Assert.AreEqual(addResult.history.f_roomID, 1);
            Assert.AreEqual(addResult.history.f_content, "123456");
            Assert.AreEqual(addResult.history.f_nickName, "你好我是");

        }

    }
}
