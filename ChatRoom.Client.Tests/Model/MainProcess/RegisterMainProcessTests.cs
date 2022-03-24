using ChatRoom.Client.Model.Process;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ChatRoom.Client.Tests.Model.MainProcess
{
    [TestClass]
    public class RegisterMainProcessTests
    {
        [TestMethod]
        public void 註冊帳號測試()
        {
            var accountSvc = new Mock<IAccountService>();
            accountSvc.Setup(p => p.Register(It.IsAny<AccountDto>())).Returns((null, new AccountResult()
            {
                resultCode = ResultCode.SUCCESS,
                account = new Account()
                {
                    f_id = 1,
                    f_account = "test123",
                    f_password = "123456",
                    f_nickName = "我是測試",
                    f_errorTimes = 0,
                    f_guid = new Guid(),
                    f_isLocked = false,
                    f_isMuted = false,
                    f_roomID = 1
                }
            }));

            var console = new Mock<IConsoleWrapper>();

            //模擬輸入
            var keyboardReader = new Mock<IKeyboardReader>();
            keyboardReader.SetupSequence(p=>p.GetInputString(@"^[a-zA-Z0-9]*$", false, UserConstants.AccountLength)).Returns("test001");
            keyboardReader.SetupSequence(p => p.GetInputString(@"^[a-zA-Z0-9]*$", true, UserConstants.PasswordLength)).Returns("123456");
            keyboardReader.SetupSequence(p => p.GetInputString(@"^[a-zA-Z0-9]*$", true, UserConstants.PasswordLength)).Returns("123456");
            keyboardReader.SetupSequence(p => p.GetInputString("", false, UserConstants.NickNameLength)).Returns("Test001");

            var process = new RegisterMainProcess(accountSvc.Object, console.Object, keyboardReader.Object);
            var result = process.Execute();

            Assert.AreEqual(result, ProcessViewType.Main);

        }
    }
}
