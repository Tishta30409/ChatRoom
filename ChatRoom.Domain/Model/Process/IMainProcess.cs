namespace ChatRoom.Domain.Model.Process
{
    public enum MainProcessType
    {
        [EnumDisplay("1. 登入")]
        Login = 1,
        [EnumDisplay("2. 註冊")]
        Register = 2,
    }

    public enum ProcessViewType
    {
        Main = 0,
        Login = 1,
        Register = 2,
        Lobby = 3,
        ChatRoom = 4,
    }

    public interface IMainProcess
    {
        ProcessViewType Execute();
    }
}
