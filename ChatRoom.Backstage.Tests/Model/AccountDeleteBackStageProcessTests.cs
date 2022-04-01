using ChatRoom.Backstage.Model;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChatRoom.Backstage.Tests.Model
{
    [TestClass]
    public class AccountDeleteBackStageProcessTests
    {
        [TestMethod]
        public void 刪除帳號測試()
        {
            var accountSvc = new Mock<IAccountService>();
            var console = new Mock<IConsoleWrapper>();
            var keyboardReader = new Mock<IKeyboardReader>();

            accountSvc.Setup(p => p.Delete(1)).Returns((null, new Account()
            {
                f_id = 1,
                f_account = "test001",
                f_password = "123456",
                f_nickName = "你好",
                f_errorTimes = 0,
                f_isLocked = 0,
                f_isMuted = 0
            }));

            var process = new AccountDeleteBackStageProcess(accountSvc.Object, console.Object, keyboardReader.Object);
            var result = process.Execute();

            Assert.IsTrue(result);

        }
    }
}
