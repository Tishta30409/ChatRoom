using ChatRoom.Backstage.Model;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Linq;

namespace ChatRoom.Backstage.Tests.Model
{
    [TestClass]
    public class RoomUpdateBackStageProcessTests
    {
        [TestMethod]
        public void 刪除房間測試()
        {
            var roomSvc = new Mock<IRoomService>();

            roomSvc.SetupSequence(p => p.GetList()).Returns((null, Enumerable.Range(1, 5).Select(index => new Room()
            {
                f_id = index,
                f_roomName = $"roomName{index}"
            })));

            roomSvc.SetupSequence(p => p.Update(It.IsAny<Room>())).Returns((null, new Room()
            {
                f_id = 1,
                f_roomName = "testName01"
            }));

            var console = new Mock<IConsoleWrapper>();

            var keyboardReader = new Mock<IKeyboardReader>();
            keyboardReader.SetupSequence(x => x.GetInputString("^[0-9]*$", false, UserConstants.DefaultLength)).Returns("1");
            keyboardReader.SetupSequence(x => x.GetInputString("^[0-9]*$", false, UserConstants.RoomNameLength)).Returns("testName02");


            var process = new RoomUpdateBackStageProcess(roomSvc.Object,  console.Object, keyboardReader.Object);
            var result = process.Execute();

            Assert.IsTrue(result);

        }
    }
}
