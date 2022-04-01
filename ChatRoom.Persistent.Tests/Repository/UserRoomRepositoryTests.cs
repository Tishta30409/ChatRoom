using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using ChatRoom.Persistent.Repository;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Linq;

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

            var userResult = this.repo.JoinRoom(new UserRoom()
            {
                f_account = "test002",
                f_roomID = 1,
                f_nickName = "test002"
            });

            Assert.IsNull(userResult.exception);
            Assert.IsNotNull(userResult);
            Assert.AreEqual("test002", userResult.userRoom.f_account);
        }

        [TestMethod]
        public void 離開房間測試()
        {
            var roomResult = this.roomRepository.Add("測試房間");
            Assert.IsNull(roomResult.exception);
            Assert.IsNotNull(roomResult);

            var userResult = this.repo.JoinRoom(new UserRoom()
            {
                f_account = "test002",
                f_roomID = 1,
                f_nickName = "test002"
            }) ;

            Assert.IsNull(userResult.exception);
            Assert.IsNotNull(userResult);
            Assert.AreEqual("test002", userResult.userRoom.f_account);

            var leaveResult = this.repo.LeaveRoom("test002");

            Assert.IsNull(leaveResult.exception);
            Assert.IsNotNull(leaveResult);
            Assert.AreEqual("test002", leaveResult.userRoom.f_account);
            Assert.IsNotNull(leaveResult.userRoom.f_roomID);
        }

        [TestMethod]
        public void 取得玩家狀態測試()
        {
            this.roomRepository.Add("測試房間1");
            this.roomRepository.Add("測試房間2");
            this.roomRepository.Add("測試房間3");
            this.roomRepository.Add("測試房間4");
            this.roomRepository.Add("測試房間5");
            this.roomRepository.Add("測試房間6");

            this.repo.JoinRoom(new UserRoom() { f_account = "test001", f_roomID = 1, f_nickName = "test0001" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test002", f_roomID = 1, f_nickName = "test0002" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test003", f_roomID = 1, f_nickName = "test0003" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test004", f_roomID = 1, f_nickName = "test0004" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test005", f_roomID = 1, f_nickName = "test0005" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test006", f_roomID = 1, f_nickName = "test0006" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test007", f_roomID = 1, f_nickName = "test0007" });

            var listResult = this.repo.Query("test001");

            Assert.IsNull(listResult.exception);
            Assert.IsNotNull(listResult.userRoom);
        }

        [TestMethod]
        public void 取得房間列表測試()
        {
            this.roomRepository.Add("測試房間1");
            this.roomRepository.Add("測試房間2");
            this.roomRepository.Add("測試房間3");
            this.roomRepository.Add("測試房間4");
            this.roomRepository.Add("測試房間5");
            this.roomRepository.Add("測試房間6");

            this.repo.JoinRoom(new UserRoom() { f_account = "test001", f_roomID = 1, f_nickName = "test0001" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test002", f_roomID = 1, f_nickName = "test0002" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test003", f_roomID = 1, f_nickName = "test0003" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test004", f_roomID = 1, f_nickName = "test0004" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test005", f_roomID = 1, f_nickName = "test0005" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test006", f_roomID = 1, f_nickName = "test0006" });
            this.repo.JoinRoom(new UserRoom() { f_account = "test007", f_roomID = 1, f_nickName = "test0007" });

            var listResult = this.repo.QueryList(1);

            Assert.IsNull(listResult.exception);
            Assert.IsNotNull(listResult);
            Assert.AreEqual(listResult.userRooms.Count(), 7);
        }


    }
}
