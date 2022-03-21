namespace ChatRoom.Domain.Model.Process
{
    public enum MainProcessType
    {
        [EnumDisplay("1. 登入")]
        Login = 1,
        [EnumDisplay("2. 註冊")]
        Register = 2,
        [EnumDisplay("3. 離開")]
        Leave = 3,
    }

    public interface IMainProcess
    {
        bool Execute();
    }
}
