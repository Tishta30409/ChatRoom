﻿using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Repository;
using ChatRoom.Persistent.Repository;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Linq;

namespace ChatRoom.Persistent.Tests
{
    [TestClass]
    public class AccountRepositoryTests
    {
        private const string connectionString = @"Data Source=localhost;database=ChatRoom;Integrated Security=True";

        private IAccountRepository repo;

        [TestInitialize]
        public void Init()
        {
            var sqlStr = @"TRUNCATE TABLE t_account";

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Execute(sqlStr);
            }

            this.repo = new AccountRepository(connectionString);
        }

        [TestMethod]
        public void 新增帳號測試()
        {
            var addResult = this.repo.Add(new Account() { f_account = "test000", f_password = "123456", f_nickName = "你好我是" });

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.account);
            Assert.AreEqual(addResult.account.f_account, "test000");
            Assert.AreEqual(addResult.account.f_password, "123456");
            Assert.AreEqual(addResult.account.f_nickName, "你好我是");

            //重複帳號測試
            var addAgainResult = this.repo.Add(new Account() { f_account = "test000", f_password = "123456", f_nickName = "你好我是" });
            Assert.IsNull(addAgainResult.exception);

        }

        [TestMethod]
        public void 登入帳號測試()
        {
            //正常登入
            var addResult = this.repo.Add(new Account() { f_account = "test000", f_password = "123456", f_nickName = "你好我是" });

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.account);
            Assert.AreEqual(addResult.account.f_account, "test000");
            Assert.AreEqual(addResult.account.f_password, "123456");
            Assert.AreEqual(addResult.account.f_nickName, "你好我是");

            var loginResult = this.repo.Login(new Login() { f_account = "test000", f_password = "123456" });
            Assert.IsNull(loginResult.exception);
            Assert.IsNotNull(loginResult.login);
            Assert.AreEqual(loginResult.login.resultCode, AccountResult.SUCCESS);

            //錯誤一次
            loginResult = this.repo.Login(new Login() { f_account = "test000", f_password = "123457" });
            Assert.IsNull(loginResult.exception);
            Assert.IsNotNull(loginResult.login);
            Assert.AreEqual(loginResult.login.resultCode, AccountResult.WORNG_PASSWORD);
            Assert.AreEqual(loginResult.login.data.f_errorTimes, 1);

            //正常登入 清空錯誤
            loginResult = this.repo.Login(new Login() { f_account = "test000", f_password = "123456" });
            Assert.IsNull(loginResult.exception);
            Assert.IsNotNull(loginResult.login);
            Assert.AreEqual(loginResult.login.resultCode, AccountResult.SUCCESS);
            Assert.AreEqual(loginResult.login.data.f_errorTimes, 0);

            //錯誤一次
            loginResult = this.repo.Login(new Login() { f_account = "test000", f_password = "123457" });
            Assert.IsNull(loginResult.exception);
            Assert.IsNotNull(loginResult.login);
            Assert.AreEqual(loginResult.login.resultCode, AccountResult.WORNG_PASSWORD);
            Assert.AreEqual(loginResult.login.data.f_errorTimes, 1);

            //錯誤二次
            loginResult = this.repo.Login(new Login() { f_account = "test000", f_password = "123457" });
            Assert.IsNull(loginResult.exception);
            Assert.IsNotNull(loginResult.login);
            Assert.AreEqual(loginResult.login.resultCode, AccountResult.WORNG_PASSWORD);
            Assert.AreEqual(loginResult.login.data.f_errorTimes, 2);

            //錯誤三次
            loginResult = this.repo.Login(new Login() { f_account = "test000", f_password = "123457" });
            Assert.IsNull(loginResult.exception);
            Assert.IsNotNull(loginResult.login);
            Assert.AreEqual(loginResult.login.resultCode, AccountResult.WORNG_PASSWORD);
            Assert.AreEqual(loginResult.login.data.f_errorTimes, 3);

            //帳號鎖定
            loginResult = this.repo.Login(new Login() { f_account = "test000", f_password = "123456" });
            Assert.IsNull(loginResult.exception);
            Assert.IsNotNull(loginResult.login);
            Assert.AreEqual(loginResult.login.resultCode, AccountResult.ACCOUNT_LOCKED);


        }

        [TestMethod]
        public void 更新帳號測試()
        {
            var addResult = this.repo.Add(new Account() { f_account = "test000", f_password = "123456", f_nickName = "你好我是" });

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.account);
            Assert.AreEqual(addResult.account.f_account, "test000");
            Assert.AreEqual(addResult.account.f_password, "123456");
            Assert.AreEqual(addResult.account.f_nickName, "你好我是");

            var updateResult = this.repo.Update(new Account() { 
                f_account = "test000", 
                f_password = "654321", 
                f_nickName = "我是你好" ,
                f_isLocked = true,
                f_isMuted = false,
                f_errorTimes = 3
            
            });
            Assert.IsNull(updateResult.exception);
            Assert.IsNotNull(updateResult.account);
            Assert.AreEqual(updateResult.account.f_account, "test000");
            Assert.AreEqual(updateResult.account.f_password, "654321");
            Assert.AreEqual(updateResult.account.f_nickName, "我是你好");
            Assert.AreEqual(updateResult.account.f_isLocked, true);
            Assert.AreEqual(updateResult.account.f_isMuted, false);
            Assert.AreEqual(updateResult.account.f_errorTimes, 3);
        }

          [TestMethod]
        public  void 刪除帳號測試()
        {
            var addResult = this.repo.Add(new Account() { f_account = "test000", f_password = "123456", f_nickName = "你好我是" });

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.account);
            Assert.AreEqual(addResult.account.f_account, "test000");
            Assert.AreEqual(addResult.account.f_password, "123456");
            Assert.AreEqual(addResult.account.f_nickName, "你好我是");

            var deleteResult = this.repo.Delete(1);
            Assert.IsNull(deleteResult.exception);
            Assert.IsNotNull(deleteResult.account);
            Assert.AreEqual(deleteResult.account.f_account, "test000");
            Assert.AreEqual(deleteResult.account.f_password, "123456");
            Assert.AreEqual(deleteResult.account.f_nickName, "你好我是");

            //重複刪除測試
            deleteResult = this.repo.Delete(1);
            Assert.IsNull(deleteResult.exception);
        }

        [TestMethod]
        public void 查詢帳號測試()
        {
            var addResult = this.repo.Add(new Account() { f_account = "test000", f_password = "123456", f_nickName = "你好我是" });

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.account);
            Assert.AreEqual(addResult.account.f_account, "test000");
            Assert.AreEqual(addResult.account.f_password, "123456");
            Assert.AreEqual(addResult.account.f_nickName, "你好我是");

            var queryResult = this.repo.Query("test000");
            Assert.IsNull(queryResult.exception);
            Assert.IsNotNull(queryResult.account);
            Assert.AreEqual(queryResult.account.f_account, "test000");
            Assert.AreEqual(queryResult.account.f_password, "123456");
            Assert.AreEqual(queryResult.account.f_nickName, "你好我是");
        }

        [TestMethod]
        public void 查詢帳號清單測試()
        {
            this.repo.Add(new Account() { f_account = "test000", f_password = "123456", f_nickName = "你好我是" });
            this.repo.Add(new Account() { f_account = "test001", f_password = "123456", f_nickName = "你好我是" });
            this.repo.Add(new Account() { f_account = "test002", f_password = "123456", f_nickName = "你好我是" });
            this.repo.Add(new Account() { f_account = "test003", f_password = "123456", f_nickName = "你好我是" });
            this.repo.Add(new Account() { f_account = "test004", f_password = "123456", f_nickName = "你好我是" });


            var queryResult = this.repo.QueryList();
            Assert.IsNull(queryResult.exception);
            Assert.IsNotNull(queryResult.accounts);
            Assert.AreEqual(queryResult.accounts.Count(), 5);
        }

    }
}
