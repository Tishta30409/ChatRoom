using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Persistent.Repository;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ChatRoom.Persistent.Tests.Repository
{ 
    [TestClass]
    public class RoomRepositoryTests
    {
        private const string connectionString = @"Data Source=localhost;database=ChatRoom;Integrated Security=True";

        private IRoomRepository repo;

        [TestInitialize]
        public void Init()
        {
            var sqlStr = @"TRUNCATE TABLE t_room";

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Execute(sqlStr);
            }

            this.repo = new RoomRepository(connectionString);
        }

        [TestMethod]
        public void 新增房間測試()
        {
            var addResult = this.repo.Add("測試房間");

            for (int i = 0; i < 20; i++)
            {
                this.repo.Add($"測試房間{i}");
            }

            Assert.IsNull(addResult.exception);
            Assert.AreEqual(addResult.room.f_roomName, "測試房間");
        }

        [TestMethod]
        public void 刪除房間測試()
        {
            var addResult = this.repo.Add("測試房間");
            Assert.IsNull(addResult.exception);
            Assert.AreEqual(addResult.room.f_roomName, "測試房間");

            var delResult = this.repo.Delete(1);
            Assert.IsNull(delResult.exception);
            Assert.AreEqual(delResult.room.f_roomName, "測試房間");

            var delAgainResult = this.repo.Delete(1);
            Assert.IsNull(delAgainResult.exception);
        }

        [TestMethod]
        public void 更新房間測試()
        {
            var addResult = this.repo.Add("測試房間");
            Assert.IsNull(addResult.exception);
            Assert.AreEqual(addResult.room.f_roomName, "測試房間");

            var delResult = this.repo.Update(new Room() { f_id = 1, f_roomName = "測試房間2"});
            Assert.IsNull(delResult.exception);
            Assert.AreEqual(delResult.room.f_roomName, "測試房間2");
        }

        [TestMethod]
        public void 查詢房間測試()
        {
            this.repo.Add("測試房間1");
            this.repo.Add("測試房間2");
            this.repo.Add("測試房間3");
            this.repo.Add("測試房間4");
            this.repo.Add("測試房間5");

            var listResult = this.repo.QueryList();
            Assert.IsNull(listResult.exception);
            Assert.AreEqual(listResult.rooms.Count(), 5);
        }

        
    }
}
