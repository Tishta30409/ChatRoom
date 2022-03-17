using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Net;

namespace ChatRoom.Server.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void 新增帳號測試()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(p => p.Add(It.IsAny<Account>()))
                .Returns((null, new Account() { f_account = "test123", f_password = "123456", f_nickName = "我是測試" }));

            var controller = new AccountController(repo.Object);
            var postRsult = controller.Post(new AccountDto()
            {
                Account = "test123",
                Password = "123456",
                NickName = "我是測試"
            });

            var result = JsonConvert.DeserializeObject<Account>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void 登入帳號測試()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(p => p.Query("test123"))
                .Returns((null, new Account() 
                { 
                    f_account = "test123", 
                    f_password = "123456", 
                    f_nickName = "我是測試", 
                    f_state =AccountState.Normal,
                    f_errorTimes = 0 
                }));

            var controller = new AccountController(repo.Object);
            var postRsult = controller.Post(new LoginDto()
            {
                Account = "test123",
                Password = "123456",
            });

            var result = JsonConvert.DeserializeObject<LoginDto>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        public void 取得帳號清單測試()
        {
        }

        public void 刪除帳號清單測試()
        {
        }
    }
}
