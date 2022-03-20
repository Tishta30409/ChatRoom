using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ChatRoom.Server.Tests.Controllers
{
    [TestClass]
    public class HistoryControllerTests
    {
        [TestMethod]
        public void 取得歷史資料測試()
        {
            var repo = new Mock<IHistoryRepository>();
            repo.Setup(p => p.QueryList(1))
                .Returns((null, Enumerable.Range(1, 10).Select(index => new History()
                {
                    f_id = index,
                    f_nickName = "test001",
                    f_content = "content123456",
                    f_createDateTime = DateTime.Now,
                    f_roomID = 1
                })));

            var controller = new HistoryController(repo.Object);
            var postRsult = controller.GetHistoryList(1);
            var result = JsonConvert.DeserializeObject<IEnumerable<History>>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }
    }
}
