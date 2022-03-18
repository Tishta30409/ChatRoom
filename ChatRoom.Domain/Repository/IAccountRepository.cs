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
        Locked = 3,
    }

    public enum AccountResult
    {
        SUCCESS = 0,
        ACCOUNT_REPEAT = 1,
        ACCOUNT_LOCKED = 2,
        WORNG_PASSWORD = 3,
    }

    public interface IAccountRepository
    {
        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Account account) Add(Account account);

        /// <summary>
        /// 更新帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Account account) Update(Account account);

        /// <summary>
        /// 查詢單一帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Account account) Query(string account);

        /// <summary>
        /// 查詢帳號清單 顯示用
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, IEnumerable<Account> accounts) QueryList();

        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Account account) Delete(int id);
    }
}
