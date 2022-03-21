using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using System;
using System.Collections.Generic;

namespace ChatRoom.Domain.Service
{
    public interface IAccountService
    {
        (Exception exception, Login login) Login(LoginDto login);

        (Exception exception, Account account) Add(Account account);

        (Exception exception, Account account) Update(Account account);

        (Exception exception, Account account) Query(string account);

        (Exception exception, IEnumerable<Account> accounts) QueryList();

        (Exception exception, Account account) Delete(int id);
    }
}
