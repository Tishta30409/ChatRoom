using Autofac;
using ChatRoom.Client.Model;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Model;
using System.Reflection;

namespace ChatRoom.Client.Applibs
{
    internal static class AutofacConfig
    {
        private static IContainer container;

        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    Register();
                }

                return container;
            }
        }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            var asm = Assembly.GetExecutingAssembly();

            // 指定處理client指令的handler
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IActionHandler>())
                .Named<IActionHandler>(t => t.Name.Replace("ActionHandler", string.Empty).ToLower())
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // console wrapper
            builder.RegisterType<ConsoleWrapper>()
                .As<IConsoleWrapper>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // hubclient
            builder.RegisterType<HubClient>()
                .WithParameter("url", ConfigHelper.SignalrUrl)
                .WithParameter("hubName", "ChatRoomHub")
                .As<IHubClient>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            container = builder.Build();
        }

    }
}
