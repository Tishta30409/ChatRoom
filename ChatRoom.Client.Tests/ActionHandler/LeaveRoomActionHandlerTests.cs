using ChatRoom.Client.ActionHandler;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ChatRoom.Client.Tests.ActionHandler
{
    [TestClass]
    public class LeaveRoomActionHandlerTests
    {
        [TestMethod]
        public void 離開房間通知測試()
        {
            var console = new Mock<IConsoleWrapper>();

            var handler = new LeaveRoomActionHandler(console.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new LeaveRoomAction()
                {
                    RoomID = 1,
                    NickName = "測試發化緣",
                    CreateDateTime = DateTime.Now,
                }.ToString()
            });

            Assert.IsTrue(result);
        }
    }
}
