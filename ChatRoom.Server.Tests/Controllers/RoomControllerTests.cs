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
    public class RoomControllerTests
    {
        [TestMethod]
        public void 新增房間測試()
        {
            var repo = new Mock<IRoomRepository>();
            repo.Setup(p => p.Add("room001"))
                .Returns((null, new Room()
                {
                    f_id = 1,
                    f_roomName = "RoomTest11"
                }));

            var hubClient = new Mock<IHubClient>();

            var controller = new RoomController(repo.Object, hubClient.Object);
            var postRsult = controller.Add("room001");

            var result = JsonConvert.DeserializeObject<Account>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void 刪除房間測試()
        {
            var repo = new Mock<IRoomRepository>();
            repo.Setup(p => p.Delete(1))
                .Returns((null, new Room() { f_roomName = "room001" }));

            var hubClient = new Mock<IHubClient>();

            var controller = new RoomController(repo.Object, hubClient.Object);
            var postRsult = controller.Delete(1);

            var result = JsonConvert.DeserializeObject<Room>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void 取得房間清單測試()
        {
            var repo = new Mock<IRoomRepository>();
            repo.Setup(p => p.QueryList())
                .Returns((null, Enumerable.Range(1, 10).Select(index => new Room()
                {
                    f_id = index,
                    f_roomName = $"room{index}"
                })));

            var hubClient = new Mock<IHubClient>();

            var controller = new RoomController(repo.Object, hubClient.Object);
            var postRsult = controller.GetList();
            var result = JsonConvert.DeserializeObject<IEnumerable<Room>>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }
    }
}