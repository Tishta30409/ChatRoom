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
    public class ChatMessageActionHandlerTests
    {
        [TestMethod]
        public void 聊天訊息通知測試()
        {
            var console = new Mock<IConsoleWrapper>();

            var handler = new ChatMessageActionHandler(console.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new ChatMessageAction()
                {
                    RoomID = 1,
                    NickName = "測試發話員",
                    Content = "測試發話",
                    CreateDateTime = DateTime.Now,
                }.ToString()
            });

            Assert.IsTrue(result);
        }
    
    }
}
