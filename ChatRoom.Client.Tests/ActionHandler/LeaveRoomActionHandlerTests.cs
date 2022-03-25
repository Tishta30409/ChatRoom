using ChatRoom.Client.ActionHandler;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChatRoom.Client.Tests.ActionHandler
{
    [TestClass]
    public class LeaveRoomActionHandlerTests
    {
        [TestMethod]
        public void 通知玩家離開房間測試()
        {
            var console = new Mock<IConsoleWrapper>();


            var handler = new LeaveRoomActionHandler(console.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new LeaveRoomAction()
                {
                    RoomID = 1
                }.ToString()
            });

            Assert.IsTrue(result);
        }
    }
}
