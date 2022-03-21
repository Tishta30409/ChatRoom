namespace ChatRoom.Domain.Model.Process
{
    public enum ProcessType
    {
        Lobby = 1,
        ChatRoom = 2,
    }

    public interface IProcess
    {
        bool Execute();
    }
}
