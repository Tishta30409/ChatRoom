namespace ChatRoom.Domain.Model.Process
{
    public enum BackStageProcessType
    {

        [EnumDisplay("1. 更新會員資料")]
        UpdateAccount = 1,
        [EnumDisplay("2. 解除會員鎖定")]
        UnlockAccount = 2,
        [EnumDisplay("3. 禁言會員")]
        MuteAccount = 3,
        [EnumDisplay("4. 刪除會員")]
        DeleteAccount = 4,
        [EnumDisplay("5. 新增房間")]
        AddRoom = 5,
        [EnumDisplay("6. 更新房間")]
        UpdateRoom = 6,
        [EnumDisplay("7. 刪除房間")]
        DeleteRoom = 7,
        [EnumDisplay("8. 查詢歷史訊息")]
        QueryHistory = 8,
    }

    public interface IBackStageProcess
    {
        bool Execute();
    }
}
