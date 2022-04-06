using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Controllers;
using ChatRoom.Server.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;

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
                .Returns((null, ResultCode.SUCCESS));

            var repoHistory = new Mock<IHistoryRepository>();

            //模擬廣播 TODO
            var hub = new Mock<IHubClient>();

            var controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            var postRsult = controller.Register(new AccountDto()
            {
                Account = "test123",
                Password = "123456",
                NickName = "我是測試"
            });

            var result = JsonConvert.DeserializeObject<ResultCode>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void 登入帳號測試()
        {
            var repo = new Mock<IAccountRepository>();

            // 一般登入
            repo.Setup(p => p.Login(It.IsAny<Account>()))
                .Returns((null, new AccountResult()
                {
                    ResultCode = ResultCode.SUCCESS,
                    Account = new Account()
                    {
                        f_account = "test123",
                        f_password = "123456",
                        f_errorTimes = 0,
                        f_nickName = "test123",
                        f_id = 1,
                        f_isLocked = 0,
                        f_isMuted = 0,
                    }
                }));

            //模擬廣播 TODO
            var hub = new Mock<IHubClient>();
            var repoHistory = new Mock<IHistoryRepository>();

            var controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            var postRsult = controller.Login(new LoginDto()
            {
                Account = "test123",
                Password = "123456",
            });

            var result = JsonConvert.DeserializeObject<Account>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);


            //帳號鎖定
            repo.Setup(p => p.Login(It.IsAny<Account>()))
               .Returns((null, new AccountResult()
               {
                   ResultCode = ResultCode.ACCOUNT_LOCKED,
                   Account = new Account()
                   {
                       f_account = "test123",
                       f_password = "123456",
                       f_errorTimes = 0,
                       f_nickName = "test123",
                       f_id = 1,
                       f_isLocked = 0,
                       f_isMuted = 0,
                   }
               }));


            controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            postRsult = controller.Login(new LoginDto()
            {
                Account = "test123",
                Password = "123456",
            });

            result = JsonConvert.DeserializeObject<Account>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);

            // 密碼錯誤
            repo.Setup(p => p.Login(It.IsAny<Account>()))
               .Returns((null, new AccountResult()
               {
                   ResultCode = ResultCode.WORNG_PASSWORD,
                   Account = new Account()
                   {
                       f_account = "test123",
                       f_password = "123456",
                       f_errorTimes = 0,
                       f_nickName = "test123",
                       f_id = 1,
                       f_isLocked = 0,
                       f_isMuted = 0,
                   }
               }));



            controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            postRsult = controller.Login(new LoginDto()
            {
                Account = "test123",
                Password = "123457",
            });

            result = JsonConvert.DeserializeObject<Account>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);

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
                    f_isLocked = 0,
                    f_isMuted = 0,
                    f_errorTimes = 0,
                })));

            //模擬廣播 TODO
            var hub = new Mock<IHubClient>();
            var repoHistory = new Mock<IHistoryRepository>();

            var controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            var postRsult = controller.GetList();
            var result = JsonConvert.DeserializeObject<IEnumerable<Account>>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void 刪除帳號測試()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(p => p.Delete(1))
                .Returns((null, new Account() { f_account = "test123", f_password = "123456", f_nickName = "我是測試" }));

            //模擬廣播 TODO
            var hub = new Mock<IHubClient>();
            var repoHistory = new Mock<IHistoryRepository>();

            var controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            var postRsult = controller.Delete(1);

            var result = JsonConvert.DeserializeObject<Account>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void 更新帳號測試()
        {
            var repo = new Mock<IAccountRepository>();

            repo.Setup(p => p.Add(It.IsAny<Account>()))
                .Returns((null, ResultCode.SUCCESS));

            //模擬廣播 TODO
            var hub = new Mock<IHubClient>();
            var repoHistory = new Mock<IHistoryRepository>();

            var controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            var postRsult = controller.Register(new AccountDto()
            {
                Account = "test123",
                Password = "123456",
                NickName = "我是測試"
            });

            var registerResult = JsonConvert.DeserializeObject<ResultCode>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(registerResult);

            repo.Setup(p => p.Update(It.IsAny<Account>()))
                .Returns((null,
                new AccountResult()
                {
                    ResultCode = ResultCode.SUCCESS,
                    Account = new Account()
                    {
                        f_id = 1,
                        f_account = "test123",
                        f_password = "123456",
                        f_nickName = "我是測試",
                        f_errorTimes = 0,
                        f_isLocked = 0,
                        f_isMuted = 0,
                        f_loginIdentifier = MD5.Create().ToString(),
                    }
                }));

            controller = new AccountController(repo.Object, repoHistory.Object, hub.Object);
            var postUpdateResult = controller.Update(new Account()
            {
                f_id = 1,
                f_account = "test123",
                f_password = "123456",
                f_nickName = "我是測試",
                f_errorTimes = 0,
                f_isLocked = 0,
                f_isMuted = 0,
                f_loginIdentifier = MD5.Create().ToString(),
                f_serialNumber = 0
            });

            var updateResult = JsonConvert.DeserializeObject<Account>(postUpdateResult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postUpdateResult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(updateResult);
        }
    }
}
