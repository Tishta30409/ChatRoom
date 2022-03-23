using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.ActionHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ChatRoom.Server.Tests.ActionHandler
{
    [TestClass]
    public class HistoryActionHandlerTests
    {
        [TestMethod]
        public void 歷史紀錄新增測試()
        {
            var repo = new Mock<IHistoryRepository>();

            repo.Setup(p => p.Add(It.IsAny<History>())).Returns((null, new History()
            {
                f_roomID = 1,
                f_nickName = "test001",
                f_content = "content0001",
                f_createDateTime = DateTime.Now
            }));

            var handler = new ChatMessageActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new ChatMessageAction()
                {
                    RoomID = 1,
                    NickName = "test001",
                    Content = "content0001",
                    CreateDateTime = DateTime.Now
                }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
