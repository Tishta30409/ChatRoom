namespace ChatRoom.Domain.Model.Process
{
    public enum BackStageProcessType
    {

        [EnumDisplay("1. 更新會員資料")]
        AccountUpdate = 1,
        [EnumDisplay("2. 解除會員鎖定")]
        AccountUnlock = 2,
        [EnumDisplay("3. 禁言會員")]
        AccountMute = 3,
        [EnumDisplay("4. 刪除會員")]
        AccountDelete = 4,
        [EnumDisplay("5. 新增房間")]
        RoomAdd = 5,
        [EnumDisplay("6. 更新房間")]
        RoomUpdate = 6,
        [EnumDisplay("7. 刪除房間")]
        RoomDelete = 7,
        [EnumDisplay("8. 查詢歷史訊息")]
        HistoryQuery = 8,
    }

    public interface IBackStageProcess
    {
        bool Execute();
    }
}
