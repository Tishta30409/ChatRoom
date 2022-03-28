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
    public class CheckConnectStateActionHandlerTests
    {
        [TestMethod]
        public void 檢查斷線通知()
        {
            var console = new Mock<IConsoleWrapper>();

            var handler = new CheckConnectStateActionHandler(console.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new CheckConnectStateAction()
                {
                    Account = "test123",
                    LoginIdentifier = new Guid().ToString(),
                }.ToString()
            }) ;

            Assert.IsTrue(result);
        }
    }
}
