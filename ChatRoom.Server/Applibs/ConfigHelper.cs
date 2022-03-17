using System.Configuration;

namespace ChatRoom.Server.Applibs
{
    internal static class ConfigHelper
    {
           public static string SignalrUrl
        {
            get
                => $"http://localhost:8085";
        }

        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ChatRoom"].ConnectionString;
    }
}
