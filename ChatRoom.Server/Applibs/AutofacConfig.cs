using Autofac;
using ChatRoom.Server.Model;
using System.Linq;
using System.Reflection;

namespace ChatRoom.Server.Applibs
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

        private static void Register()
        {
            var builder = new ContainerBuilder();
            var asm = Assembly.GetExecutingAssembly();

            // Action Handler
            builder.RegisterAssemblyTypes(asm)
                .Named<IActionHandler>(t => t.Name.Replace("ActionHandler", string.Empty).ToLower())
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // sql ioc
            builder.RegisterAssemblyTypes(Assembly.Load("ChatRoom.Persistent"), Assembly.Load("ChatRoom.Domain"))
                .WithParameter("connectionString", ConfigHelper.ConnectionString)
                .Where(t => t.Namespace == "ChatRoom.Persistent.Repository" || t.Namespace == "ChatRoom.Domain.Repository")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"))
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            container = builder.Build();
        }
    }
}
