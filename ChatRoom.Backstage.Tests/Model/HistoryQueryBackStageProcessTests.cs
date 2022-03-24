using ChatRoom.Backstage.Model;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace ChatRoom.Backstage.Tests.Model
{
    [TestClass]
    public class HistoryQueryBackStageProcessTests
    {
        [TestMethod]
        public void 查詢歷史資料測試()
        {
            var historySvc = new Mock<IHistoryService>();

            var roomSvc = new Mock<IRoomService>();
            roomSvc.Setup(p => p.GetList()).Returns((null, Enumerable.Range(1, 5).Select(index => new Room()
            {
                f_id = index,
                f_roomName = $"roomName{index}"
            })));

            var console = new Mock<IConsoleWrapper>();

            var keyboardReader = new Mock<IKeyboardReader>();
            keyboardReader.Setup(x => x.GetInputString("^[0-9]*$", false, UserConstants.DefaultLength)).Returns("1");

            historySvc.Setup(p => p.QueryList(1)).Returns((null, Enumerable.Range(1, 10).Select(index => new History()
            {
                f_id = index,
                f_nickName = "test001",
                f_createDateTime = DateTime.Now,
                f_content = "測試內容",
                f_roomID = 1
            })));

            var process = new HistoryQueryBackStageProcess(historySvc.Object, roomSvc.Object, console.Object, keyboardReader.Object);
            var result = process.Execute();

            Assert.IsTrue(result);

        }
    }
}
