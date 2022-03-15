using ChatRoom.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ChatRoom.Domain.Repository
{
    public enum AccountState: byte
    {
        Normal = 1,
        Mute = 2,
        Locking = 3,
    }

    public interface IAccountRepository
    {
        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Account account) Create(Account account);

        /// <summary>
        /// 更新帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Account account) Update(Account account);

        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Account account) Delete(string account);
    }
}
