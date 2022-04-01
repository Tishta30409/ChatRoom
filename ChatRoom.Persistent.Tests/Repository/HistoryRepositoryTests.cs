using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using ChatRoom.Persistent.Repository;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ChatRoom.Persistent.Tests
{
    [TestClass]
    public class HistoryRepositoryTests
    {
        private const string connectionString = @"Data Source=localhost;database=ChatRoom;Integrated Security=True";

        private IHistoryRepository repo;

        private IRoomRepository roomRepo;

        [TestInitialize]
        public void Init()
        {
            var sqlStr = @"TRUNCATE TABLE t_history TRUNCATE TABLE t_room";

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Execute(sqlStr);
            }

            this.repo = new HistoryRepository(connectionString);

            this.roomRepo = new RoomRepository(connectionString);
        }

        [TestMethod]
        public void 新增歷史資料測試()
        {
            var addResult = this.repo.Add(new History()
            {
                f_roomID = 1,
                f_account = "test001",
                f_content = "123456",
                f_nickName = "你好我是",
                f_createDateTime = DateTime.Now
            });

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.history);
            Assert.AreEqual(addResult.history.f_roomID, 1);
            Assert.AreEqual(addResult.history.f_content, "123456");
            Assert.AreEqual(addResult.history.f_nickName, "你好我是");

        }

        [TestMethod]
        public void 查詢歷史資料測試()
        {

            for (int i = 0; i < 20; i++)
            {
                this.repo.Add(new History()
                {
                    f_roomID = 1,
                    f_account = "test001",
                    f_content = "123456",
                    f_nickName = "你好我是",
                    f_createDateTime = DateTime.Now
                });
            }

            var queryResult = this.repo.QueryList(1);

            Assert.IsNull(queryResult.exception);
            //只查10筆
            Assert.AreEqual(queryResult.historys.Count(), 10);
        }

        [TestMethod]
        public void 定時整理歷史資料測試()
        {
            for (int i = 0; i < 5; i++)
            {
                this.roomRepo.Add($"測試房間{i}");
            }

            for (int i = 0; i < 30; i++)
            {
                 this.repo.Add(new History()
                {
                    f_roomID = 1,
                    f_account = "test001",
                    f_content = "123456",
                    f_nickName = "你好我是",
                    f_createDateTime = DateTime.Now
                });
            }

            for (int i = 0; i < 5; i++)
            {
                this.repo.Add(new History()
                {
                    f_roomID = 2,
                    f_account = "test001",
                    f_content = "123456",
                    f_nickName = "你好我是",
                    f_createDateTime = DateTime.Now
                });
            }

            for (int i = 0; i < 10; i++)
            {
                this.repo.Add(new History()
                {
                    f_roomID = 3,
                    f_account = "test001",
                    f_content = "123456",
                    f_nickName = "你好我是",
                    f_createDateTime = DateTime.Now
                });
            }

            var sortResult = this.repo.SortOut();
            Assert.IsNull(sortResult.exception);

            //清除後最多應該只剩10筆
            var queryResult1 = this.repo.QueryList(1);
            Assert.IsNull(queryResult1.exception);
            Assert.AreEqual(queryResult1.historys.Count(), 10);

            var queryResult2 = this.repo.QueryList(2);
            Assert.IsNull(queryResult2.exception);
            Assert.AreEqual(queryResult2.historys.Count(), 5);

            var queryResult3 = this.repo.QueryList(3);
            Assert.IsNull(queryResult3.exception);
            Assert.AreEqual(queryResult3.historys.Count(), 10);

        }

        [TestMethod]
        public void 刪除歷史資料測試()
        {

            for (int i = 0; i < 20; i++)
            {
                this.repo.Add(new History()
                {
                    f_roomID = 1,
                    f_account = "test001",
                    f_content = "123456",
                    f_nickName = "你好我是",
                    f_createDateTime = DateTime.Now
                });
            }

            var queryResult = this.repo.QueryList(1);

            Assert.IsNull(queryResult.exception);
            //只查10筆
            Assert.AreEqual(queryResult.historys.Count(), 10);

            this.repo.Delete("test001");

            var queryResult2 = this.repo.QueryList(1);

            Assert.IsNull(queryResult2.exception);
            //只查10筆
            Assert.AreEqual(queryResult2.historys.Count(), 0);
        }


    }
}
