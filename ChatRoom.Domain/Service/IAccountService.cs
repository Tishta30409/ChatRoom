﻿using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using System;
using System.Collections.Generic;

namespace ChatRoom.Domain.Service
{
    public interface IAccountService
    {

         /// <summary>
        /// 後臺使用 解禁言
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        (Exception exception, Account account) Update(Account account);

        (Exception exception, AccountResult result) Login(LoginDto login);

        (Exception exception, AccountResult result) Register(AccountDto account);

        (Exception exception, IEnumerable<Account> accounts) QueryList();

        (Exception exception, Account account) Delete(int id);
    }
}
