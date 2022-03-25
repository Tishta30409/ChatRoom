using ChatRoom.Backstage.Model;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Linq;

namespace ChatRoom.Backstage.Tests.Model
{
    [TestClass]
    public class RoomAddBackStageProcessTests
    {
        [TestMethod]
        public void 新增房間測試()
        {
            var roomSvc = new Mock<IRoomService>();
            roomSvc.Setup(p => p.Add("testName01")).Returns((null, ResultCode.SUCCESS));

            var console = new Mock<IConsoleWrapper>();

            var keyboardReader = new Mock<IKeyboardReader>();
            keyboardReader.Setup(x => x.GetInputString("", false, UserConstants.RoomNameLength)).Returns("testName01");

            var process = new RoomAddBackStageProcess(roomSvc.Object,  console.Object, keyboardReader.Object);
            var result = process.Execute();

            Assert.IsTrue(result);

        }
    }
}
