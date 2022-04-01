using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Controllers;
using ChatRoom.Server.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ChatRoom.Server.Tests.Controllers
{
    [TestClass]
    public class UserRoomControllerTests
    {
        [TestMethod]
        public void 新增房間測試()
        {
            var repo = new Mock<IUserRoomRepository>();
            repo.Setup(p => p.JoinRoom(It.IsAny<UserRoom>()))
                .Returns((null, new UserRoom()
                {
                    f_id = 1,
                    f_account = "roomTest11",
                    f_nickName = "TYkdja"
                }));

            var hubClient = new Mock<IHubClient>();

            var controller = new UserRoomController(repo.Object, hubClient.Object);
            var postRsult = controller.JoinRoom(new UserRoom()
            {
                f_id = 1,
                f_account = "roomTest11",
                f_nickName = "TYkdja"
            });

            var result = JsonConvert.DeserializeObject<UserRoom>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void 離開房間測試()
        {
            var repo = new Mock<IUserRoomRepository>();
            repo.Setup(p => p.LeaveRoom("test001"))
                .Returns((null, new UserRoom() {
                    f_roomID = 1,
                    f_account = "test001",
                    f_nickName = "test001"
                }));

            var hubClient = new Mock<IHubClient>();

            var controller = new UserRoomController(repo.Object, hubClient.Object);
            var postRsult = controller.LeaveRoom("test001");

            var result = JsonConvert.DeserializeObject<UserRoom>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void 取得房間清單測試()
        {
            var repo = new Mock<IUserRoomRepository>();
            repo.Setup(p => p.QueryList(1))
                .Returns((null, Enumerable.Range(1, 10).Select(index => new UserRoom()
                {
                    f_id = index,
                    f_account = $"acc{index}",
                    f_nickName = $"nick{index}",
                    f_roomID=1,
                })));

            var hubClient = new Mock<IHubClient>();

            var controller = new UserRoomController(repo.Object, hubClient.Object);
            var postRsult = controller.QueryList(1);
            var result = JsonConvert.DeserializeObject<IEnumerable<UserRoom>>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }
    }
}