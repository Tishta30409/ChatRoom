using ChatRoom.Client.ActionHandler;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ChatRoom.Client.Tests.ActionHandler
{
    [TestClass]
    public class AccountDisconnectActionHandlerTests
    {
        [TestMethod]
        public void 玩家斷線通知測試()
        {
            var console = new Mock<IConsoleWrapper>();

            var hubClient = new Mock<IHubClient>();

            var handler = new AccountDisconnectActionHandler(console.Object, hubClient.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new AccountDisconnectAction()
                {
                    Account = "test001"
                }.ToString()
            });

            Assert.IsTrue(result);
        }
    }
}
