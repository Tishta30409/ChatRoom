using System.Configuration;

namespace ChatRoom.Client.Applibs
{
    internal static class ConfigHelper
    {
        public static string SignalrUrl
        {
            get
                => $"http://{ConfigurationManager.AppSettings["SignalrUrl"]}:8085/signalr";
        }

        public static string ServiceUrl
        {
            get
                => $"http://{ConfigurationManager.AppSettings["ServiceUrl"]}:8085";
        }
    }
}
