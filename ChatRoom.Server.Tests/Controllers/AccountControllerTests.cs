using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var postRsult = controller.AccountRegister(new AccountDto()
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

            // 一般登入
            repo.Setup(p => p.Login(It.IsAny<Login>()))
                .Returns((null, new Login()
                {
                   resultCode = AccountResult.SUCCESS,
                   data = new Account()
                   {
                       f_account = "test123",
                       f_password = "123456",
                       f_errorTimes = 0,
                       f_nickName = "test123",
                       f_id = 1,
                       f_isLocked = false,
                       f_isMuted = false,
                   }
                }));

            var controller = new AccountController(repo.Object);
            var postRsult = controller.Login(new LoginDto()
            {
                Account = "test123",
                Password = "123456",
            });

            var result = JsonConvert.DeserializeObject<Login>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.resultCode, AccountResult.SUCCESS);


            //帳號鎖定
            repo.Setup(p => p.Login(It.IsAny<Login>()))
               .Returns((null, new Login()
               {
                   resultCode = AccountResult.ACCOUNT_LOCKED,
                   data = new Account()
                   {
                       f_account = "test123",
                       f_password = "123456",
                       f_errorTimes = 0,
                       f_nickName = "test123",
                       f_id = 1,
                       f_isLocked = false,
                       f_isMuted = false,
                   }
               }));

            controller = new AccountController(repo.Object);
            postRsult = controller.Login(new LoginDto()
            {
                Account = "test123",
                Password = "123456",
            });

            result = JsonConvert.DeserializeObject<Login>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.resultCode, AccountResult.ACCOUNT_LOCKED);

            // 密碼錯誤
            repo.Setup(p => p.Login(It.IsAny<Login>()))
               .Returns((null, new Login()
               {
                   resultCode = AccountResult.WORNG_PASSWORD,
                   data = new Account()
                   {
                       f_account = "test123",
                       f_password = "123456",
                       f_errorTimes = 0,
                       f_nickName = "test123",
                       f_id = 1,
                       f_isLocked = false,
                       f_isMuted = false,
                   }
               }));

            controller = new AccountController(repo.Object);
            postRsult = controller.Login(new LoginDto()
            {
                Account = "test123",
                Password = "123457",
            });

            result = JsonConvert.DeserializeObject<Login>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.resultCode, AccountResult.WORNG_PASSWORD);

        }

        [TestMethod]
        public void 取得帳號清單測試()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(p => p.QueryList())
                .Returns((null, Enumerable.Range(1, 10).Select(index => new Account()
                {
                    f_id = index,
                    f_account = $"acc{index}",
                    f_password = $"pass{index}",
                    f_nickName = $"nick{index}",
                    f_isLocked=false,
                    f_isMuted = false,
                    f_errorTimes = 0,
                })));

            var controller = new AccountController(repo.Object);
            var postRsult = controller.GetAccountList();
            var result = JsonConvert.DeserializeObject<IEnumerable<Account>>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void 刪除帳號清單測試()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(p => p.Delete(1))
                .Returns((null, new Account() { f_account = "test123", f_password = "123456", f_nickName = "我是測試" }));

            var controller = new AccountController(repo.Object);
            var postRsult = controller.AccountDelete(1);

            var result = JsonConvert.DeserializeObject<Account>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }
    }
}
