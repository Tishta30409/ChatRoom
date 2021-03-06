using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using System;
using System.Collections.Generic;

namespace ChatRoom.Domain.Repository
{
    public enum ResultCode
    {
        [EnumDisplay("預期外的錯誤")]
        DEFAULT_ERROR = -1,
        [EnumDisplay("成功")]
        SUCCESS = 0,
        [EnumDisplay("帳號重複")]
        ACCOUNT_REPEAT = 1,
        [EnumDisplay("帳號已鎖定")]
        ACCOUNT_LOCKED = 2,
        [EnumDisplay("帳號不存在")]
        ACCOUNT_NOTEXIST = 3,
        [EnumDisplay("密碼錯誤")]
        WORNG_PASSWORD = 4,
        [EnumDisplay("帳號未啟用")]
        ACCOUNT_UNACTIVE = 5,
        [EnumDisplay("房間名稱重複")]
        ROOM_REPEAT = 6,
        [EnumDisplay("資料需要更新")]
        DATA_NEED_REFRESH = 7
    }

    public interface IAccountRepository
    {
        /// <summary>
        /// 帳號登入
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, AccountResult result) Login(Account login);

        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, ResultCode result) Add(Account account);

        /// <summary>
        /// 更新帳號
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, AccountResult result) Update(Account account);

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

        (Exception exception, Account account) ChangePwd(Account account);
    }
}
