using ChatRoom.Client.Model.Process;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ChatRoom.Client.Tests
{
    [TestClass]
    public class LoginMainProcessTests
    {
        [TestMethod]
        public void 登入帳號測試()
        {
            var accountSvc = new Mock<IAccountService>();
            accountSvc.Setup(p => p.Login(It.IsAny<LoginDto>())).Returns((null, new AccountResult()
            {
                ResultCode = ResultCode.SUCCESS,
                Account = new Account()
                {
                    f_id = 1,
                    f_account = "test123",
                    f_password = "123456",
                    f_nickName = "我是測試",
                    f_errorTimes = 0,
                    f_loginIdentifier = new Guid().ToString(),
                    f_isLocked = 0,
                    f_isMuted = 0,
                }
            }));

            //模擬輸入
            var keyboardReader = new Mock<IKeyboardReader>();
            keyboardReader.SetupSequence(p => p.GetInputString(@"^[a-zA-Z0-9]*$", false, UserConstants.AccountLength)).Returns("test123");
            keyboardReader.SetupSequence(p => p.GetInputString(@"^[a-zA-Z0-9]*$", true, UserConstants.PasswordLength)).Returns("123456");

            var console = new Mock<IConsoleWrapper>();

            //不模擬連線
            var process = new LoginMainProcess(accountSvc.Object, console.Object, keyboardReader.Object, null);
            var result = process.Execute();

            Assert.AreEqual(result, ProcessViewType.Lobby);
        }
    }
}
