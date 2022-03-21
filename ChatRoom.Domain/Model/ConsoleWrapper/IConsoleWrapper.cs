
namespace ChatRoom.Domain.Model
{

    public interface IConsoleWrapper
    {

        void Clear();

        int Read();

        string ReadLine();

        void Write(string str);

        void WriteLine(string str);
    }
}
