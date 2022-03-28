using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Repository;
using ChatRoom.Persistent.Repository;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace ChatRoom.Persistent.Tests.Repository
{
    [TestClass]
    public class UserRoomRepositoryTests
    {
        private const string connectionString = @"Data Source=localhost;database=ChatRoom;Integrated Security=True";

        private IUserRoomRepository repo;

        private IRoomRepository roomRepository;

        [TestInitialize]
        public void Init()
        {
            var sqlStr = @"TRUNCATE TABLE t_room TRUNCATE TABLE t_userroom";


            using (var cn = new SqlConnection(connectionString))
            {
                cn.Execute(sqlStr);
            }

            this.repo = new UserRoomRepository(connectionString);

            this.roomRepository = new RoomRepository(connectionString);
        }

        [TestMethod]
        public void 加入房間測試()
        {
            var roomResult = this.roomRepository.Add("測試房間");
            Assert.IsNull(roomResult.exception);
            Assert.IsNotNull(roomResult);

            var userResult = this.repo.AddRoom(new UserRoom()
            {
                f_account = "test002",
                f_roomID = 1
            });

            Assert.IsNull(userResult.exception);
            Assert.IsNotNull(userResult);
            Assert.AreEqual("test002", userResult.data.f_account);
        }

        [TestMethod]
        public void 離開房間測試()
        {
            var roomResult = this.roomRepository.Add("測試房間");
            Assert.IsNull(roomResult.exception);
            Assert.IsNotNull(roomResult);

            var userResult = this.repo.AddRoom(new UserRoom()
            {
                f_account = "test002",
                f_roomID = 1
            });

            Assert.IsNull(userResult.exception);
            Assert.IsNotNull(userResult);
            Assert.AreEqual("test002", userResult.data.f_account);

            var leaveResult = this.repo.LeaveRoom("test002");

            Assert.IsNull(leaveResult.exception);
            Assert.IsNotNull(leaveResult);
            Assert.AreEqual("test002", leaveResult.data.f_account);
            Assert.IsNull(leaveResult.data.f_roomID);

        }


    }
}
