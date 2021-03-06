using ChatRoom.Domain.Model.DataType;
using System;
using System.Collections.Generic;

namespace ChatRoom.Domain.Repository
{
    public interface IHistoryRepository
    {
        /// <summary>
        /// 插入單筆資料
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        (Exception exception, History history) Add(History history);

        /// <summary>
        /// 整理資料 清除多於10筆的資料
        /// </summary>
        /// <returns></returns>
        (Exception exception, IEnumerable<History> historys) SortOut();

        /// <summary>
        /// 查詢歷史紀錄清單 最多10筆
        /// </summary>
        /// <returns></returns>
        (Exception exception, IEnumerable<History> historys) QueryList(int roomID);

        (Exception exception, ResultCode resultCode) Delete(string account);

    }
}
