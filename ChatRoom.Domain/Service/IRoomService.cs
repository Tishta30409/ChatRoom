using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using System;
using System.Collections.Generic;

namespace ChatRoom.Domain.Service
{
    public interface IRoomService
    {
        /// <summary>
        /// 新增帳號(輸入房間名即可)
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, ResultCode resultCode) Add(string roomName);

        /// <summary>
        /// 更新帳號(--後台LIST 會先列出列表 選擇後才可以改名或刪除)
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Room room) Update(Room room);

        /// <summary>
        /// 列出所有的房間
        /// </summary>
        /// <returns></returns>
        (Exception exception, IEnumerable<Room> rooms) GetList();

        /// <summary>
        /// 刪除房間 同時會刪除歷史資料
        /// </summary>
        /// <param account="accoumt"></param>
        /// <returns></returns>
        (Exception exception, Room room) Delete(int id);
    }
}
