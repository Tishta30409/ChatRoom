using ChatRoom.Client.ActionHandler;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChatRoom.Client.Tests.ActionHandler
{
    [TestClass]
    public class UpdateAccountActionHandlerTests
    {
        [TestMethod]
        public void 通知玩家更新測試()
        {
            var console = new Mock<IConsoleWrapper>();

            var hubClient = new Mock<IHubClient>();

            var handler = new UpdateAccountActionHandler(console.Object, hubClient.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new UpdateAccountAction()
                {
                    Account = new Account()
                    {
                        f_id = 1,
                        f_account = "test123",
                        f_password = "123456",
                        f_errorTimes = 0,
                        f_isLocked = false,
                        f_isMuted = false,
                        f_nickName = "test123",
                       f_roomID =0
                          
                    }
                }.ToString()
            });

            Assert.IsTrue(result);
        }
    }
}
