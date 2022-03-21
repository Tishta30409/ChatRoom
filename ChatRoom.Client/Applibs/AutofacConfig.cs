using Autofac;
using ChatRoom.Client.Model;
using ChatRoom.Client.Model.Process;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using System;
using System.Linq;
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

            // MainProcess
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IMainProcess>())
                .Keyed<IMainProcess>(p => (MainProcessType)Enum.Parse(typeof(MainProcessType), p.Name.Replace("MainProcess", string.Empty), true))
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // Process
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IProcess>())
                .Keyed<IProcess>(p => (ProcessType)Enum.Parse(typeof(ProcessType), p.Name.Replace("Process", string.Empty), true))
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // console wrapper
            builder.RegisterType<ConsoleWrapper>()
                .As<IConsoleWrapper>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // service
            builder.RegisterAssemblyTypes(Assembly.Load("ChatRoom.Domain"))
                .WithParameter("serviceUri", ConfigHelper.ServiceUrl)
                .WithParameter("timeout", 5)
                .Where(t => t.Namespace == "ChatRoom.Domain.Service")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"))
                .SingleInstance();

            // hubclient
            builder.RegisterType<HubClient>()
                .WithParameter("url", ConfigHelper.SignalrUrl)
                .WithParameter("hubName", "ChatRoomHub")
                .As<IHubClient>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // 指定處理client指令的handler
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IActionHandler>())
                .Named<IActionHandler>(t => t.Name.Replace("ActionHandler", string.Empty).ToLower())
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            container = builder.Build();
        }

    }
}
