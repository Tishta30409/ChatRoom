
namespace ChatRoom.Client.UI.Applibs
{
    using Autofac;
    using ChatRoom.Client.UI.Forms;
    using ChatRoom.Client.UI.Model;
    using ChatRoom.Client.UI.Signalr;
    using System.Linq;
    using System.Reflection;


    /// <summary>
    /// autofac 設定檔
    /// </summary>
    internal static class AutofacConfig
    {
        /// <summary>
        /// autofac 裝載介面跟實作的容器
        /// </summary>
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

        /// <summary>
        /// 註冊容器
        /// </summary>
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var asm = Assembly.GetExecutingAssembly();

            // 取出當前執行assembly, 讓繼承IActionHandler且名稱結尾為ActionHandler的對應事件名稱
            // ex LoginResultAction對應的是LoginResultActionHandler
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IActionHandler>())
                .Named<IActionHandler>(t => t.Name.Replace("ActionHandler", string.Empty).ToLower())
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            builder.RegisterType<HubClient>()
                .WithParameter("url", ConfigHelper.SignalrUrl)
                .WithParameter("hubName", ConfigHelper.SignalrHubName)
                .As<IHubClient>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // service
            builder.RegisterAssemblyTypes(Assembly.Load("ChatRoom.Domain"))
                .WithParameter("serviceUri", ConfigHelper.ServiceUrl)
                .WithParameter("timeout", 5)
                .Where(t => t.Namespace == "ChatRoom.Domain.Service")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"))
                .SingleInstance();

            builder.RegisterType<MainForm>()
                .SingleInstance();

            builder.RegisterType<LobbyForm>()
                .SingleInstance();

            builder.RegisterType<ChatRoomForm>()
                .SingleInstance();

            builder.RegisterType<UserListForm>()
                .SingleInstance();

            builder.RegisterType<ChangePasswordForm>()
                .SingleInstance();

            container = builder.Build();
        }
    }
}
